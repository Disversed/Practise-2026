namespace _13_APM_additional
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
            this.isCompleteBtn = new System.Windows.Forms.Button();
            this.endBtn = new System.Windows.Forms.Button();
            this.callbackBtn = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // isCompleteBtn
            // 
            this.isCompleteBtn.Location = new System.Drawing.Point(98, 243);
            this.isCompleteBtn.Name = "isCompleteBtn";
            this.isCompleteBtn.Size = new System.Drawing.Size(178, 51);
            this.isCompleteBtn.TabIndex = 0;
            this.isCompleteBtn.Text = "IsComplete";
            this.isCompleteBtn.UseVisualStyleBackColor = true;
            this.isCompleteBtn.Click += new System.EventHandler(this.isCompleteBtn_Click);
            // 
            // endBtn
            // 
            this.endBtn.Location = new System.Drawing.Point(295, 243);
            this.endBtn.Name = "endBtn";
            this.endBtn.Size = new System.Drawing.Size(178, 51);
            this.endBtn.TabIndex = 1;
            this.endBtn.Text = "End";
            this.endBtn.UseVisualStyleBackColor = true;
            this.endBtn.Click += new System.EventHandler(this.endBtn_Click);
            // 
            // callbackBtn
            // 
            this.callbackBtn.Location = new System.Drawing.Point(494, 243);
            this.callbackBtn.Name = "callbackBtn";
            this.callbackBtn.Size = new System.Drawing.Size(178, 51);
            this.callbackBtn.TabIndex = 2;
            this.callbackBtn.Text = "Callback";
            this.callbackBtn.UseVisualStyleBackColor = true;
            this.callbackBtn.Click += new System.EventHandler(this.callbackBtn_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(12, 357);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(776, 81);
            this.logBox.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(269, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(415, 130);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.callbackBtn);
            this.Controls.Add(this.endBtn);
            this.Controls.Add(this.isCompleteBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button isCompleteBtn;
        private System.Windows.Forms.Button endBtn;
        private System.Windows.Forms.Button callbackBtn;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

