namespace _DNA_
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtmautin = new System.Windows.Forms.RichTextBox();
            this.txthidden = new System.Windows.Forms.TextBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lstlblCurrent = new System.Windows.Forms.ListBox();
            this.lstlblAfter = new System.Windows.Forms.ListBox();
            this.lblcurrernt = new System.Windows.Forms.Label();
            this.lblafter = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnClearAfter = new System.Windows.Forms.Button();
            this.btnfromFile = new System.Windows.Forms.Button();
            this.lstBoxPDFcurrent = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtmautin
            // 
            this.txtmautin.Location = new System.Drawing.Point(29, 12);
            this.txtmautin.Name = "txtmautin";
            this.txtmautin.Size = new System.Drawing.Size(100, 96);
            this.txtmautin.TabIndex = 0;
            this.txtmautin.Text = "DANG THI HUE VIET NAM TRUYEN GIAO";
            // 
            // txthidden
            // 
            this.txthidden.Location = new System.Drawing.Point(29, 126);
            this.txthidden.Name = "txthidden";
            this.txthidden.Size = new System.Drawing.Size(100, 20);
            this.txthidden.TabIndex = 1;
            this.txthidden.Text = "HUE";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(176, 26);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 2;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(176, 123);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lstlblCurrent
            // 
            this.lstlblCurrent.FormattingEnabled = true;
            this.lstlblCurrent.Location = new System.Drawing.Point(29, 175);
            this.lstlblCurrent.Name = "lstlblCurrent";
            this.lstlblCurrent.Size = new System.Drawing.Size(120, 173);
            this.lstlblCurrent.TabIndex = 4;
            // 
            // lstlblAfter
            // 
            this.lstlblAfter.FormattingEnabled = true;
            this.lstlblAfter.Location = new System.Drawing.Point(176, 175);
            this.lstlblAfter.Name = "lstlblAfter";
            this.lstlblAfter.Size = new System.Drawing.Size(122, 173);
            this.lstlblAfter.TabIndex = 5;
            // 
            // lblcurrernt
            // 
            this.lblcurrernt.AutoSize = true;
            this.lblcurrernt.Location = new System.Drawing.Point(29, 153);
            this.lblcurrernt.Name = "lblcurrernt";
            this.lblcurrernt.Size = new System.Drawing.Size(41, 13);
            this.lblcurrernt.TabIndex = 6;
            this.lblcurrernt.Text = "Current";
            // 
            // lblafter
            // 
            this.lblafter.AutoSize = true;
            this.lblafter.Location = new System.Drawing.Point(176, 153);
            this.lblafter.Name = "lblafter";
            this.lblafter.Size = new System.Drawing.Size(29, 13);
            this.lblafter.TabIndex = 7;
            this.lblafter.Text = "After";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(461, 175);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(180, 164);
            this.txtResult.TabIndex = 8;
            this.txtResult.Text = "";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(475, 152);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 9;
            this.lblResult.Text = "Result";
            // 
            // btnClearAfter
            // 
            this.btnClearAfter.Location = new System.Drawing.Point(278, 123);
            this.btnClearAfter.Name = "btnClearAfter";
            this.btnClearAfter.Size = new System.Drawing.Size(75, 23);
            this.btnClearAfter.TabIndex = 10;
            this.btnClearAfter.Text = "Clear After";
            this.btnClearAfter.UseVisualStyleBackColor = true;
            this.btnClearAfter.Click += new System.EventHandler(this.btnClearAfter_Click);
            // 
            // btnfromFile
            // 
            this.btnfromFile.Location = new System.Drawing.Point(322, 26);
            this.btnfromFile.Name = "btnfromFile";
            this.btnfromFile.Size = new System.Drawing.Size(91, 23);
            this.btnfromFile.TabIndex = 11;
            this.btnfromFile.Text = "From File PDF";
            this.btnfromFile.UseVisualStyleBackColor = true;
            this.btnfromFile.Click += new System.EventHandler(this.btnfromFile_Click);
            // 
            // lstBoxPDFcurrent
            // 
            this.lstBoxPDFcurrent.FormattingEnabled = true;
            this.lstBoxPDFcurrent.Location = new System.Drawing.Point(478, 13);
            this.lstBoxPDFcurrent.Name = "lstBoxPDFcurrent";
            this.lstBoxPDFcurrent.Size = new System.Drawing.Size(118, 134);
            this.lstBoxPDFcurrent.TabIndex = 12;
            this.lstBoxPDFcurrent.SelectedIndexChanged += new System.EventHandler(this.lstBoxPDFcurrent_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 351);
            this.Controls.Add(this.lstBoxPDFcurrent);
            this.Controls.Add(this.btnfromFile);
            this.Controls.Add(this.btnClearAfter);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblafter);
            this.Controls.Add(this.lblcurrernt);
            this.Controls.Add(this.lstlblAfter);
            this.Controls.Add(this.lstlblCurrent);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.txthidden);
            this.Controls.Add(this.txtmautin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtmautin;
        private System.Windows.Forms.TextBox txthidden;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ListBox lstlblCurrent;
        private System.Windows.Forms.ListBox lstlblAfter;
        private System.Windows.Forms.Label lblcurrernt;
        private System.Windows.Forms.Label lblafter;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnClearAfter;
        private System.Windows.Forms.Button btnfromFile;
        private System.Windows.Forms.ListBox lstBoxPDFcurrent;
        private System.Windows.Forms.RichTextBox txtInputWord;
        private System.Windows.Forms.TextBox txtPDf;
    }
}

