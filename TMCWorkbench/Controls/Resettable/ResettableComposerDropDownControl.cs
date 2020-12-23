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

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableComposerDropDownControl : _ResettableDropDownHoldControl
    {
        public ResettableComposerDropDownControl()
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
            DBManager.Instance.LoadComposers();

            var query = from composer in DB.DBManager.Instance.Composers
                        select new { composer.Name, composer.Composer_id };

            var bindingSource = new BindingSource();
            var list = query.ToList();
            var s = new TMCDatabase.DBModel.Composer();
            s.Composer_id = 0;
            s.Name = "== SELECT COMPOSER ==";

            list.Insert(0, new { s.Name, s.Composer_id });

            bindingSource.DataSource = list;

            ddList.DisplayMember = "Name";
            ddList.ValueMember = "Composer_id";
            ddList.AutoCompleteMode = AutoCompleteMode.Suggest;
            ddList.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddList.DataSource = bindingSource;
        }

        public void Reset()
        {
            ddList.SelectedValue = 0;
        }

        public bool SetComposer(string text)
        {
            if (text != null)
            {
                var composer = DBManager.Instance.Composers.Where(x => x.Name.ToLow() == text.ToLow()).FirstOrNull();

                if (composer != null)
                {
                    ddList.SelectedValue = composer.Composer_id;
                    return true;
                }
            }

            ddList.SelectedValue = 0;
            return false;
        }

        public void SetComposer(int? id)
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
