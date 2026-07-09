namespace _16_AppDomain_Additional
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
            this.chooseAssemblyBtn = new System.Windows.Forms.Button();
            this.assemblyPathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkFileRW = new System.Windows.Forms.CheckBox();
            this.checkNetworkAccess = new System.Windows.Forms.CheckBox();
            this.launchBtn = new System.Windows.Forms.Button();
            this.checkGuiPermission = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chooseAssemblyBtn
            // 
            this.chooseAssemblyBtn.Location = new System.Drawing.Point(641, 16);
            this.chooseAssemblyBtn.Name = "chooseAssemblyBtn";
            this.chooseAssemblyBtn.Size = new System.Drawing.Size(147, 43);
            this.chooseAssemblyBtn.TabIndex = 0;
            this.chooseAssemblyBtn.Text = "Choose assembly";
            this.chooseAssemblyBtn.UseVisualStyleBackColor = true;
            this.chooseAssemblyBtn.Click += new System.EventHandler(this.chooseAssemblyBtn_Click);
            // 
            // assemblyPathBox
            // 
            this.assemblyPathBox.Location = new System.Drawing.Point(12, 33);
            this.assemblyPathBox.Name = "assemblyPathBox";
            this.assemblyPathBox.ReadOnly = true;
            this.assemblyPathBox.Size = new System.Drawing.Size(595, 22);
            this.assemblyPathBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Assembly path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Assemply privileges:";
            // 
            // checkFileRW
            // 
            this.checkFileRW.AutoSize = true;
            this.checkFileRW.Location = new System.Drawing.Point(12, 106);
            this.checkFileRW.Name = "checkFileRW";
            this.checkFileRW.Size = new System.Drawing.Size(143, 20);
            this.checkFileRW.TabIndex = 4;
            this.checkFileRW.Text = "Allow file read/write";
            this.checkFileRW.UseVisualStyleBackColor = true;
            // 
            // checkNetworkAccess
            // 
            this.checkNetworkAccess.AutoSize = true;
            this.checkNetworkAccess.Location = new System.Drawing.Point(283, 106);
            this.checkNetworkAccess.Name = "checkNetworkAccess";
            this.checkNetworkAccess.Size = new System.Drawing.Size(157, 20);
            this.checkNetworkAccess.TabIndex = 5;
            this.checkNetworkAccess.Text = "Allow network access";
            this.checkNetworkAccess.UseVisualStyleBackColor = true;
            // 
            // launchBtn
            // 
            this.launchBtn.Enabled = false;
            this.launchBtn.Location = new System.Drawing.Point(641, 190);
            this.launchBtn.Name = "launchBtn";
            this.launchBtn.Size = new System.Drawing.Size(147, 43);
            this.launchBtn.TabIndex = 6;
            this.launchBtn.Text = "Launch assembly";
            this.launchBtn.UseVisualStyleBackColor = true;
            this.launchBtn.Click += new System.EventHandler(this.launchBtn_Click);
            // 
            // checkGuiPermission
            // 
            this.checkGuiPermission.AutoSize = true;
            this.checkGuiPermission.Location = new System.Drawing.Point(174, 106);
            this.checkGuiPermission.Name = "checkGuiPermission";
            this.checkGuiPermission.Size = new System.Drawing.Size(87, 20);
            this.checkGuiPermission.TabIndex = 7;
            this.checkGuiPermission.Text = "Allow GUI";
            this.checkGuiPermission.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 245);
            this.Controls.Add(this.checkGuiPermission);
            this.Controls.Add(this.launchBtn);
            this.Controls.Add(this.checkNetworkAccess);
            this.Controls.Add(this.checkFileRW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.assemblyPathBox);
            this.Controls.Add(this.chooseAssemblyBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseAssemblyBtn;
        private System.Windows.Forms.TextBox assemblyPathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkFileRW;
        private System.Windows.Forms.CheckBox checkNetworkAccess;
        private System.Windows.Forms.Button launchBtn;
        private System.Windows.Forms.CheckBox checkGuiPermission;
    }
}

