using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Controls
{
    public partial class ControlDateChooser : UserControl
    {
        public DateTime? DateSelectedLow
        {
            get
            {
                if (ddlY.SelectedIndex <= 0) return null;

                var y = ddlY.SelectedItem.ToInt();
                var m = 1;
                var d = 1;

                if (ddlM.SelectedIndex > 0)
                    m = ddlM.SelectedItem.ToInt();
                if (ddlD.SelectedIndex > 0)
                    d = ddlD.SelectedItem.ToInt();

                return new DateTime(y, m, d);
            }
        }

        public DateTime? DateSelectedHigh
        {
            get
            {
                if (ddlY.SelectedIndex <= 0) return null;

                var y = ddlY.SelectedItem.ToInt();
                var m = 12;
                var d = 31;

                if (ddlM.SelectedIndex > 0)
                    m = ddlM.SelectedItem.ToInt();
                if (ddlD.SelectedIndex > 0)
                    d = ddlD.SelectedItem.ToInt();

                return new DateTime(y, m, d);
            }
        }


        public void Init(DateTime startdate, DateTime endDate)
        {
            //if (date < startdate || date > endDate)
            //    return;

            if (startdate > endDate)
                return;

            var startYear = startdate.Year;
            var stopYear = endDate.Year;

            for (var i = startYear; i <= stopYear; i++)
            {
                ddlY.Items.Add(i);
            }
            ddlY.Items.Insert(0, "");

            for (var i = 1; i <= 12; i++)
            {
                ddlM.Items.Add(i.ToString("D2"));
            }
            ddlM.Items.Insert(0, "");

            //var days = DateTime.DaysInMonth(date.Year, date.Month);
            var days = 31;

            for (var i = 1; i <= days; i++)
            {
                ddlD.Items.Add(i.ToString("D2"));
            }
            ddlD.Items.Insert(0, "");

            //ddlY.SelectedItem = date.Year;
            //ddlM.SelectedItem = date.Month.ToString("D2");
            //ddlD.SelectedItem = date.Day.ToString("D2");

            ddlM.SelectedValueChanged += Handle_DdlM_SelectedValueChanged;
        }

        private void FillDays(int y, int m)
        {
            ddlD.Items.Clear();
            var days = DateTime.DaysInMonth(y, m);

            for (var i = 1; i<=days; i++)
            {
                ddlD.Items.Add(i.ToString("D2"));
            }
            ddlD.Items.Insert(0, "");
        }

        private void Handle_DdlM_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ddlY.SelectedItem.IsNumeric() == false || ddlM.SelectedItem.IsNumeric() == false) return;

            var y = ddlY.SelectedItem.ToInt();
            var m = ddlM.SelectedItem.ToInt();
            var d = ddlD.SelectedItem.ToInt();

            var days = DateTime.DaysInMonth(y, m);

            if (d > days)
            {
                ddlD.SelectedItem = days.ToString("D2");
            }

            if (ddlD.Items.Count != days)
            {
                FillDays(y, m);
            }
        }

        public ControlDateChooser()
        {
            InitializeComponent();
        }
    }
}
