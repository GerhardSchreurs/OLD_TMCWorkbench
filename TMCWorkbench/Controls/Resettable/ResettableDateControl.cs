using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableDateControl : ResettableControlPanel
    {
        public ResettableDateControl()
        {
            InitializeComponent();

            this.resettableControl1.Title = "Date:";

            Init();
        }

        void Init()
        {
            for (var i = 1990; i < DateTime.Now.Year; i++)
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
            ddlYear.SelectedItem = _date.Year;
            ddlMonth.SelectedIndex = _date.Month - 1;
            UpdateDays(_date.Year, _date.Month);
            ddlDay.SelectedIndex = _date.Day - 1;

            this.ddlMonth.SelectedIndexChanged -= Handle_ddlMonth_SelectedIndexChanged;
            this.ddlMonth.SelectedIndexChanged += Handle_ddlMonth_SelectedIndexChanged;

        }

        private DateTime _date;
        public DateTime Date
        {
            get
            {
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
