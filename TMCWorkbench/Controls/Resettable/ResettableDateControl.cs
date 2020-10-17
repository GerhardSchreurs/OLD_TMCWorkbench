﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Extensions;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableDateControl : _ResettableControlPanel
    {
        public ResettableDateControl()
        {
            InitializeComponent();

            this.resettableControl1.OnReset += ResettableControl1_OnReset;

            Init();
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

        private void ResettableControl1_OnReset(object sender, EventArgs e)
        {
            UpdateDate();
        }

        void Init()
        {
            for (var i = 1990; i <= DateTime.Now.Year + 1; i++)
            {
                ddlYear.Items.Add(i);
            }

            for (var i = 0; i<12; i++)
            {
                ddlMonth.Items.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i + 1));
            }
        }

        private void Handle_ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = (int)ddlYear.SelectedItem;
            int month = (int)ddlMonth.SelectedIndex + 1;

            UpdateDays(year, month);
        }

        void UpdateDays(int year, int month)
        {
            var days = DateTime.DaysInMonth(year, month);

            ddlDay.Items.Clear();

            for (var i = 0; i < days; i++)
            {
                ddlDay.Items.Add(i + 1);
            }
        }

        void UpdateDate()
        {
            this.ddlMonth.SelectedIndexChanged -= Handle_ddlMonth_SelectedIndexChanged;

            if (_date.HasValue)
            {
                ddlYear.SelectedItem = _date.Value.Year;
                ddlMonth.SelectedIndex = _date.Value.Month - 1;
                UpdateDays(_date.Value.Year, _date.Value.Month);
                ddlDay.SelectedIndex = _date.Value.Day - 1;
            }
            else
            {
                ddlYear.SelectedIndex = -1;
                ddlMonth.SelectedIndex = -1;
                ddlDay.SelectedIndex = -1;
            }



            this.ddlMonth.SelectedIndexChanged += Handle_ddlMonth_SelectedIndexChanged;
        }

        public bool ProcessEnteredDate()
        {
            var returnValue = false;

            if (ddlYear.SelectedIndex >= 0)
            {
                var year = ddlYear.Text.ToInt();
                var month = ddlMonth.SelectedIndex + 1;
                var day = ddlDay.SelectedIndex + 1;
                int hour = 0, minute = 0, second = 0, millisecond = 0;

                if (_date.HasValue)
                {
                    hour = _date.Value.Hour;
                    minute = _date.Value.Minute;
                    second = _date.Value.Second;
                    millisecond = _date.Value.Millisecond;
                }


                _date = new DateTime(year, month, day, hour, minute, second, millisecond);

                returnValue = true;
            }

            return returnValue;
        }


        private DateTime? _date;
        public DateTime? Date
        {
            get
            {
                ProcessEnteredDate();
                return _date;
            }
            set
            {
                _date = value;
                UpdateDate();
            }
        }
    }
}
