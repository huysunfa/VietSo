namespace PrintSo
{
	// Token: 0x02000012 RID: 18
	public partial class FrmPreview : global::System.Windows.Forms.Form
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x00010240 File Offset: 0x0000E440
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00010260 File Offset: 0x0000E460
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.ctextMenuS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddCol = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemDelRow = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemDelCol = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemDelCel = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemThemChuSauTinChu = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddMua = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddYear = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddDay = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddNoiC = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddAdress = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddGiaChu = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddTinChu = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddHuongLinh = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddHLinhSinh = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddHLinhMat = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddHLinhTho = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddNgachSo = new System.Windows.Forms.ToolStripMenuItem();
            this.ckxMaSo = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlSBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlSBtnPrintAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tlSBtnUndo = new System.Windows.Forms.ToolStripButton();
            this.tlSBtnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tlSBtnLoaiSo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlSLblKieuChuCN = new System.Windows.Forms.ToolStripLabel();
            this.tlSCbxFontCN = new System.Windows.Forms.ToolStripComboBox();
            this.tlSCbxFontCNSize = new System.Windows.Forms.ToolStripComboBox();
            this.tlSCbxFontCNStyle = new System.Windows.Forms.ToolStripComboBox();
            this.tlSLblKieuChuVN = new System.Windows.Forms.ToolStripLabel();
            this.tlSCbxFontVN = new System.Windows.Forms.ToolStripComboBox();
            this.tlSCbxFontVNSize = new System.Windows.Forms.ToolStripComboBox();
            this.tlSCbxFontVNStyle = new System.Windows.Forms.ToolStripComboBox();
            this.tlSBtnInputKey = new System.Windows.Forms.ToolStripButton();
            this.splitCntMain = new System.Windows.Forms.SplitContainer();
            this.btnDanhSach = new System.Windows.Forms.Button();
            this.cbxVNLeft = new System.Windows.Forms.CheckBox();
            this.btnTinChu = new System.Windows.Forms.Button();
            this.btnNgachSo = new System.Windows.Forms.Button();
            this.pnlAlign = new System.Windows.Forms.Panel();
            this.rbtnRight = new System.Windows.Forms.RadioButton();
            this.rbtnLeft = new System.Windows.Forms.RadioButton();
            this.rbtnBottom = new System.Windows.Forms.RadioButton();
            this.rbtnTop = new System.Windows.Forms.RadioButton();
            this.cbxSongNgu = new System.Windows.Forms.CheckBox();
            this.btnSetupPaper = new System.Windows.Forms.Button();
            this.btnDeleteLongSo = new System.Windows.Forms.Button();
            this.btnSaveNewLongSo = new System.Windows.Forms.Button();
            this.cbxChuViet = new System.Windows.Forms.CheckBox();
            this.cbxChuTrung = new System.Windows.Forms.CheckBox();
            this.txt_Focus = new System.Windows.Forms.TextBox();
            this.cbxSuggest = new System.Windows.Forms.ComboBox();
            this.pnlDicSuggest = new System.Windows.Forms.FlowLayoutPanel();
            this.pBx = new System.Windows.Forms.PictureBox();
            this.timerNotifyUpdate = new System.Windows.Forms.Timer(this.components);
            this.ctextMenuS.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCntMain)).BeginInit();
            this.splitCntMain.Panel1.SuspendLayout();
            this.splitCntMain.SuspendLayout();
            this.pnlAlign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBx)).BeginInit();
            this.SuspendLayout();
            // 
            // ctextMenuS
            // 
            this.ctextMenuS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctextMenuS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMItemPaste,
            this.TSMItemAddRow,
            this.TSMItemAddCol,
            this.TSMItemDelRow,
            this.TSMItemDelCol,
            this.TSMItemDelCel,
            this.TSMItemThemChuSauTinChu,
            this.TSMItemAddMua,
            this.TSMItemAddYear,
            this.TSMItemAddMonth,
            this.TSMItemAddDay,
            this.TSMItemAddNoiC,
            this.TSMItemAddAdress,
            this.TSMItemAddGiaChu,
            this.TSMItemAddTinChu,
            this.TSMItemAddHuongLinh,
            this.TSMItemAddHLinhSinh,
            this.TSMItemAddHLinhMat,
            this.TSMItemAddHLinhTho,
            this.TSMItemAddNgachSo});
            this.ctextMenuS.Name = "ctextMenuS";
            this.ctextMenuS.Size = new System.Drawing.Size(305, 484);
            // 
            // TSMItemPaste
            // 
            this.TSMItemPaste.Name = "TSMItemPaste";
            this.TSMItemPaste.Size = new System.Drawing.Size(304, 24);
            this.TSMItemPaste.Text = "Dán";
            this.TSMItemPaste.Click += new System.EventHandler(this.TSMItemPaste_Click);
            // 
            // TSMItemAddRow
            // 
            this.TSMItemAddRow.Name = "TSMItemAddRow";
            this.TSMItemAddRow.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddRow.Text = "Thêm dòng";
            this.TSMItemAddRow.Click += new System.EventHandler(this.TSMItemAddRow_Click);
            // 
            // TSMItemAddCol
            // 
            this.TSMItemAddCol.Name = "TSMItemAddCol";
            this.TSMItemAddCol.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddCol.Text = "Thêm cột";
            this.TSMItemAddCol.Click += new System.EventHandler(this.TSMItemAddCol_Click);
            // 
            // TSMItemDelRow
            // 
            this.TSMItemDelRow.Name = "TSMItemDelRow";
            this.TSMItemDelRow.Size = new System.Drawing.Size(304, 24);
            this.TSMItemDelRow.Text = "Xóa dòng";
            this.TSMItemDelRow.Click += new System.EventHandler(this.TSMItemDelRow_Click);
            // 
            // TSMItemDelCol
            // 
            this.TSMItemDelCol.Name = "TSMItemDelCol";
            this.TSMItemDelCol.Size = new System.Drawing.Size(304, 24);
            this.TSMItemDelCol.Text = "Xóa cột";
            this.TSMItemDelCol.Click += new System.EventHandler(this.TSMItemDelCol_Click);
            // 
            // TSMItemDelCel
            // 
            this.TSMItemDelCel.Name = "TSMItemDelCel";
            this.TSMItemDelCel.Size = new System.Drawing.Size(304, 24);
            this.TSMItemDelCel.Text = "Xóa ô";
            this.TSMItemDelCel.Click += new System.EventHandler(this.TSMItemDelCel_Click);
            // 
            // TSMItemThemChuSauTinChu
            // 
            this.TSMItemThemChuSauTinChu.Name = "TSMItemThemChuSauTinChu";
            this.TSMItemThemChuSauTinChu.Size = new System.Drawing.Size(304, 24);
            this.TSMItemThemChuSauTinChu.Text = "Khuôn mẫu Tín chủ";
            this.TSMItemThemChuSauTinChu.Click += new System.EventHandler(this.TSMItemThemChuSauTinChu_Click);
            // 
            // TSMItemAddMua
            // 
            this.TSMItemAddMua.Name = "TSMItemAddMua";
            this.TSMItemAddMua.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddMua.Text = "Thêm mùa (@mua)";
            this.TSMItemAddMua.Click += new System.EventHandler(this.TSMItemAddMua_Click);
            // 
            // TSMItemAddYear
            // 
            this.TSMItemAddYear.Name = "TSMItemAddYear";
            this.TSMItemAddYear.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddYear.Text = "Thêm năm (@nam)";
            this.TSMItemAddYear.Click += new System.EventHandler(this.TSMItemAddYear_Click);
            // 
            // TSMItemAddMonth
            // 
            this.TSMItemAddMonth.Name = "TSMItemAddMonth";
            this.TSMItemAddMonth.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddMonth.Text = "Thêm tháng (@thang)";
            this.TSMItemAddMonth.Click += new System.EventHandler(this.TSMItemAddMonth_Click);
            // 
            // TSMItemAddDay
            // 
            this.TSMItemAddDay.Name = "TSMItemAddDay";
            this.TSMItemAddDay.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddDay.Text = "Thêm ngày (@ngay)";
            this.TSMItemAddDay.Click += new System.EventHandler(this.TSMItemAddDay_Click);
            // 
            // TSMItemAddNoiC
            // 
            this.TSMItemAddNoiC.Name = "TSMItemAddNoiC";
            this.TSMItemAddNoiC.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddNoiC.Text = "Thêm nơi cúng(@noicung)";
            this.TSMItemAddNoiC.Click += new System.EventHandler(this.TSMItemAddNoiC_Click);
            // 
            // TSMItemAddAdress
            // 
            this.TSMItemAddAdress.Name = "TSMItemAddAdress";
            this.TSMItemAddAdress.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddAdress.Text = "Thêm địa chỉ (@diachiyvu)";
            this.TSMItemAddAdress.Click += new System.EventHandler(this.TSMItemAddAdress_Click);
            // 
            // TSMItemAddGiaChu
            // 
            this.TSMItemAddGiaChu.Name = "TSMItemAddGiaChu";
            this.TSMItemAddGiaChu.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddGiaChu.Text = "Thêm gia chủ ($giachu)";
            this.TSMItemAddGiaChu.Click += new System.EventHandler(this.TSMItemAddGiaChu_Click);
            // 
            // TSMItemAddTinChu
            // 
            this.TSMItemAddTinChu.Name = "TSMItemAddTinChu";
            this.TSMItemAddTinChu.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddTinChu.Text = "Thêm tín chủ ($tinchu)";
            this.TSMItemAddTinChu.Click += new System.EventHandler(this.TSMItemAddTinChu_Click);
            // 
            // TSMItemAddHuongLinh
            // 
            this.TSMItemAddHuongLinh.Name = "TSMItemAddHuongLinh";
            this.TSMItemAddHuongLinh.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddHuongLinh.Text = "Thêm Tên Hương linh ($hlinhten)";
            this.TSMItemAddHuongLinh.Click += new System.EventHandler(this.TSMItemAddHuongLinh_Click);
            // 
            // TSMItemAddHLinhSinh
            // 
            this.TSMItemAddHLinhSinh.Name = "TSMItemAddHLinhSinh";
            this.TSMItemAddHLinhSinh.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddHLinhSinh.Text = "Hương linh Năm sinh ($hlinhsinh)";
            this.TSMItemAddHLinhSinh.Click += new System.EventHandler(this.TSMItemAddHLinhSinh_Click);
            // 
            // TSMItemAddHLinhMat
            // 
            this.TSMItemAddHLinhMat.Name = "TSMItemAddHLinhMat";
            this.TSMItemAddHLinhMat.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddHLinhMat.Text = "Hương linh Năm mất ($hlinhmat)";
            this.TSMItemAddHLinhMat.Click += new System.EventHandler(this.TSMItemAddHLinhMat_Click);
            // 
            // TSMItemAddHLinhTho
            // 
            this.TSMItemAddHLinhTho.Name = "TSMItemAddHLinhTho";
            this.TSMItemAddHLinhTho.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddHLinhTho.Text = "Hương linh Hưởng thọ ($hlinhtho)";
            this.TSMItemAddHLinhTho.Click += new System.EventHandler(this.TSMItemAddHLinhTho_Click);
            // 
            // TSMItemAddNgachSo
            // 
            this.TSMItemAddNgachSo.Name = "TSMItemAddNgachSo";
            this.TSMItemAddNgachSo.Size = new System.Drawing.Size(304, 24);
            this.TSMItemAddNgachSo.Text = "Thêm ngạch sớ ($ngachso)";
            this.TSMItemAddNgachSo.Click += new System.EventHandler(this.TSMItemAddNgachSo_Click);
            // 
            // ckxMaSo
            // 
            this.ckxMaSo.AutoSize = true;
            this.ckxMaSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckxMaSo.Location = new System.Drawing.Point(13, 15);
            this.ckxMaSo.Margin = new System.Windows.Forms.Padding(4);
            this.ckxMaSo.Name = "ckxMaSo";
            this.ckxMaSo.Size = new System.Drawing.Size(121, 24);
            this.ckxMaSo.TabIndex = 9;
            this.ckxMaSo.Text = "Có in Mã sớ";
            this.ckxMaSo.UseVisualStyleBackColor = true;
            this.ckxMaSo.CheckedChanged += new System.EventHandler(this.ckxMaSo_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblInfo.Location = new System.Drawing.Point(0, 725);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(777, 25);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "backgroud status backgroud status backgroud status backgroud status backgroud sta" +
    "tus";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlSBtnPrint,
            this.toolStripSeparator2,
            this.tlSBtnPrintAll,
            this.toolStripSeparator6,
            this.tlSBtnUndo,
            this.tlSBtnRedo,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.tlSBtnLoaiSo,
            this.toolStripSeparator5,
            this.tlSLblKieuChuCN,
            this.tlSCbxFontCN,
            this.tlSCbxFontCNSize,
            this.tlSCbxFontCNStyle,
            this.tlSLblKieuChuVN,
            this.tlSCbxFontVN,
            this.tlSCbxFontVNSize,
            this.tlSCbxFontVNStyle,
            this.tlSBtnInputKey});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(1, 7, 1, 10);
            this.toolStrip1.Size = new System.Drawing.Size(1371, 46);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlSBtnPrint
            // 
            this.tlSBtnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlSBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlSBtnPrint.Name = "tlSBtnPrint";
            this.tlSBtnPrint.Size = new System.Drawing.Size(52, 26);
            this.tlSBtnPrint.Text = "In sớ";
            this.tlSBtnPrint.Click += new System.EventHandler(this.tlSBtnPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // tlSBtnPrintAll
            // 
            this.tlSBtnPrintAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlSBtnPrintAll.Name = "tlSBtnPrintAll";
            this.tlSBtnPrintAll.Size = new System.Drawing.Size(134, 26);
            this.tlSBtnPrintAll.Text = "In nhiều gia đình";
            this.tlSBtnPrintAll.Click += new System.EventHandler(this.tlSBtnPrintAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // tlSBtnUndo
            // 
            this.tlSBtnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlSBtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlSBtnUndo.Name = "tlSBtnUndo";
            this.tlSBtnUndo.Size = new System.Drawing.Size(29, 26);
            this.tlSBtnUndo.ToolTipText = "Undo";
            this.tlSBtnUndo.Click += new System.EventHandler(this.tlSBtnUndo_Click);
            // 
            // tlSBtnRedo
            // 
            this.tlSBtnRedo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlSBtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlSBtnRedo.Name = "tlSBtnRedo";
            this.tlSBtnRedo.Size = new System.Drawing.Size(29, 26);
            this.tlSBtnRedo.ToolTipText = "Redo";
            this.tlSBtnRedo.Click += new System.EventHandler(this.tlSBtnRedo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(64, 26);
            this.toolStripLabel1.Text = "Loại sớ";
            // 
            // tlSBtnLoaiSo
            // 
            this.tlSBtnLoaiSo.BackColor = System.Drawing.Color.Yellow;
            this.tlSBtnLoaiSo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlSBtnLoaiSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlSBtnLoaiSo.ForeColor = System.Drawing.Color.Black;
            this.tlSBtnLoaiSo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlSBtnLoaiSo.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tlSBtnLoaiSo.Name = "tlSBtnLoaiSo";
            this.tlSBtnLoaiSo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tlSBtnLoaiSo.Size = new System.Drawing.Size(199, 26);
            this.tlSBtnLoaiSo.Text = "Click để chọn loại sớ";
            this.tlSBtnLoaiSo.ToolTipText = "Click để chọn loại sớ";
            this.tlSBtnLoaiSo.Click += new System.EventHandler(this.tlSBtnLoaiSo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // tlSLblKieuChuCN
            // 
            this.tlSLblKieuChuCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlSLblKieuChuCN.Name = "tlSLblKieuChuCN";
            this.tlSLblKieuChuCN.Size = new System.Drawing.Size(106, 26);
            this.tlSLblKieuChuCN.Text = "Kiểu chữ nho";
            // 
            // tlSCbxFontCN
            // 
            this.tlSCbxFontCN.AutoSize = false;
            this.tlSCbxFontCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlSCbxFontCN.DropDownWidth = 120;
            this.tlSCbxFontCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlSCbxFontCN.Name = "tlSCbxFontCN";
            this.tlSCbxFontCN.Size = new System.Drawing.Size(125, 28);
            this.tlSCbxFontCN.SelectedIndexChanged += new System.EventHandler(this.tlSCbxFontCN_SelectedIndexChanged);
            // 
            // tlSCbxFontCNSize
            // 
            this.tlSCbxFontCNSize.AutoSize = false;
            this.tlSCbxFontCNSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlSCbxFontCNSize.DropDownWidth = 50;
            this.tlSCbxFontCNSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tlSCbxFontCNSize.Name = "tlSCbxFontCNSize";
            this.tlSCbxFontCNSize.Size = new System.Drawing.Size(67, 28);
            this.tlSCbxFontCNSize.SelectedIndexChanged += new System.EventHandler(this.tlSCbxFontCNSize_SelectedIndexChanged);
            // 
            // tlSCbxFontCNStyle
            // 
            this.tlSCbxFontCNStyle.AutoSize = false;
            this.tlSCbxFontCNStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlSCbxFontCNStyle.DropDownWidth = 50;
            this.tlSCbxFontCNStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tlSCbxFontCNStyle.Name = "tlSCbxFontCNStyle";
            this.tlSCbxFontCNStyle.Size = new System.Drawing.Size(92, 28);
            this.tlSCbxFontCNStyle.SelectedIndexChanged += new System.EventHandler(this.tlSCbxFontCNStyle_SelectedIndexChanged);
            // 
            // tlSLblKieuChuVN
            // 
            this.tlSLblKieuChuVN.Name = "tlSLblKieuChuVN";
            this.tlSLblKieuChuVN.Size = new System.Drawing.Size(104, 26);
            this.tlSLblKieuChuVN.Text = "Kiểu chữ QN";
            this.tlSLblKieuChuVN.ToolTipText = "Kiểu chữ quốc ngữ";
            // 
            // tlSCbxFontVN
            // 
            this.tlSCbxFontVN.AutoSize = false;
            this.tlSCbxFontVN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlSCbxFontVN.DropDownWidth = 120;
            this.tlSCbxFontVN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlSCbxFontVN.Name = "tlSCbxFontVN";
            this.tlSCbxFontVN.Size = new System.Drawing.Size(39, 28);
            this.tlSCbxFontVN.SelectedIndexChanged += new System.EventHandler(this.tlSCbxFontVN_SelectedIndexChanged);
            // 
            // tlSCbxFontVNSize
            // 
            this.tlSCbxFontVNSize.AutoSize = false;
            this.tlSCbxFontVNSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlSCbxFontVNSize.DropDownWidth = 50;
            this.tlSCbxFontVNSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tlSCbxFontVNSize.Name = "tlSCbxFontVNSize";
            this.tlSCbxFontVNSize.Size = new System.Drawing.Size(39, 28);
            this.tlSCbxFontVNSize.SelectedIndexChanged += new System.EventHandler(this.tlSCbxFontVNSize_SelectedIndexChanged);
            // 
            // tlSCbxFontVNStyle
            // 
            this.tlSCbxFontVNStyle.AutoSize = false;
            this.tlSCbxFontVNStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlSCbxFontVNStyle.DropDownWidth = 50;
            this.tlSCbxFontVNStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tlSCbxFontVNStyle.Name = "tlSCbxFontVNStyle";
            this.tlSCbxFontVNStyle.Size = new System.Drawing.Size(39, 28);
            this.tlSCbxFontVNStyle.SelectedIndexChanged += new System.EventHandler(this.tlSCbxFontVNStyle_SelectedIndexChanged);
            // 
            // tlSBtnInputKey
            // 
            this.tlSBtnInputKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tlSBtnInputKey.ForeColor = System.Drawing.Color.Red;
            this.tlSBtnInputKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlSBtnInputKey.Name = "tlSBtnInputKey";
            this.tlSBtnInputKey.Size = new System.Drawing.Size(168, 26);
            this.tlSBtnInputKey.Text = "Nhập mã Bản Quyên";
            this.tlSBtnInputKey.Click += new System.EventHandler(this.tlSBtnInputKey_Click);
            // 
            // splitCntMain
            // 
            this.splitCntMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCntMain.Location = new System.Drawing.Point(0, 46);
            this.splitCntMain.Margin = new System.Windows.Forms.Padding(4);
            this.splitCntMain.Name = "splitCntMain";
            // 
            // splitCntMain.Panel1
            // 
            this.splitCntMain.Panel1.Controls.Add(this.btnDanhSach);
            this.splitCntMain.Panel1.Controls.Add(this.cbxVNLeft);
            this.splitCntMain.Panel1.Controls.Add(this.btnTinChu);
            this.splitCntMain.Panel1.Controls.Add(this.btnNgachSo);
            this.splitCntMain.Panel1.Controls.Add(this.pnlAlign);
            this.splitCntMain.Panel1.Controls.Add(this.cbxSongNgu);
            this.splitCntMain.Panel1.Controls.Add(this.btnSetupPaper);
            this.splitCntMain.Panel1.Controls.Add(this.btnDeleteLongSo);
            this.splitCntMain.Panel1.Controls.Add(this.btnSaveNewLongSo);
            this.splitCntMain.Panel1.Controls.Add(this.cbxChuViet);
            this.splitCntMain.Panel1.Controls.Add(this.cbxChuTrung);
            this.splitCntMain.Panel1.Controls.Add(this.ckxMaSo);
            // 
            // splitCntMain.Panel2
            // 
            this.splitCntMain.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitCntMain.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitCntMain_Panel2_Paint);
            this.splitCntMain.Size = new System.Drawing.Size(1371, 704);
            this.splitCntMain.SplitterDistance = 180;
            this.splitCntMain.SplitterWidth = 5;
            this.splitCntMain.TabIndex = 3;
            // 
            // btnDanhSach
            // 
            this.btnDanhSach.AutoSize = true;
            this.btnDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhSach.Location = new System.Drawing.Point(4, 304);
            this.btnDanhSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDanhSach.Name = "btnDanhSach";
            this.btnDanhSach.Size = new System.Drawing.Size(200, 43);
            this.btnDanhSach.TabIndex = 29;
            this.btnDanhSach.Text = "Danh sách đoàn";
            this.btnDanhSach.UseVisualStyleBackColor = true;
            this.btnDanhSach.Click += new System.EventHandler(this.btnDanhSach_Click);
            // 
            // cbxVNLeft
            // 
            this.cbxVNLeft.AutoSize = true;
            this.cbxVNLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVNLeft.Location = new System.Drawing.Point(28, 351);
            this.cbxVNLeft.Margin = new System.Windows.Forms.Padding(4);
            this.cbxVNLeft.Name = "cbxVNLeft";
            this.cbxVNLeft.Size = new System.Drawing.Size(163, 24);
            this.cbxVNLeft.TabIndex = 28;
            this.cbxVNLeft.Text = "Căn chữ sang trái";
            this.cbxVNLeft.UseVisualStyleBackColor = true;
            this.cbxVNLeft.Visible = false;
            this.cbxVNLeft.CheckedChanged += new System.EventHandler(this.cbxVNLeft_CheckedChanged);
            // 
            // btnTinChu
            // 
            this.btnTinChu.AutoSize = true;
            this.btnTinChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinChu.Location = new System.Drawing.Point(3, 217);
            this.btnTinChu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTinChu.Name = "btnTinChu";
            this.btnTinChu.Size = new System.Drawing.Size(200, 43);
            this.btnTinChu.TabIndex = 27;
            this.btnTinChu.Text = "Tín chủ";
            this.btnTinChu.UseVisualStyleBackColor = true;
            this.btnTinChu.Click += new System.EventHandler(this.btnTinChu_Click);
            // 
            // btnNgachSo
            // 
            this.btnNgachSo.AutoSize = true;
            this.btnNgachSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNgachSo.Location = new System.Drawing.Point(3, 260);
            this.btnNgachSo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNgachSo.Name = "btnNgachSo";
            this.btnNgachSo.Size = new System.Drawing.Size(200, 43);
            this.btnNgachSo.TabIndex = 25;
            this.btnNgachSo.Text = "Ngạch sớ";
            this.btnNgachSo.UseVisualStyleBackColor = true;
            this.btnNgachSo.Click += new System.EventHandler(this.btnNgachSo_Click);
            // 
            // pnlAlign
            // 
            this.pnlAlign.Controls.Add(this.rbtnRight);
            this.pnlAlign.Controls.Add(this.rbtnLeft);
            this.pnlAlign.Controls.Add(this.rbtnBottom);
            this.pnlAlign.Controls.Add(this.rbtnTop);
            this.pnlAlign.Location = new System.Drawing.Point(4, 146);
            this.pnlAlign.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAlign.Name = "pnlAlign";
            this.pnlAlign.Size = new System.Drawing.Size(211, 68);
            this.pnlAlign.TabIndex = 24;
            this.pnlAlign.Visible = false;
            // 
            // rbtnRight
            // 
            this.rbtnRight.AutoSize = true;
            this.rbtnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnRight.Location = new System.Drawing.Point(83, 34);
            this.rbtnRight.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnRight.Name = "rbtnRight";
            this.rbtnRight.Size = new System.Drawing.Size(56, 22);
            this.rbtnRight.TabIndex = 3;
            this.rbtnRight.TabStop = true;
            this.rbtnRight.Text = "phải";
            this.rbtnRight.UseVisualStyleBackColor = true;
            this.rbtnRight.CheckedChanged += new System.EventHandler(this.rbtnTop_CheckedChanged);
            // 
            // rbtnLeft
            // 
            this.rbtnLeft.AutoSize = true;
            this.rbtnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnLeft.Location = new System.Drawing.Point(83, 4);
            this.rbtnLeft.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnLeft.Name = "rbtnLeft";
            this.rbtnLeft.Size = new System.Drawing.Size(49, 22);
            this.rbtnLeft.TabIndex = 2;
            this.rbtnLeft.TabStop = true;
            this.rbtnLeft.Text = "trái";
            this.rbtnLeft.UseVisualStyleBackColor = true;
            this.rbtnLeft.CheckedChanged += new System.EventHandler(this.rbtnTop_CheckedChanged);
            // 
            // rbtnBottom
            // 
            this.rbtnBottom.AutoSize = true;
            this.rbtnBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnBottom.Location = new System.Drawing.Point(13, 34);
            this.rbtnBottom.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnBottom.Name = "rbtnBottom";
            this.rbtnBottom.Size = new System.Drawing.Size(57, 22);
            this.rbtnBottom.TabIndex = 1;
            this.rbtnBottom.TabStop = true;
            this.rbtnBottom.Text = "dưới";
            this.rbtnBottom.UseVisualStyleBackColor = true;
            this.rbtnBottom.CheckedChanged += new System.EventHandler(this.rbtnTop_CheckedChanged);
            // 
            // rbtnTop
            // 
            this.rbtnTop.AutoSize = true;
            this.rbtnTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTop.Location = new System.Drawing.Point(13, 4);
            this.rbtnTop.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnTop.Name = "rbtnTop";
            this.rbtnTop.Size = new System.Drawing.Size(54, 22);
            this.rbtnTop.TabIndex = 0;
            this.rbtnTop.TabStop = true;
            this.rbtnTop.Text = "trên";
            this.rbtnTop.UseVisualStyleBackColor = true;
            this.rbtnTop.CheckedChanged += new System.EventHandler(this.rbtnTop_CheckedChanged);
            // 
            // cbxSongNgu
            // 
            this.cbxSongNgu.AutoSize = true;
            this.cbxSongNgu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSongNgu.Location = new System.Drawing.Point(13, 113);
            this.cbxSongNgu.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSongNgu.Name = "cbxSongNgu";
            this.cbxSongNgu.Size = new System.Drawing.Size(104, 24);
            this.cbxSongNgu.TabIndex = 23;
            this.cbxSongNgu.Text = "Song Ngữ";
            this.cbxSongNgu.UseVisualStyleBackColor = true;
            this.cbxSongNgu.CheckedChanged += new System.EventHandler(this.cbxSongNgu_CheckedChanged);
            // 
            // btnSetupPaper
            // 
            this.btnSetupPaper.AutoSize = true;
            this.btnSetupPaper.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetupPaper.Location = new System.Drawing.Point(3, 382);
            this.btnSetupPaper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSetupPaper.Name = "btnSetupPaper";
            this.btnSetupPaper.Size = new System.Drawing.Size(200, 43);
            this.btnSetupPaper.TabIndex = 22;
            this.btnSetupPaper.Text = "Cài đặt khổ giấy";
            this.btnSetupPaper.UseVisualStyleBackColor = true;
            this.btnSetupPaper.Click += new System.EventHandler(this.btnSetupPaper_Click);
            // 
            // btnDeleteLongSo
            // 
            this.btnDeleteLongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLongSo.Location = new System.Drawing.Point(3, 470);
            this.btnDeleteLongSo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteLongSo.Name = "btnDeleteLongSo";
            this.btnDeleteLongSo.Size = new System.Drawing.Size(200, 39);
            this.btnDeleteLongSo.TabIndex = 21;
            this.btnDeleteLongSo.Text = "Xóa lòng sớ hiện tại";
            this.btnDeleteLongSo.UseVisualStyleBackColor = true;
            this.btnDeleteLongSo.Click += new System.EventHandler(this.btnDeleteLongSo_Click);
            // 
            // btnSaveNewLongSo
            // 
            this.btnSaveNewLongSo.AutoSize = true;
            this.btnSaveNewLongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNewLongSo.Location = new System.Drawing.Point(3, 426);
            this.btnSaveNewLongSo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveNewLongSo.Name = "btnSaveNewLongSo";
            this.btnSaveNewLongSo.Size = new System.Drawing.Size(233, 43);
            this.btnSaveNewLongSo.TabIndex = 20;
            this.btnSaveNewLongSo.Text = "Tạo mẫu lòng sớ mới";
            this.btnSaveNewLongSo.UseVisualStyleBackColor = true;
            this.btnSaveNewLongSo.Click += new System.EventHandler(this.btnSaveNewLongSo_Click);
            // 
            // cbxChuViet
            // 
            this.cbxChuViet.AutoSize = true;
            this.cbxChuViet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxChuViet.Location = new System.Drawing.Point(13, 48);
            this.cbxChuViet.Margin = new System.Windows.Forms.Padding(4);
            this.cbxChuViet.Name = "cbxChuViet";
            this.cbxChuViet.Size = new System.Drawing.Size(95, 24);
            this.cbxChuViet.TabIndex = 13;
            this.cbxChuViet.Text = "Chữ Việt";
            this.cbxChuViet.UseVisualStyleBackColor = true;
            this.cbxChuViet.CheckedChanged += new System.EventHandler(this.cbxChuViet_CheckedChanged);
            // 
            // cbxChuTrung
            // 
            this.cbxChuTrung.AutoSize = true;
            this.cbxChuTrung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxChuTrung.Location = new System.Drawing.Point(13, 80);
            this.cbxChuTrung.Margin = new System.Windows.Forms.Padding(4);
            this.cbxChuTrung.Name = "cbxChuTrung";
            this.cbxChuTrung.Size = new System.Drawing.Size(131, 24);
            this.cbxChuTrung.TabIndex = 11;
            this.cbxChuTrung.Text = "Chữ Hán Việt";
            this.cbxChuTrung.UseVisualStyleBackColor = true;
            this.cbxChuTrung.CheckedChanged += new System.EventHandler(this.cbxChuTrung_CheckedChanged);
            // 
            // txt_Focus
            // 
            this.txt_Focus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Focus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Focus.Location = new System.Drawing.Point(445, 90);
            this.txt_Focus.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Focus.Name = "txt_Focus";
            this.txt_Focus.Size = new System.Drawing.Size(63, 23);
            this.txt_Focus.TabIndex = 2;
            this.txt_Focus.TextChanged += new System.EventHandler(this.txt_Focus_TextChanged);
            this.txt_Focus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Focus_KeyDown);
            // 
            // cbxSuggest
            // 
            this.cbxSuggest.DisplayMember = "vn";
            this.cbxSuggest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSuggest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSuggest.FormattingEnabled = true;
            this.cbxSuggest.ItemHeight = 25;
            this.cbxSuggest.Location = new System.Drawing.Point(431, 147);
            this.cbxSuggest.Name = "cbxSuggest";
            this.cbxSuggest.Size = new System.Drawing.Size(107, 33);
            this.cbxSuggest.TabIndex = 0;
            this.cbxSuggest.SelectedIndexChanged += new System.EventHandler(this.cbxSuggest_SelectedIndexChanged);
            // 
            // pnlDicSuggest
            // 
            this.pnlDicSuggest.AutoScroll = true;
            this.pnlDicSuggest.BackColor = System.Drawing.Color.Transparent;
            this.pnlDicSuggest.Location = new System.Drawing.Point(431, 201);
            this.pnlDicSuggest.Name = "pnlDicSuggest";
            this.pnlDicSuggest.Size = new System.Drawing.Size(95, 56);
            this.pnlDicSuggest.TabIndex = 3;
            // 
            // pBx
            // 
            this.pBx.BackColor = System.Drawing.Color.White;
            this.pBx.ContextMenuStrip = this.ctextMenuS;
            this.pBx.Location = new System.Drawing.Point(3, 3);
            this.pBx.Name = "pBx";
            this.pBx.Size = new System.Drawing.Size(472, 285);
            this.pBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pBx.TabIndex = 0;
            this.pBx.TabStop = false;
            this.pBx.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pBx_MouseDoubleClick);
            this.pBx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBx_MouseDown);
            this.pBx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBx_MouseMove);
            this.pBx.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBx_MouseUp);
            this.pBx.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pBx_MouseWheel);
            // 
            // timerNotifyUpdate
            // 
            this.timerNotifyUpdate.Enabled = true;
            this.timerNotifyUpdate.Interval = 3000;
            this.timerNotifyUpdate.Tick += new System.EventHandler(this.timerNotifyUpdate_Tick);
            // 
            // FrmPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.splitCntMain);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bibe.vn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPreview_FormClosing);
            this.Load += new System.EventHandler(this.FrmPreview_Load);
            this.SizeChanged += new System.EventHandler(this.FrmPreview_SizeChanged);
            this.ctextMenuS.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitCntMain.Panel1.ResumeLayout(false);
            this.splitCntMain.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCntMain)).EndInit();
            this.splitCntMain.ResumeLayout(false);
            this.pnlAlign.ResumeLayout(false);
            this.pnlAlign.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x0400009A RID: 154
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.PictureBox pBx;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.Label lblInfo;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.CheckBox ckxMaSo;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.ToolStrip toolStrip1;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.ToolStripButton tlSBtnPrint;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.ToolStripButton tlSBtnRedo;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.ToolStripLabel toolStripLabel1;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator5;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.ToolStripLabel tlSLblKieuChuCN;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.ToolStripComboBox tlSCbxFontCN;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.SplitContainer splitCntMain;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.CheckBox cbxChuTrung;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.ComboBox cbxSuggest;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.CheckBox cbxChuViet;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.ToolStripComboBox tlSCbxFontVN;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator6;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.ToolStripLabel tlSLblKieuChuVN;

		// Token: 0x040000AE RID: 174
	//	private global::PrintSo.ToolTipCustom toolTipCustom1;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.ContextMenuStrip ctextMenuS;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemThemChuSauTinChu;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.TextBox txt_Focus;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.Button btnSaveNewLongSo;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.ToolStripComboBox tlSCbxFontVNStyle;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.Button btnDeleteLongSo;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.Button btnSetupPaper;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddRow;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddCol;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemDelRow;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemDelCol;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemDelCel;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddMua;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddYear;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddMonth;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddDay;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddNoiC;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddAdress;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.CheckBox cbxSongNgu;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.ToolStripComboBox tlSCbxFontCNSize;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.ToolStripComboBox tlSCbxFontVNSize;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.Panel pnlAlign;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.RadioButton rbtnBottom;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.RadioButton rbtnTop;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.RadioButton rbtnRight;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.RadioButton rbtnLeft;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.Button btnNgachSo;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddNgachSo;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.ToolStripComboBox tlSCbxFontCNStyle;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddTinChu;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemPaste;

		// Token: 0x040000CE RID: 206
		//private global::PrintSo.USupportInfo uSupportInfo1;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.ToolStripButton tlSBtnInputKey;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.Timer timerNotifyUpdate;

		// Token: 0x040000D1 RID: 209
	//	private global::PrintSo.UHasNewVersionNote uHasNewVersionNote1;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Button btnTinChu;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddGiaChu;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddHuongLinh;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddHLinhSinh;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddHLinhMat;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.ToolStripMenuItem TSMItemAddHLinhTho;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.ToolStripButton tlSBtnUndo;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.CheckBox cbxVNLeft;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.FlowLayoutPanel pnlDicSuggest;

		// Token: 0x040000DB RID: 219
		//private global::PrintSo.PanelBibe pnlLongSo;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.ToolStripButton tlSBtnPrintAll;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Button btnDanhSach;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.ToolStripButton tlSBtnLoaiSo;
	}
}
