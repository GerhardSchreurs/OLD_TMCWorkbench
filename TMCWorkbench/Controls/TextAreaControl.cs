using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastColoredTextBoxNS;

namespace TMCWorkbench.Controls
{
    public class TextAreaControl : FastColoredTextBox
    {
        public TextAreaControl()
        {
            this.Font = new System.Drawing.Font("Consolas", 8.25f);
            this.AllowMacroRecording = false;
            this.AutoIndent = true;
            this.AutoIndentChars = true;
            this.AutoIndentExistingLines = true;
            this.ShowLineNumbers = false;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Paddings = new System.Windows.Forms.Padding(3);
            this.WordWrap = true;


            var x = this.HotkeysMapping;

            var mapping = new HotkeysMapping();

            Console.ReadLine();
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // TextAreaControl
            // 
            this.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Name = "TextAreaControl";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
