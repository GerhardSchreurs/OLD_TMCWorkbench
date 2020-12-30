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
    public partial class OutputControl : UserControl
    {
        private bool showYoutube = false;

        public void Clear()
        {
            txtHeader.Clear();
            txtHeaderYT.Clear();
            txtSummary.Clear();
            txtSummaryYT.Clear();
        }

        public string TextHeaderOrg
        {
            get => txtHeader.TextOrg;
            set
            {
                txtHeader.TextOrg = value;
                txtHeaderYT.TextOrg = value;
            }
        }

        public string TextHeaderNew
        {
            get => txtHeader.TextNew;
            set
            {
                txtHeader.TextNew = value;
                txtHeaderYT.TextNew = value;
            }
        }

        public string TextSummaryOrg
        {
            get => txtSummary.TextOrg;
            set
            {
                txtSummary.TextOrg = value;
                txtSummaryYT.TextOrg = value;
            }
        }

        public string TextSummaryNew
        {
            get => txtSummary.TextNew;
            set
            {
                txtSummary.TextNew = value;
                txtSummaryYT.TextNew = value;
            }
        }

        public OutputControl()
        {
            InitializeComponent();

            ShowNew();
        }

        public void Show(bool showNew = true)
        {
            if (showNew)
                ShowNew();
            else
                ShowOld();
        }


        public void ShowNew()
        {
            if (showYoutube)
                ShowNewYoutube();
            else
                ShowNewOriginal();
        }

        public void ShowOld()
        {
            if (showYoutube)
                ShowOldYoutube();
            else
                ShowOldOriginal();
        }

        private void ShowNewOriginal()
        {
            txtHeaderYT.Visible = false;
            txtSummaryYT.Visible = false;

            txtHeader.Dock = DockStyle.Fill;
            txtSummary.Dock = DockStyle.Fill;
            txtHeader.Visible = true;
            txtSummary.Visible = true;

            txtHeader.ShowNew();
            txtSummary.ShowNew();
        }

        private void ShowNewYoutube()
        {
            txtHeader.Visible = false;
            txtSummary.Visible = false;

            txtHeaderYT.TextNew = txtHeader.TextNew;

            txtHeaderYT.Dock = DockStyle.Fill;
            txtSummaryYT.Dock = DockStyle.Fill;
            txtHeaderYT.Visible = true;
            txtSummaryYT.Visible = true;

            txtHeaderYT.ShowNew();
            txtSummaryYT.ShowNew();
        }

        private void ShowOldOriginal()
        {
            txtHeaderYT.Visible = false;
            txtSummaryYT.Visible = false;

            txtHeader.Dock = DockStyle.Fill;
            txtSummary.Dock = DockStyle.Fill;
            txtHeader.Visible = true;
            txtSummary.Visible = true;

            txtHeaderYT.ShowOld();
            txtSummary.ShowOld();
        }

        private void ShowOldYoutube()
        {
            txtHeader.Visible = false;
            txtSummary.Visible = false;

            txtHeaderYT.TextNew = txtHeader.TextNew;

            txtHeaderYT.Dock = DockStyle.Fill;
            txtSummaryYT.Dock = DockStyle.Fill;
            txtHeaderYT.Visible = true;
            txtSummaryYT.Visible = true;

            txtHeaderYT.ShowOld();
            txtSummaryYT.ShowOld();
        }
    }
}
