using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Dialogs
{
    public partial class DoubleStringDialog : DialogBase
    {
        public string LabelA {
            get => lblA.Text;
            set => lblA.Text = value;
        }

        public string LabelB {
            get => lblB.Text;
            set => lblB.Text = value;
        }

        public string TextA {
            get => txtA.Text;
            set => txtA.Text = value;
        }

        public string TextB {
            get => txtB.Text;
            set => txtB.Text = value;
        }

        public string ButtonText {
            get => btnAction.Text;
            set => btnAction.Text = value;
        }

        public DoubleStringDialog()
        {
            InitializeComponent();
        }

        public DialogResult Show(string title, string lblA, string lblB, string txtA, string txtB, string okText)
        {
            Text = title;
            LabelA = lblA;
            LabelB = lblB;
            TextA = txtA;
            TextB = txtB;
            btnAction.Text = okText;
            return (ShowDialog());
        }
    }
}
