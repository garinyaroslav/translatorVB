namespace coursework
{
    partial class MainForm
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
		private void InitializeComponent() {
			CodeBox = new TextBox();
			RunBut = new Button();
			ResultBox = new TextBox();
			ExprBox = new TextBox();
			ResBut = new Button();
			SuspendLayout();
			// 
			// CodeBox
			// 
			CodeBox.BackColor = SystemColors.MenuText;
			CodeBox.Font = new Font("Segoe UI", 12F);
			CodeBox.ForeColor = SystemColors.Menu;
			CodeBox.Location = new Point(12, 12);
			CodeBox.Multiline = true;
			CodeBox.Name = "CodeBox";
			CodeBox.Size = new Size(390, 382);
			CodeBox.TabIndex = 0;
			CodeBox.Text = "Dim a as integer\r\nb=1\r\ndo while (a < 10 and a > 5)\r\n b = b + a\r\nloop";
			// 
			// RunBut
			// 
			RunBut.BackColor = SystemColors.Window;
			RunBut.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			RunBut.Location = new Point(422, 12);
			RunBut.Name = "RunBut";
			RunBut.Size = new Size(78, 43);
			RunBut.TabIndex = 1;
			RunBut.Text = "RUN";
			RunBut.UseVisualStyleBackColor = false;
			RunBut.Click += RunBut_Click;
			// 
			// ResultBox
			// 
			ResultBox.BackColor = SystemColors.MenuText;
			ResultBox.Font = new Font("Segoe UI", 12F);
			ResultBox.ForeColor = SystemColors.Menu;
			ResultBox.Location = new Point(519, 12);
			ResultBox.Multiline = true;
			ResultBox.Name = "ResultBox";
			ResultBox.ReadOnly = true;
			ResultBox.ScrollBars = ScrollBars.Vertical;
			ResultBox.Size = new Size(371, 632);
			ResultBox.TabIndex = 2;
			// 
			// ExprBox
			// 
			ExprBox.BackColor = SystemColors.MenuText;
			ExprBox.Font = new Font("Segoe UI", 12F);
			ExprBox.ForeColor = SystemColors.Menu;
			ExprBox.Location = new Point(12, 410);
			ExprBox.Multiline = true;
			ExprBox.Name = "ExprBox";
			ExprBox.ReadOnly = true;
			ExprBox.Size = new Size(390, 234);
			ExprBox.TabIndex = 3;
			// 
			// ResBut
			// 
			ResBut.BackColor = SystemColors.Window;
			ResBut.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ResBut.Location = new Point(422, 76);
			ResBut.Name = "ResBut";
			ResBut.Size = new Size(78, 43);
			ResBut.TabIndex = 4;
			ResBut.Text = "RES";
			ResBut.UseVisualStyleBackColor = false;
			ResBut.Click += ResBut_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.WindowText;
			ClientSize = new Size(905, 667);
			Controls.Add(ResBut);
			Controls.Add(ExprBox);
			Controls.Add(ResultBox);
			Controls.Add(RunBut);
			Controls.Add(CodeBox);
			Name = "MainForm";
			Text = "AUTOMATS";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox CodeBox;
        private Button RunBut;
        private TextBox ResultBox;
		private TextBox ExprBox;
		private Button ResBut;
	}
}
