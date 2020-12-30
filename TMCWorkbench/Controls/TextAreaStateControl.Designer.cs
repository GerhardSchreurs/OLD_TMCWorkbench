
namespace TMCWorkbench.Controls
{
    partial class TextAreaStateControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextAreaStateControl));
            this.panelState = new System.Windows.Forms.Panel();
            this.txtNew = new TMCWorkbench.Controls.TextAreaControl();
            this.txtOrg = new TMCWorkbench.Controls.TextAreaControl();
            this.panelState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrg)).BeginInit();
            this.SuspendLayout();
            // 
            // panelState
            // 
            this.panelState.Controls.Add(this.txtOrg);
            this.panelState.Controls.Add(this.txtNew);
            this.panelState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelState.Location = new System.Drawing.Point(0, 0);
            this.panelState.Name = "panelState";
            this.panelState.Size = new System.Drawing.Size(408, 263);
            this.panelState.TabIndex = 0;
            // 
            // txtNew
            // 
            this.txtNew.AllowMacroRecording = false;
            this.txtNew.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtNew.AutoScrollMinSize = new System.Drawing.Size(0, 18);
            this.txtNew.BackBrush = null;
            this.txtNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNew.CharHeight = 12;
            this.txtNew.CharWidth = 6;
            this.txtNew.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNew.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNew.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtNew.IsReplaceMode = false;
            this.txtNew.Location = new System.Drawing.Point(0, 0);
            this.txtNew.Name = "txtNew";
            this.txtNew.Paddings = new System.Windows.Forms.Padding(3);
            this.txtNew.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtNew.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtNew.ServiceColors")));
            this.txtNew.ShowLineNumbers = false;
            this.txtNew.Size = new System.Drawing.Size(408, 75);
            this.txtNew.TabIndex = 0;
            this.txtNew.Text = "txtNew";
            this.txtNew.WordWrap = true;
            this.txtNew.Zoom = 100;
            // 
            // txtOld
            // 
            this.txtOrg.AllowMacroRecording = false;
            this.txtOrg.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtOrg.AutoScrollMinSize = new System.Drawing.Size(0, 18);
            this.txtOrg.BackBrush = null;
            this.txtOrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrg.CharHeight = 12;
            this.txtOrg.CharWidth = 6;
            this.txtOrg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOrg.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtOrg.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtOrg.IsReplaceMode = false;
            this.txtOrg.Location = new System.Drawing.Point(0, 75);
            this.txtOrg.Name = "txtOld";
            this.txtOrg.Paddings = new System.Windows.Forms.Padding(3);
            this.txtOrg.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtOrg.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtOld.ServiceColors")));
            this.txtOrg.ShowLineNumbers = false;
            this.txtOrg.Size = new System.Drawing.Size(408, 75);
            this.txtOrg.TabIndex = 1;
            this.txtOrg.Text = "txtOld";
            this.txtOrg.WordWrap = true;
            this.txtOrg.Zoom = 100;
            // 
            // StateTextAreaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelState);
            this.Name = "StateTextAreaControl";
            this.Size = new System.Drawing.Size(408, 263);
            this.panelState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelState;
        private TextAreaControl txtOrg;
        private TextAreaControl txtNew;
    }
}
