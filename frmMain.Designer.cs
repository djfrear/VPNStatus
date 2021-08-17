namespace VPNStatus
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.lblIsConnected = new System.Windows.Forms.Label();
            this.vpnCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.cmdClose = new System.Windows.Forms.Button();
            this.VPNCheckIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connected:";
            // 
            // lblIsConnected
            // 
            this.lblIsConnected.AutoSize = true;
            this.lblIsConnected.Location = new System.Drawing.Point(80, 9);
            this.lblIsConnected.Name = "lblIsConnected";
            this.lblIsConnected.Size = new System.Drawing.Size(21, 13);
            this.lblIsConnected.TabIndex = 1;
            this.lblIsConnected.Text = "No";
            // 
            // vpnCheckTimer
            // 
            this.vpnCheckTimer.Enabled = true;
            this.vpnCheckTimer.Interval = 15000;
            this.vpnCheckTimer.Tick += new System.EventHandler(this.vpnCheckTimer_Tick);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(139, 5);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "&Quit";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // VPNCheckIcon
            // 
            this.VPNCheckIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.VPNCheckIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("VPNCheckIcon.Icon")));
            this.VPNCheckIcon.Text = "VPNCheck";
            this.VPNCheckIcon.Visible = true;
            this.VPNCheckIcon.DoubleClick += new System.EventHandler(this.VPNCheckIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsConnect});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 26);
            // 
            // tsConnect
            // 
            this.tsConnect.Name = "tsConnect";
            this.tsConnect.Size = new System.Drawing.Size(119, 22);
            this.tsConnect.Text = "Connect";
            this.tsConnect.Click += new System.EventHandler(this.tsConnect_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 34);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lblIsConnected);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VPNCheck - Disconnected";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIsConnected;
        private System.Windows.Forms.Timer vpnCheckTimer;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.NotifyIcon VPNCheckIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsConnect;
    }
}

