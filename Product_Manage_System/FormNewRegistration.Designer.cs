namespace Product_Manage_System
{
    partial class FormNewRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewRegistration));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cbCOMPANY = new System.Windows.Forms.ComboBox();
            this.cbCOMPETENCY = new System.Windows.Forms.ComboBox();
            this.cbPROPERTY_PURPOSE = new System.Windows.Forms.ComboBox();
            this.cbPROPERTY_TYPE = new System.Windows.Forms.ComboBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.Hscanner = new System.IO.Ports.SerialPort(this.components);
            this.txtCOMPANY = new System.Windows.Forms.TextBox();
            this.txtCOMPETENCY = new System.Windows.Forms.TextBox();
            this.txtPROPERTY_PURPOSE = new System.Windows.Forms.TextBox();
            this.txtPROPERTY_TYPE = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtIDENT_NUMBER = new System.Windows.Forms.TextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.btnBoxPrint = new System.Windows.Forms.Button();
            this.txtBoxNum = new System.Windows.Forms.TextBox();
            this.cbProductLabelSize = new System.Windows.Forms.ComboBox();
            this.txtBoxCOMPETENCY = new System.Windows.Forms.TextBox();
            this.cbBoxCOMPETENCY = new System.Windows.Forms.ComboBox();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cbCOMPANY
            // 
            this.cbCOMPANY.DropDownWidth = 121;
            this.cbCOMPANY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCOMPANY.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbCOMPANY.FormattingEnabled = true;
            this.cbCOMPANY.IntegralHeight = false;
            this.cbCOMPANY.Location = new System.Drawing.Point(129, 289);
            this.cbCOMPANY.Name = "cbCOMPANY";
            this.cbCOMPANY.Size = new System.Drawing.Size(228, 21);
            this.cbCOMPANY.Sorted = true;
            this.cbCOMPANY.TabIndex = 279;
            this.cbCOMPANY.SelectedIndexChanged += new System.EventHandler(this.cbCOMPANY_SelectedIndexChanged);
            this.cbCOMPANY.SelectedValueChanged += new System.EventHandler(this.cbCOMPANY_SelectedValueChanged);
            // 
            // cbCOMPETENCY
            // 
            this.cbCOMPETENCY.DropDownHeight = 300;
            this.cbCOMPETENCY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCOMPETENCY.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbCOMPETENCY.FormattingEnabled = true;
            this.cbCOMPETENCY.IntegralHeight = false;
            this.cbCOMPETENCY.Location = new System.Drawing.Point(129, 316);
            this.cbCOMPETENCY.Name = "cbCOMPETENCY";
            this.cbCOMPETENCY.Size = new System.Drawing.Size(228, 21);
            this.cbCOMPETENCY.Sorted = true;
            this.cbCOMPETENCY.TabIndex = 281;
            this.cbCOMPETENCY.SelectedIndexChanged += new System.EventHandler(this.cbCOMPETENCY_SelectedIndexChanged);
            this.cbCOMPETENCY.SelectedValueChanged += new System.EventHandler(this.cbCOMPETENCY_SelectedValueChanged);
            // 
            // cbPROPERTY_PURPOSE
            // 
            this.cbPROPERTY_PURPOSE.DropDownHeight = 300;
            this.cbPROPERTY_PURPOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPROPERTY_PURPOSE.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPROPERTY_PURPOSE.FormattingEnabled = true;
            this.cbPROPERTY_PURPOSE.IntegralHeight = false;
            this.cbPROPERTY_PURPOSE.Location = new System.Drawing.Point(129, 345);
            this.cbPROPERTY_PURPOSE.Name = "cbPROPERTY_PURPOSE";
            this.cbPROPERTY_PURPOSE.Size = new System.Drawing.Size(228, 21);
            this.cbPROPERTY_PURPOSE.Sorted = true;
            this.cbPROPERTY_PURPOSE.TabIndex = 284;
            this.cbPROPERTY_PURPOSE.SelectedIndexChanged += new System.EventHandler(this.cbPROPERTY_PURPOSE_SelectedIndexChanged);
            this.cbPROPERTY_PURPOSE.SelectedValueChanged += new System.EventHandler(this.cbPROPERTY_PURPOSE_SelectedValueChanged);
            // 
            // cbPROPERTY_TYPE
            // 
            this.cbPROPERTY_TYPE.DropDownHeight = 300;
            this.cbPROPERTY_TYPE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPROPERTY_TYPE.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPROPERTY_TYPE.FormattingEnabled = true;
            this.cbPROPERTY_TYPE.IntegralHeight = false;
            this.cbPROPERTY_TYPE.Location = new System.Drawing.Point(129, 373);
            this.cbPROPERTY_TYPE.Name = "cbPROPERTY_TYPE";
            this.cbPROPERTY_TYPE.Size = new System.Drawing.Size(228, 21);
            this.cbPROPERTY_TYPE.Sorted = true;
            this.cbPROPERTY_TYPE.TabIndex = 286;
            this.cbPROPERTY_TYPE.SelectedIndexChanged += new System.EventHandler(this.cbPROPERTY_TYPE_SelectedIndexChanged);
            this.cbPROPERTY_TYPE.SelectedValueChanged += new System.EventHandler(this.cbPROPERTY_TYPE_SelectedValueChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBarcode.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBarcode.Location = new System.Drawing.Point(133, 448);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(264, 15);
            this.txtBarcode.TabIndex = 288;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(417, 533);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnAdd.Size = new System.Drawing.Size(83, 24);
            this.btnAdd.TabIndex = 290;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClear.Location = new System.Drawing.Point(967, 579);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(53, 25);
            this.btnClear.TabIndex = 289;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Hscanner
            // 
            this.Hscanner.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Hscanner_DataReceived);
            // 
            // txtCOMPANY
            // 
            this.txtCOMPANY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCOMPANY.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCOMPANY.Location = new System.Drawing.Point(362, 288);
            this.txtCOMPANY.Name = "txtCOMPANY";
            this.txtCOMPANY.ReadOnly = true;
            this.txtCOMPANY.Size = new System.Drawing.Size(40, 22);
            this.txtCOMPANY.TabIndex = 300;
            this.txtCOMPANY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCOMPETENCY
            // 
            this.txtCOMPETENCY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCOMPETENCY.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCOMPETENCY.Location = new System.Drawing.Point(362, 315);
            this.txtCOMPETENCY.Name = "txtCOMPETENCY";
            this.txtCOMPETENCY.ReadOnly = true;
            this.txtCOMPETENCY.Size = new System.Drawing.Size(40, 22);
            this.txtCOMPETENCY.TabIndex = 301;
            this.txtCOMPETENCY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPROPERTY_PURPOSE
            // 
            this.txtPROPERTY_PURPOSE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPROPERTY_PURPOSE.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPROPERTY_PURPOSE.Location = new System.Drawing.Point(362, 344);
            this.txtPROPERTY_PURPOSE.Name = "txtPROPERTY_PURPOSE";
            this.txtPROPERTY_PURPOSE.ReadOnly = true;
            this.txtPROPERTY_PURPOSE.Size = new System.Drawing.Size(40, 22);
            this.txtPROPERTY_PURPOSE.TabIndex = 302;
            this.txtPROPERTY_PURPOSE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPROPERTY_TYPE
            // 
            this.txtPROPERTY_TYPE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPROPERTY_TYPE.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPROPERTY_TYPE.Location = new System.Drawing.Point(362, 372);
            this.txtPROPERTY_TYPE.Name = "txtPROPERTY_TYPE";
            this.txtPROPERTY_TYPE.ReadOnly = true;
            this.txtPROPERTY_TYPE.Size = new System.Drawing.Size(40, 22);
            this.txtPROPERTY_TYPE.TabIndex = 303;
            this.txtPROPERTY_TYPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProductName
            // 
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProductName.Location = new System.Drawing.Point(133, 421);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(264, 15);
            this.txtProductName.TabIndex = 305;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(967, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(53, 25);
            this.btnSearch.TabIndex = 306;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(308, 533);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(104, 24);
            this.btnPrint.TabIndex = 307;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtIDENT_NUMBER
            // 
            this.txtIDENT_NUMBER.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDENT_NUMBER.Enabled = false;
            this.txtIDENT_NUMBER.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtIDENT_NUMBER.Location = new System.Drawing.Point(133, 476);
            this.txtIDENT_NUMBER.Name = "txtIDENT_NUMBER";
            this.txtIDENT_NUMBER.Size = new System.Drawing.Size(264, 15);
            this.txtIDENT_NUMBER.TabIndex = 309;
            // 
            // txtBoxName
            // 
            this.txtBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBoxName.Location = new System.Drawing.Point(635, 292);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(264, 15);
            this.txtBoxName.TabIndex = 311;
            // 
            // btnBoxPrint
            // 
            this.btnBoxPrint.BackColor = System.Drawing.Color.White;
            this.btnBoxPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBoxPrint.BackgroundImage")));
            this.btnBoxPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoxPrint.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBoxPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoxPrint.Location = new System.Drawing.Point(923, 533);
            this.btnBoxPrint.Name = "btnBoxPrint";
            this.btnBoxPrint.Size = new System.Drawing.Size(83, 24);
            this.btnBoxPrint.TabIndex = 312;
            this.btnBoxPrint.UseVisualStyleBackColor = false;
            this.btnBoxPrint.Click += new System.EventHandler(this.btnBoxPrint_Click);
            // 
            // txtBoxNum
            // 
            this.txtBoxNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxNum.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBoxNum.Location = new System.Drawing.Point(635, 320);
            this.txtBoxNum.Name = "txtBoxNum";
            this.txtBoxNum.Size = new System.Drawing.Size(264, 15);
            this.txtBoxNum.TabIndex = 314;
            this.txtBoxNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxNum_KeyDown);
            // 
            // cbProductLabelSize
            // 
            this.cbProductLabelSize.DropDownHeight = 300;
            this.cbProductLabelSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbProductLabelSize.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbProductLabelSize.FormattingEnabled = true;
            this.cbProductLabelSize.IntegralHeight = false;
            this.cbProductLabelSize.Location = new System.Drawing.Point(631, 373);
            this.cbProductLabelSize.Name = "cbProductLabelSize";
            this.cbProductLabelSize.Size = new System.Drawing.Size(77, 21);
            this.cbProductLabelSize.Sorted = true;
            this.cbProductLabelSize.TabIndex = 316;
            // 
            // txtBoxCOMPETENCY
            // 
            this.txtBoxCOMPETENCY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxCOMPETENCY.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBoxCOMPETENCY.Location = new System.Drawing.Point(863, 344);
            this.txtBoxCOMPETENCY.Name = "txtBoxCOMPETENCY";
            this.txtBoxCOMPETENCY.ReadOnly = true;
            this.txtBoxCOMPETENCY.Size = new System.Drawing.Size(40, 22);
            this.txtBoxCOMPETENCY.TabIndex = 319;
            this.txtBoxCOMPETENCY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbBoxCOMPETENCY
            // 
            this.cbBoxCOMPETENCY.DropDownHeight = 300;
            this.cbBoxCOMPETENCY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBoxCOMPETENCY.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbBoxCOMPETENCY.FormattingEnabled = true;
            this.cbBoxCOMPETENCY.IntegralHeight = false;
            this.cbBoxCOMPETENCY.Location = new System.Drawing.Point(631, 345);
            this.cbBoxCOMPETENCY.Name = "cbBoxCOMPETENCY";
            this.cbBoxCOMPETENCY.Size = new System.Drawing.Size(227, 21);
            this.cbBoxCOMPETENCY.Sorted = true;
            this.cbBoxCOMPETENCY.TabIndex = 317;
            this.cbBoxCOMPETENCY.SelectedIndexChanged += new System.EventHandler(this.cbBoxCOMPETENCY_SelectedIndexChanged);
            this.cbBoxCOMPETENCY.SelectedValueChanged += new System.EventHandler(this.cbBoxCOMPETENCY_SelectedValueChanged);
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(22, 13);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(100, 22);
            this.tbUserId.TabIndex = 320;
            this.tbUserId.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(814, 533);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 24);
            this.button1.TabIndex = 321;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AllowUserToResizeColumns = false;
            this.dgList.AllowUserToResizeRows = false;
            this.dgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgList.BackgroundColor = System.Drawing.Color.White;
            this.dgList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgList.ColumnHeadersHeight = 26;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.aa,
            this.Column1,
            this.dataGridViewTextBoxColumn9});
            this.dgList.EnableHeadersVisualStyles = false;
            this.dgList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgList.Location = new System.Drawing.Point(22, 79);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgList.RowHeadersVisible = false;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgList.ShowCellToolTips = false;
            this.dgList.ShowEditingIcon = false;
            this.dgList.ShowRowErrors = false;
            this.dgList.Size = new System.Drawing.Size(997, 144);
            this.dgList.TabIndex = 322;
            this.dgList.TabStop = false;
            this.dgList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "제품명";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "제품코드";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "자산목적";
            this.dataGridViewTextBoxColumn3.FillWeight = 125F;
            this.dataGridViewTextBoxColumn3.HeaderText = "회사구분";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "제품군구분";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "회사구분";
            this.dataGridViewTextBoxColumn5.HeaderText = "자산목적";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "자산유형";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "제품군구분";
            this.dataGridViewTextBoxColumn7.HeaderText = "고유번호";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "박스명";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // aa
            // 
            this.aa.FillWeight = 120F;
            this.aa.HeaderText = "박스코드";
            this.aa.Name = "aa";
            this.aa.ReadOnly = true;
            this.aa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "박스제품군코드";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "제품코드";
            this.dataGridViewTextBoxColumn9.FillWeight = 120F;
            this.dataGridViewTextBoxColumn9.HeaderText = "박스제품군";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // FormNewRegistration
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1041, 619);
            this.Controls.Add(this.dgList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbUserId);
            this.Controls.Add(this.txtBoxCOMPETENCY);
            this.Controls.Add(this.cbBoxCOMPETENCY);
            this.Controls.Add(this.cbProductLabelSize);
            this.Controls.Add(this.txtBoxNum);
            this.Controls.Add(this.btnBoxPrint);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.txtIDENT_NUMBER);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtPROPERTY_TYPE);
            this.Controls.Add(this.txtPROPERTY_PURPOSE);
            this.Controls.Add(this.txtCOMPETENCY);
            this.Controls.Add(this.txtCOMPANY);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.cbPROPERTY_TYPE);
            this.Controls.Add(this.cbPROPERTY_PURPOSE);
            this.Controls.Add(this.cbCOMPETENCY);
            this.Controls.Add(this.cbCOMPANY);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNewRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormpRoductAdd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormpRoductAdd_FormClosing);
            this.Load += new System.EventHandler(this.FormpRoductAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cbCOMPANY;
        private System.Windows.Forms.ComboBox cbCOMPETENCY;
        private System.Windows.Forms.ComboBox cbPROPERTY_PURPOSE;
        private System.Windows.Forms.ComboBox cbPROPERTY_TYPE;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.IO.Ports.SerialPort Hscanner;
        private System.Windows.Forms.TextBox txtCOMPANY;
        private System.Windows.Forms.TextBox txtCOMPETENCY;
        private System.Windows.Forms.TextBox txtPROPERTY_PURPOSE;
        private System.Windows.Forms.TextBox txtPROPERTY_TYPE;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtIDENT_NUMBER;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Button btnBoxPrint;
        private System.Windows.Forms.TextBox txtBoxNum;
        private System.Windows.Forms.ComboBox cbProductLabelSize;
        private System.Windows.Forms.TextBox txtBoxCOMPETENCY;
        private System.Windows.Forms.ComboBox cbBoxCOMPETENCY;
        public System.Windows.Forms.TextBox tbUserId;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn aa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}