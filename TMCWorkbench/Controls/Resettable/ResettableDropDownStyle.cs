﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench.DB;
using TMCWorkbench;
using FastColoredTextBoxNS;
using TMCDatabase.DBModel;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableDropDownStyle : _XResettableDropDownHoldControl
    {
        public ResettableDropDownStyle()
        {
            InitializeComponent();
        }

        public override string LabelTitle
        {
            get => base.LabelTitle;
            set
            {
                base.LabelTitle = value;
                this.resettableControl1.Title = value;
            }
        }

        public void Init()
        {
            DBManager.Instance.LoadStyles();

            //var query = from style in DB.Manager.Instance.C.Styles
            //            select new { style.Name, style.Style_id };

            var query = from style in DB.DBManager.Instance.Styles
                        where style.IsAlt == false
                        select new { style.Name, style.Style_id };

            var bindingSource = new BindingSource();
            var list = query.ToList();
            var s = new TMCDatabase.DBModel.Style();
            s.Style_id = 0;
            s.Name = "== SELECT STYLE ==";

            list.Insert(0, new { s.Name, s.Style_id });

            bindingSource.DataSource = list;

            ddList.DisplayMember = "Name";
            ddList.ValueMember = "Style_id";
            ddList.AutoCompleteMode = AutoCompleteMode.Suggest;
            ddList.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddList.DataSource = bindingSource;

            btnEdit.Click += Handle_BtnEdit_Click;
        }

        private void Handle_BtnEdit_Click(object sender, EventArgs e)
        {
            using (var f = new UCStyles())
            {
                f.ShowDialog();
            }
        }

        public void Reset()
        {
            ddList.SelectedValue = 0;
        }

        public bool SetStyle(string text)
        {
            if (text.IsNotNullOrEmpty())
            {
                var style = DB.DBManager.Instance.Styles.Where(x => x.Name.ToLow() == text.ToLow()).FirstOrNull();

                if (style != null)
                {
                    ddList.SelectedValue = style.Style_id;
                    return true;
                }
            }

            ddList.SelectedValue = 0;
            return false;
        }

        public void SetStyle(int? id)
        {
            if (id.HasValue)
            {
                ddList.SelectedValue = id.Value;
            }
            else
            {
                ddList.SelectedValue = 0;
            }
        }
    }
}
