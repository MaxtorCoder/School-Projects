namespace RomanNumerals.GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OutputRoman = new System.Windows.Forms.Label();
            this.NummerInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HelpText = new System.Windows.Forms.Label();
            this.NummerOutput = new System.Windows.Forms.Label();
            this.RomanInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OutputRoman
            // 
            this.OutputRoman.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputRoman.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputRoman.Location = new System.Drawing.Point(16, 75);
            this.OutputRoman.MinimumSize = new System.Drawing.Size(235, 0);
            this.OutputRoman.Name = "OutputRoman";
            this.OutputRoman.Size = new System.Drawing.Size(235, 25);
            this.OutputRoman.TabIndex = 0;
            this.OutputRoman.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NummerInput
            // 
            this.NummerInput.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NummerInput.Location = new System.Drawing.Point(16, 30);
            this.NummerInput.Name = "NummerInput";
            this.NummerInput.Size = new System.Drawing.Size(235, 32);
            this.NummerInput.TabIndex = 1;
            this.NummerInput.TextChanged += new System.EventHandler(this.NummerInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nummer:";
            // 
            // HelpText
            // 
            this.HelpText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HelpText.Location = new System.Drawing.Point(16, 232);
            this.HelpText.MinimumSize = new System.Drawing.Size(235, 50);
            this.HelpText.Name = "HelpText";
            this.HelpText.Size = new System.Drawing.Size(235, 50);
            this.HelpText.TabIndex = 3;
            // 
            // NummerOutput
            // 
            this.NummerOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NummerOutput.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NummerOutput.Location = new System.Drawing.Point(16, 182);
            this.NummerOutput.MinimumSize = new System.Drawing.Size(235, 0);
            this.NummerOutput.Name = "NummerOutput";
            this.NummerOutput.Size = new System.Drawing.Size(235, 25);
            this.NummerOutput.TabIndex = 0;
            this.NummerOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RomanInput
            // 
            this.RomanInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RomanInput.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RomanInput.Location = new System.Drawing.Point(16, 137);
            this.RomanInput.Name = "RomanInput";
            this.RomanInput.Size = new System.Drawing.Size(235, 32);
            this.RomanInput.TabIndex = 1;
            this.RomanInput.TextChanged += new System.EventHandler(this.RomanInput_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Romeinse Nummer:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 295);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RomanInput);
            this.Controls.Add(this.NummerOutput);
            this.Controls.Add(this.HelpText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NummerInput);
            this.Controls.Add(this.OutputRoman);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Roman Numeral Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OutputRoman;
        private System.Windows.Forms.TextBox NummerInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HelpText;
        private System.Windows.Forms.Label NummerOutput;
        private System.Windows.Forms.TextBox RomanInput;
        private System.Windows.Forms.Label label3;
    }
}

