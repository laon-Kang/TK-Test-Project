namespace Product_Manage_System
{
    partial class FormRental
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRental));
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.tbProductCode = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgListInfo = new System.Windows.Forms.DataGridView();
            this.PROPERTY_TYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROPERTY_TYPE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROPERTY_PURPOSE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROPERTY_PURPOSE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPANY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPANY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPETENCY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPETENCY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.제품고유번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDENT_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgListUser = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentalBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.tbInputProductName = new System.Windows.Forms.TextBox();
            this.tbInputNote = new System.Windows.Forms.TextBox();
            this.tbInputProductCode = new System.Windows.Forms.TextBox();
            this.tbInputPropertyPurposeName = new System.Windows.Forms.TextBox();
            this.tbInputPropertyTypeName = new System.Windows.Forms.TextBox();
            this.tbInputCompetencyName = new System.Windows.Forms.TextBox();
            this.tbInputCompanyName = new System.Windows.Forms.TextBox();
            this.tbInputPropertyPurposeCode = new System.Windows.Forms.TextBox();
            this.tbInputPropertyTypeCode = new System.Windows.Forms.TextBox();
            this.tbInputCompetencyCode = new System.Windows.Forms.TextBox();
            this.tbInputCompanyCode = new System.Windows.Forms.TextBox();
            this.tbInputIdentNumber = new System.Windows.Forms.TextBox();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.barcodeSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.stIco = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgListInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgListUser)).BeginInit();
            this.SuspendLayout();
            // 
            // tbProductName
            // 
            this.tbProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbProductName.Location = new System.Drawing.Point(594, 18);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(124, 15);
            this.tbProductName.TabIndex = 0;
            this.tbProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbProductName_KeyDown);
            // 
            // tbProductCode
            // 
            this.tbProductCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbProductCode.Location = new System.Drawing.Point(819, 18);
            this.tbProductCode.Name = "tbProductCode";
            this.tbProductCode.Size = new System.Drawing.Size(124, 15);
            this.tbProductCode.TabIndex = 1;
            this.tbProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbIdentNumber_KeyDown);
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SearchBtn.BackgroundImage")));
            this.SearchBtn.FlatAppearance.BorderSize = 0;
            this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBtn.Location = new System.Drawing.Point(967, 13);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(53, 25);
            this.SearchBtn.TabIndex = 2;
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            this.SearchBtn.MouseLeave += new System.EventHandler(this.SearchBtn_MouseLeave);
            this.SearchBtn.MouseHover += new System.EventHandler(this.SearchBtn_MouseHover);
            // 
            // dgListInfo
            // 
            this.dgListInfo.AllowUserToAddRows = false;
            this.dgListInfo.AllowUserToDeleteRows = false;
            this.dgListInfo.AllowUserToResizeColumns = false;
            this.dgListInfo.AllowUserToResizeRows = false;
            this.dgListInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgListInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgListInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgListInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgListInfo.ColumnHeadersHeight = 26;
            this.dgListInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgListInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PROPERTY_TYPE_NAME,
            this.PROPERTY_TYPE_CODE,
            this.PROPERTY_PURPOSE_NAME,
            this.PROPERTY_PURPOSE_CODE,
            this.COMPANY_NAME,
            this.COMPANY_CODE,
            this.COMPETENCY_NAME,
            this.COMPETENCY_CODE,
            this.제품고유번호,
            this.IDENT_NUMBER,
            this.PRODUCT_NAME});
            this.dgListInfo.EnableHeadersVisualStyles = false;
            this.dgListInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgListInfo.Location = new System.Drawing.Point(22, 79);
            this.dgListInfo.MultiSelect = false;
            this.dgListInfo.Name = "dgListInfo";
            this.dgListInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgListInfo.RowHeadersVisible = false;
            this.dgListInfo.RowTemplate.Height = 23;
            this.dgListInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListInfo.ShowCellToolTips = false;
            this.dgListInfo.ShowEditingIcon = false;
            this.dgListInfo.ShowRowErrors = false;
            this.dgListInfo.Size = new System.Drawing.Size(997, 228);
            this.dgListInfo.TabIndex = 10;
            this.dgListInfo.TabStop = false;
            this.dgListInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgListInfo_CellMouseClick);
            // 
            // PROPERTY_TYPE_NAME
            // 
            this.PROPERTY_TYPE_NAME.DataPropertyName = "자산유형";
            this.PROPERTY_TYPE_NAME.FillWeight = 110F;
            this.PROPERTY_TYPE_NAME.HeaderText = "자산유형";
            this.PROPERTY_TYPE_NAME.Name = "PROPERTY_TYPE_NAME";
            this.PROPERTY_TYPE_NAME.ReadOnly = true;
            this.PROPERTY_TYPE_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PROPERTY_TYPE_CODE
            // 
            this.PROPERTY_TYPE_CODE.DataPropertyName = "자산유형코드";
            this.PROPERTY_TYPE_CODE.HeaderText = "자산유형코드";
            this.PROPERTY_TYPE_CODE.Name = "PROPERTY_TYPE_CODE";
            this.PROPERTY_TYPE_CODE.ReadOnly = true;
            this.PROPERTY_TYPE_CODE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PROPERTY_TYPE_CODE.Visible = false;
            // 
            // PROPERTY_PURPOSE_NAME
            // 
            this.PROPERTY_PURPOSE_NAME.DataPropertyName = "자산목적";
            this.PROPERTY_PURPOSE_NAME.FillWeight = 135F;
            this.PROPERTY_PURPOSE_NAME.HeaderText = "자산목적";
            this.PROPERTY_PURPOSE_NAME.Name = "PROPERTY_PURPOSE_NAME";
            this.PROPERTY_PURPOSE_NAME.ReadOnly = true;
            this.PROPERTY_PURPOSE_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PROPERTY_PURPOSE_CODE
            // 
            this.PROPERTY_PURPOSE_CODE.DataPropertyName = "자산목적코드";
            this.PROPERTY_PURPOSE_CODE.HeaderText = "자산목적코드";
            this.PROPERTY_PURPOSE_CODE.Name = "PROPERTY_PURPOSE_CODE";
            this.PROPERTY_PURPOSE_CODE.ReadOnly = true;
            this.PROPERTY_PURPOSE_CODE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PROPERTY_PURPOSE_CODE.Visible = false;
            // 
            // COMPANY_NAME
            // 
            this.COMPANY_NAME.DataPropertyName = "회사구분";
            this.COMPANY_NAME.FillWeight = 110F;
            this.COMPANY_NAME.HeaderText = "회사구분";
            this.COMPANY_NAME.Name = "COMPANY_NAME";
            this.COMPANY_NAME.ReadOnly = true;
            this.COMPANY_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // COMPANY_CODE
            // 
            this.COMPANY_CODE.DataPropertyName = "회사구분코드";
            this.COMPANY_CODE.HeaderText = "회사구분코드";
            this.COMPANY_CODE.Name = "COMPANY_CODE";
            this.COMPANY_CODE.ReadOnly = true;
            this.COMPANY_CODE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COMPANY_CODE.Visible = false;
            // 
            // COMPETENCY_NAME
            // 
            this.COMPETENCY_NAME.DataPropertyName = "제품군구분";
            this.COMPETENCY_NAME.FillWeight = 160F;
            this.COMPETENCY_NAME.HeaderText = "제품군구분";
            this.COMPETENCY_NAME.Name = "COMPETENCY_NAME";
            this.COMPETENCY_NAME.ReadOnly = true;
            this.COMPETENCY_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // COMPETENCY_CODE
            // 
            this.COMPETENCY_CODE.DataPropertyName = "제품군구분코드";
            this.COMPETENCY_CODE.HeaderText = "제품군구분코드";
            this.COMPETENCY_CODE.Name = "COMPETENCY_CODE";
            this.COMPETENCY_CODE.ReadOnly = true;
            this.COMPETENCY_CODE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COMPETENCY_CODE.Visible = false;
            // 
            // 제품고유번호
            // 
            this.제품고유번호.HeaderText = "고유번호";
            this.제품고유번호.Name = "제품고유번호";
            this.제품고유번호.ReadOnly = true;
            this.제품고유번호.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // IDENT_NUMBER
            // 
            this.IDENT_NUMBER.DataPropertyName = "제품코드";
            this.IDENT_NUMBER.FillWeight = 110F;
            this.IDENT_NUMBER.HeaderText = "제품코드";
            this.IDENT_NUMBER.Name = "IDENT_NUMBER";
            this.IDENT_NUMBER.ReadOnly = true;
            this.IDENT_NUMBER.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "제품명";
            this.PRODUCT_NAME.FillWeight = 160F;
            this.PRODUCT_NAME.HeaderText = "제품명";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgListUser
            // 
            this.dgListUser.AllowUserToAddRows = false;
            this.dgListUser.AllowUserToDeleteRows = false;
            this.dgListUser.AllowUserToResizeColumns = false;
            this.dgListUser.AllowUserToResizeRows = false;
            this.dgListUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgListUser.BackgroundColor = System.Drawing.Color.White;
            this.dgListUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgListUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgListUser.ColumnHeadersHeight = 26;
            this.dgListUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column1,
            this.dataGridViewTextBoxColumn2,
            this.Column2,
            this.dataGridViewTextBoxColumn3,
            this.Column3,
            this.dataGridViewTextBoxColumn4,
            this.Column4,
            this.aa,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.Column5});
            this.dgListUser.EnableHeadersVisualStyles = false;
            this.dgListUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgListUser.Location = new System.Drawing.Point(536, 349);
            this.dgListUser.MultiSelect = false;
            this.dgListUser.Name = "dgListUser";
            this.dgListUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgListUser.RowHeadersVisible = false;
            this.dgListUser.RowTemplate.Height = 23;
            this.dgListUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListUser.ShowCellToolTips = false;
            this.dgListUser.ShowEditingIcon = false;
            this.dgListUser.ShowRowErrors = false;
            this.dgListUser.Size = new System.Drawing.Size(483, 220);
            this.dgListUser.TabIndex = 15;
            this.dgListUser.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "자산유형";
            this.dataGridViewTextBoxColumn1.HeaderText = "자산유형";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "자산유형코드";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "자산목적";
            this.dataGridViewTextBoxColumn2.FillWeight = 125F;
            this.dataGridViewTextBoxColumn2.HeaderText = "자산목적";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "자산목적코드";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "회사구분";
            this.dataGridViewTextBoxColumn3.HeaderText = "회사구분";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "회사구분코드";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "제품군구분";
            this.dataGridViewTextBoxColumn4.FillWeight = 150F;
            this.dataGridViewTextBoxColumn4.HeaderText = "제품군구분";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "제품군구분코드";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.Visible = false;
            // 
            // aa
            // 
            this.aa.HeaderText = "고유번호";
            this.aa.Name = "aa";
            this.aa.ReadOnly = true;
            this.aa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "제품코드";
            this.dataGridViewTextBoxColumn6.HeaderText = "제품코드";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "제품명";
            this.dataGridViewTextBoxColumn5.FillWeight = 150F;
            this.dataGridViewTextBoxColumn5.HeaderText = "제품명";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "대여시간";
            this.dataGridViewTextBoxColumn7.FillWeight = 110F;
            this.dataGridViewTextBoxColumn7.HeaderText = "대여시간";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "NOTE";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // RentalBtn
            // 
            this.RentalBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RentalBtn.BackgroundImage")));
            this.RentalBtn.FlatAppearance.BorderSize = 0;
            this.RentalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RentalBtn.Location = new System.Drawing.Point(967, 579);
            this.RentalBtn.Margin = new System.Windows.Forms.Padding(0);
            this.RentalBtn.Name = "RentalBtn";
            this.RentalBtn.Size = new System.Drawing.Size(53, 25);
            this.RentalBtn.TabIndex = 16;
            this.RentalBtn.UseVisualStyleBackColor = true;
            this.RentalBtn.Click += new System.EventHandler(this.RentalBtn_Click);
            this.RentalBtn.MouseLeave += new System.EventHandler(this.RentalBtn_MouseLeave);
            this.RentalBtn.MouseHover += new System.EventHandler(this.RentalBtn_MouseHover);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelBtn.BackgroundImage")));
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Location = new System.Drawing.Point(909, 579);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(53, 25);
            this.CancelBtn.TabIndex = 17;
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            this.CancelBtn.MouseLeave += new System.EventHandler(this.CancelBtn_MouseLeave);
            this.CancelBtn.MouseHover += new System.EventHandler(this.CancelBtn_MouseHover);
            // 
            // tbInputProductName
            // 
            this.tbInputProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInputProductName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbInputProductName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbInputProductName.Location = new System.Drawing.Point(119, 368);
            this.tbInputProductName.Name = "tbInputProductName";
            this.tbInputProductName.ReadOnly = true;
            this.tbInputProductName.Size = new System.Drawing.Size(124, 15);
            this.tbInputProductName.TabIndex = 20;
            this.tbInputProductName.TabStop = false;
            // 
            // tbInputNote
            // 
            this.tbInputNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInputNote.Location = new System.Drawing.Point(119, 464);
            this.tbInputNote.Multiline = true;
            this.tbInputNote.Name = "tbInputNote";
            this.tbInputNote.Size = new System.Drawing.Size(371, 84);
            this.tbInputNote.TabIndex = 26;
            // 
            // tbInputProductCode
            // 
            this.tbInputProductCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInputProductCode.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbInputProductCode.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbInputProductCode.Location = new System.Drawing.Point(366, 368);
            this.tbInputProductCode.Name = "tbInputProductCode";
            this.tbInputProductCode.ReadOnly = true;
            this.tbInputProductCode.Size = new System.Drawing.Size(124, 15);
            this.tbInputProductCode.TabIndex = 27;
            this.tbInputProductCode.TabStop = false;
            // 
            // tbInputPropertyPurposeName
            // 
            this.tbInputPropertyPurposeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInputPropertyPurposeName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbInputPropertyPurposeName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbInputPropertyPurposeName.Location = new System.Drawing.Point(366, 401);
            this.tbInputPropertyPurposeName.Name = "tbInputPropertyPurposeName";
            this.tbInputPropertyPurposeName.ReadOnly = true;
            this.tbInputPropertyPurposeName.Size = new System.Drawing.Size(124, 15);
            this.tbInputPropertyPurposeName.TabIndex = 29;
            this.tbInputPropertyPurposeName.TabStop = false;
            // 
            // tbInputPropertyTypeName
            // 
            this.tbInputPropertyTypeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInputPropertyTypeName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbInputPropertyTypeName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbInputPropertyTypeName.Location = new System.Drawing.Point(119, 401);
            this.tbInputPropertyTypeName.Name = "tbInputPropertyTypeName";
            this.tbInputPropertyTypeName.ReadOnly = true;
            this.tbInputPropertyTypeName.Size = new System.Drawing.Size(124, 15);
            this.tbInputPropertyTypeName.TabIndex = 28;
            this.tbInputPropertyTypeName.TabStop = false;
            // 
            // tbInputCompetencyName
            // 
            this.tbInputCompetencyName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInputCompetencyName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbInputCompetencyName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbInputCompetencyName.Location = new System.Drawing.Point(366, 432);
            this.tbInputCompetencyName.Name = "tbInputCompetencyName";
            this.tbInputCompetencyName.ReadOnly = true;
            this.tbInputCompetencyName.Size = new System.Drawing.Size(124, 15);
            this.tbInputCompetencyName.TabIndex = 31;
            this.tbInputCompetencyName.TabStop = false;
            // 
            // tbInputCompanyName
            // 
            this.tbInputCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInputCompanyName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbInputCompanyName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbInputCompanyName.Location = new System.Drawing.Point(119, 432);
            this.tbInputCompanyName.Name = "tbInputCompanyName";
            this.tbInputCompanyName.ReadOnly = true;
            this.tbInputCompanyName.Size = new System.Drawing.Size(124, 15);
            this.tbInputCompanyName.TabIndex = 30;
            this.tbInputCompanyName.TabStop = false;
            // 
            // tbInputPropertyPurposeCode
            // 
            this.tbInputPropertyPurposeCode.Location = new System.Drawing.Point(137, 516);
            this.tbInputPropertyPurposeCode.Name = "tbInputPropertyPurposeCode";
            this.tbInputPropertyPurposeCode.Size = new System.Drawing.Size(100, 22);
            this.tbInputPropertyPurposeCode.TabIndex = 33;
            this.tbInputPropertyPurposeCode.Visible = false;
            // 
            // tbInputPropertyTypeCode
            // 
            this.tbInputPropertyTypeCode.Location = new System.Drawing.Point(27, 516);
            this.tbInputPropertyTypeCode.Name = "tbInputPropertyTypeCode";
            this.tbInputPropertyTypeCode.Size = new System.Drawing.Size(100, 22);
            this.tbInputPropertyTypeCode.TabIndex = 32;
            this.tbInputPropertyTypeCode.Visible = false;
            // 
            // tbInputCompetencyCode
            // 
            this.tbInputCompetencyCode.Location = new System.Drawing.Point(353, 516);
            this.tbInputCompetencyCode.Name = "tbInputCompetencyCode";
            this.tbInputCompetencyCode.Size = new System.Drawing.Size(100, 22);
            this.tbInputCompetencyCode.TabIndex = 35;
            this.tbInputCompetencyCode.Visible = false;
            // 
            // tbInputCompanyCode
            // 
            this.tbInputCompanyCode.Location = new System.Drawing.Point(243, 516);
            this.tbInputCompanyCode.Name = "tbInputCompanyCode";
            this.tbInputCompanyCode.Size = new System.Drawing.Size(100, 22);
            this.tbInputCompanyCode.TabIndex = 34;
            this.tbInputCompanyCode.Visible = false;
            // 
            // tbInputIdentNumber
            // 
            this.tbInputIdentNumber.Location = new System.Drawing.Point(459, 516);
            this.tbInputIdentNumber.Name = "tbInputIdentNumber";
            this.tbInputIdentNumber.Size = new System.Drawing.Size(100, 22);
            this.tbInputIdentNumber.TabIndex = 36;
            this.tbInputIdentNumber.Visible = false;
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(27, 11);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(100, 22);
            this.tbUserId.TabIndex = 41;
            this.tbUserId.Visible = false;
            // 
            // tbMessage
            // 
            this.tbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMessage.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbMessage.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbMessage.Location = new System.Drawing.Point(55, 584);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ReadOnly = true;
            this.tbMessage.Size = new System.Drawing.Size(812, 15);
            this.tbMessage.TabIndex = 42;
            this.tbMessage.TabStop = false;
            // 
            // barcodeSerialPort
            // 
            this.barcodeSerialPort.BaudRate = 115200;
            this.barcodeSerialPort.PortName = "COM6";
            this.barcodeSerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.barcodeSerialPort_DataReceived);
            // 
            // stIco
            // 
            this.stIco.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stIco.BackgroundImage")));
            this.stIco.FlatAppearance.BorderSize = 0;
            this.stIco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stIco.Location = new System.Drawing.Point(21, 580);
            this.stIco.Margin = new System.Windows.Forms.Padding(0);
            this.stIco.Name = "stIco";
            this.stIco.Size = new System.Drawing.Size(27, 23);
            this.stIco.TabIndex = 43;
            this.stIco.UseVisualStyleBackColor = true;
            // 
            // FormRental
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1041, 619);
            this.Controls.Add(this.stIco);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.tbUserId);
            this.Controls.Add(this.tbInputIdentNumber);
            this.Controls.Add(this.tbInputCompetencyCode);
            this.Controls.Add(this.tbInputCompanyCode);
            this.Controls.Add(this.tbInputPropertyPurposeCode);
            this.Controls.Add(this.tbInputPropertyTypeCode);
            this.Controls.Add(this.tbInputCompetencyName);
            this.Controls.Add(this.tbInputCompanyName);
            this.Controls.Add(this.tbInputPropertyPurposeName);
            this.Controls.Add(this.tbInputPropertyTypeName);
            this.Controls.Add(this.tbInputProductCode);
            this.Controls.Add(this.tbInputNote);
            this.Controls.Add(this.tbInputProductName);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.RentalBtn);
            this.Controls.Add(this.dgListUser);
            this.Controls.Add(this.dgListInfo);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.tbProductCode);
            this.Controls.Add(this.tbProductName);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRental";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRental_FormClosing);
            this.Load += new System.EventHandler(this.FormRental_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgListInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgListUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.TextBox tbProductCode;
        private System.Windows.Forms.Button SearchBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgListInfo;
        private System.Windows.Forms.DataGridView dgListUser;
        private System.Windows.Forms.Button RentalBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox tbInputProductName;
        private System.Windows.Forms.TextBox tbInputNote;
        private System.Windows.Forms.TextBox tbInputProductCode;
        private System.Windows.Forms.TextBox tbInputPropertyPurposeName;
        private System.Windows.Forms.TextBox tbInputPropertyTypeName;
        private System.Windows.Forms.TextBox tbInputCompetencyName;
        private System.Windows.Forms.TextBox tbInputCompanyName;
        public System.Windows.Forms.TextBox tbInputPropertyPurposeCode;
        public System.Windows.Forms.TextBox tbInputPropertyTypeCode;
        public System.Windows.Forms.TextBox tbInputCompetencyCode;
        public System.Windows.Forms.TextBox tbInputCompanyCode;
        public System.Windows.Forms.TextBox tbInputIdentNumber;
        public System.Windows.Forms.TextBox tbUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn aa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROPERTY_TYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROPERTY_TYPE_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROPERTY_PURPOSE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROPERTY_PURPOSE_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPANY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPANY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPETENCY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPETENCY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제품고유번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDENT_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.TextBox tbMessage;
        private System.IO.Ports.SerialPort barcodeSerialPort;
        private System.Windows.Forms.Button stIco;

    }
}