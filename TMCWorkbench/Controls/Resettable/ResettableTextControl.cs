﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableTextControl : ResettableControlPanel
    {
        public ResettableTextControl()
        {
            InitializeComponent();

            this.resettableControl1.Title = "File:";
            this.resettableControl1.OnReset += ResettableControl1_OnReset;
        }

        private void ResettableControl1_OnReset(object sender, EventArgs e)
        {
            Filename = _fileName;
        }

        private string _fileName;

        public string Filename
        {
            get { return _fileName;  }
            set {
                _fileName = value;
                this.txtFilename.Text = value;
            }
        }
    }
}