namespace _15_AsyncAwait_1
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
            this.components = new System.ComponentModel.Container();
            this.connectDbBtn = new System.Windows.Forms.Button();
            this.disconnectDbBtn = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectDbBtn
            // 
            this.connectDbBtn.Location = new System.Drawing.Point(103, 106);
            this.connectDbBtn.Name = "connectDbBtn";
            this.connectDbBtn.Size = new System.Drawing.Size(179, 64);
            this.connectDbBtn.TabIndex = 0;
            this.connectDbBtn.Text = "Connect to DB";
            this.connectDbBtn.UseVisualStyleBackColor = true;
            this.connectDbBtn.Click += new System.EventHandler(this.ConnectDbBtn_Click);
            // 
            // disconnectDbBtn
            // 
            this.disconnectDbBtn.Enabled = false;
            this.disconnectDbBtn.Location = new System.Drawing.Point(305, 106);
            this.disconnectDbBtn.Name = "disconnectDbBtn";
            this.disconnectDbBtn.Size = new System.Drawing.Size(179, 64);
            this.disconnectDbBtn.TabIndex = 1;
            this.disconnectDbBtn.Text = "Disconnect from DB";
            this.disconnectDbBtn.UseVisualStyleBackColor = true;
            this.disconnectDbBtn.Click += new System.EventHandler(this.DisconnectDbBtn_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 265);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(589, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(0, 18);
            // 
            // timer
            // 
            this.timer.Interval = 2000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 287);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.disconnectDbBtn);
            this.Controls.Add(this.connectDbBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectDbBtn;
        private System.Windows.Forms.Button disconnectDbBtn;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
    }
}

