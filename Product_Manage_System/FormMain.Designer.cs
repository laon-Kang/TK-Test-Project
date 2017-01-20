namespace Product_Manage_System
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lbUserName = new System.Windows.Forms.Label();
            this.LMHome = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.LMHistory = new System.Windows.Forms.Button();
            this.LMDisposal = new System.Windows.Forms.Button();
            this.LMNewRegistration = new System.Windows.Forms.Button();
            this.LMReturnSample = new System.Windows.Forms.Button();
            this.LMRentalSample = new System.Windows.Forms.Button();
            this.LMReturn = new System.Windows.Forms.Button();
            this.LMRental = new System.Windows.Forms.Button();
            this.tbAuthorityCode = new System.Windows.Forms.TextBox();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.tbMenuName = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(0)))));
            this.lbUserName.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lbUserName.Location = new System.Drawing.Point(1124, 19);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(43, 16);
            this.lbUserName.TabIndex = 37;
            this.lbUserName.Text = "USER";
            // 
            // LMHome
            // 
            this.LMHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LMHome.BackgroundImage")));
            this.LMHome.FlatAppearance.BorderSize = 0;
            this.LMHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LMHome.Location = new System.Drawing.Point(40, 69);
            this.LMHome.Margin = new System.Windows.Forms.Padding(0);
            this.LMHome.Name = "LMHome";
            this.LMHome.Size = new System.Drawing.Size(22, 19);
            this.LMHome.TabIndex = 36;
            this.LMHome.UseVisualStyleBackColor = true;
            this.LMHome.Click += new System.EventHandler(this.LMHome_Click);
            this.LMHome.MouseLeave += new System.EventHandler(this.LMHome_MouseLeave);
            this.LMHome.MouseHover += new System.EventHandler(this.LMHome_MouseHover);
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseBtn.BackgroundImage")));
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Location = new System.Drawing.Point(1219, 13);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(21, 21);
            this.CloseBtn.TabIndex = 33;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            this.CloseBtn.MouseLeave += new System.EventHandler(this.CloseBtn_MouseLeave);
            this.CloseBtn.MouseHover += new System.EventHandler(this.CloseBtn_MouseHover);
            // 
            // LMHistory
            // 
            this.LMHistory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LMHistory.BackgroundImage")));
            this.LMHistory.FlatAppearance.BorderSize = 0;
            this.LMHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LMHistory.Location = new System.Drawing.Point(39, 293);
            this.LMHistory.Margin = new System.Windows.Forms.Padding(0);
            this.LMHistory.Name = "LMHistory";
            this.LMHistory.Size = new System.Drawing.Size(37, 18);
            this.LMHistory.TabIndex = 35;
            this.LMHistory.UseVisualStyleBackColor = true;
            this.LMHistory.Click += new System.EventHandler(this.LMHistory_Click);
            this.LMHistory.MouseLeave += new System.EventHandler(this.LMHistory_MouseLeave);
            this.LMHistory.MouseHover += new System.EventHandler(this.LMHistory_MouseHover);
            // 
            // LMDisposal
            // 
            this.LMDisposal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LMDisposal.BackgroundImage")));
            this.LMDisposal.FlatAppearance.BorderSize = 0;
            this.LMDisposal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LMDisposal.Location = new System.Drawing.Point(39, 413);
            this.LMDisposal.Margin = new System.Windows.Forms.Padding(0);
            this.LMDisposal.Name = "LMDisposal";
            this.LMDisposal.Size = new System.Drawing.Size(37, 18);
            this.LMDisposal.TabIndex = 34;
            this.LMDisposal.UseVisualStyleBackColor = true;
            this.LMDisposal.Visible = false;
            this.LMDisposal.Click += new System.EventHandler(this.LMDisposal_Click);
            this.LMDisposal.MouseLeave += new System.EventHandler(this.LMDisposal_MouseLeave);
            this.LMDisposal.MouseHover += new System.EventHandler(this.LMDisposal_MouseHover);
            // 
            // LMNewRegistration
            // 
            this.LMNewRegistration.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LMNewRegistration.BackgroundImage")));
            this.LMNewRegistration.FlatAppearance.BorderSize = 0;
            this.LMNewRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LMNewRegistration.Location = new System.Drawing.Point(39, 368);
            this.LMNewRegistration.Margin = new System.Windows.Forms.Padding(0);
            this.LMNewRegistration.Name = "LMNewRegistration";
            this.LMNewRegistration.Size = new System.Drawing.Size(69, 18);
            this.LMNewRegistration.TabIndex = 32;
            this.LMNewRegistration.UseVisualStyleBackColor = true;
            this.LMNewRegistration.Visible = false;
            this.LMNewRegistration.Click += new System.EventHandler(this.LMNewRegistration_Click);
            this.LMNewRegistration.MouseLeave += new System.EventHandler(this.LMNewRegistration_MouseLeave);
            this.LMNewRegistration.MouseHover += new System.EventHandler(this.LMNewRegistration_MouseHover);
            // 
            // LMReturnSample
            // 
            this.LMReturnSample.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LMReturnSample.BackgroundImage")));
            this.LMReturnSample.FlatAppearance.BorderSize = 0;
            this.LMReturnSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LMReturnSample.Location = new System.Drawing.Point(39, 246);
            this.LMReturnSample.Margin = new System.Windows.Forms.Padding(0);
            this.LMReturnSample.Name = "LMReturnSample";
            this.LMReturnSample.Size = new System.Drawing.Size(67, 19);
            this.LMReturnSample.TabIndex = 31;
            this.LMReturnSample.UseVisualStyleBackColor = true;
            this.LMReturnSample.Click += new System.EventHandler(this.LMReturnSample_Click);
            this.LMReturnSample.MouseLeave += new System.EventHandler(this.LMReturnSample_MouseLeave);
            this.LMReturnSample.MouseHover += new System.EventHandler(this.LMReturnSample_MouseHover);
            // 
            // LMRentalSample
            // 
            this.LMRentalSample.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LMRentalSample.BackgroundImage")));
            this.LMRentalSample.FlatAppearance.BorderSize = 0;
            this.LMRentalSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LMRentalSample.Location = new System.Drawing.Point(39, 201);
            this.LMRentalSample.Margin = new System.Windows.Forms.Padding(0);
            this.LMRentalSample.Name = "LMRentalSample";
            this.LMRentalSample.Size = new System.Drawing.Size(67, 19);
            this.LMRentalSample.TabIndex = 30;
            this.LMRentalSample.UseVisualStyleBackColor = true;
            this.LMRentalSample.Click += new System.EventHandler(this.LMRentalSample_Click);
            this.LMRentalSample.MouseLeave += new System.EventHandler(this.LMRentalSample_MouseLeave);
            this.LMRentalSample.MouseHover += new System.EventHandler(this.LMRentalSample_MouseHover);
            // 
            // LMReturn
            // 
            this.LMReturn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LMReturn.BackgroundImage")));
            this.LMReturn.FlatAppearance.BorderSize = 0;
            this.LMReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LMReturn.Location = new System.Drawing.Point(39, 155);
            this.LMReturn.Margin = new System.Windows.Forms.Padding(0);
            this.LMReturn.Name = "LMReturn";
            this.LMReturn.Size = new System.Drawing.Size(37, 18);
            this.LMReturn.TabIndex = 29;
            this.LMReturn.UseVisualStyleBackColor = true;
            this.LMReturn.Click += new System.EventHandler(this.LMReturn_Click);
            this.LMReturn.MouseLeave += new System.EventHandler(this.LMReturn_MouseLeave);
            this.LMReturn.MouseHover += new System.EventHandler(this.LMReturn_MouseHover);
            // 
            // LMRental
            // 
            this.LMRental.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LMRental.BackgroundImage")));
            this.LMRental.FlatAppearance.BorderSize = 0;
            this.LMRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LMRental.Location = new System.Drawing.Point(39, 107);
            this.LMRental.Margin = new System.Windows.Forms.Padding(0);
            this.LMRental.Name = "LMRental";
            this.LMRental.Size = new System.Drawing.Size(34, 20);
            this.LMRental.TabIndex = 28;
            this.LMRental.UseVisualStyleBackColor = true;
            this.LMRental.Click += new System.EventHandler(this.LMRental_Click);
            this.LMRental.MouseLeave += new System.EventHandler(this.LMRental_MouseLeave);
            this.LMRental.MouseHover += new System.EventHandler(this.LMRental_MouseHover);
            // 
            // tbAuthorityCode
            // 
            this.tbAuthorityCode.Location = new System.Drawing.Point(329, 54);
            this.tbAuthorityCode.Name = "tbAuthorityCode";
            this.tbAuthorityCode.Size = new System.Drawing.Size(100, 22);
            this.tbAuthorityCode.TabIndex = 39;
            this.tbAuthorityCode.Visible = false;
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(219, 54);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(100, 22);
            this.tbUserId.TabIndex = 38;
            this.tbUserId.Visible = false;
            // 
            // tbMenuName
            // 
            this.tbMenuName.Location = new System.Drawing.Point(435, 54);
            this.tbMenuName.Name = "tbMenuName";
            this.tbMenuName.Size = new System.Drawing.Size(100, 22);
            this.tbMenuName.TabIndex = 40;
            this.tbMenuName.Visible = false;
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(209, 47);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1041, 620);
            this.mainPanel.TabIndex = 41;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1251, 666);
            this.Controls.Add(this.tbMenuName);
            this.Controls.Add(this.tbAuthorityCode);
            this.Controls.Add(this.tbUserId);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.LMHome);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.LMHistory);
            this.Controls.Add(this.LMDisposal);
            this.Controls.Add(this.LMNewRegistration);
            this.Controls.Add(this.LMReturnSample);
            this.Controls.Add(this.LMRentalSample);
            this.Controls.Add(this.LMReturn);
            this.Controls.Add(this.LMRental);
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Button LMHome;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button LMHistory;
        private System.Windows.Forms.Button LMDisposal;
        private System.Windows.Forms.Button LMNewRegistration;
        private System.Windows.Forms.Button LMReturnSample;
        private System.Windows.Forms.Button LMRentalSample;
        private System.Windows.Forms.Button LMReturn;
        private System.Windows.Forms.Button LMRental;
        public System.Windows.Forms.TextBox tbAuthorityCode;
        public System.Windows.Forms.TextBox tbUserId;
        public System.Windows.Forms.TextBox tbMenuName;
        private System.Windows.Forms.Panel mainPanel;



    }
}