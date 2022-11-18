
namespace AppVietSo
{
    // Token: 0x02000015 RID: 21
    public partial class FrmSetupPaper : global::System.Windows.Forms.Form
    {
        // Token: 0x06000129 RID: 297 RVA: 0x000170CC File Offset: 0x000152CC
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Token: 0x0600012A RID: 298 RVA: 0x000170EC File Offset: 0x000152EC
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nmrHeight = new System.Windows.Forms.NumericUpDown();
            this.nmrWidth = new System.Windows.Forms.NumericUpDown();
            this.nmrTop = new System.Windows.Forms.NumericUpDown();
            this.nmrBottom = new System.Windows.Forms.NumericUpDown();
            this.nmrLeft = new System.Windows.Forms.NumericUpDown();
            this.nmrRight = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxPaperSize = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrintSetting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmrHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrRight)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dài";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Rộng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dưới";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Trên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(173, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Phải";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Trái";
            // 
            // nmrHeight
            // 
            this.nmrHeight.Location = new System.Drawing.Point(62, 60);
            this.nmrHeight.Margin = new System.Windows.Forms.Padding(5);
            this.nmrHeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nmrHeight.Name = "nmrHeight";
            this.nmrHeight.ReadOnly = true;
            this.nmrHeight.Size = new System.Drawing.Size(101, 26);
            this.nmrHeight.TabIndex = 2;
            this.nmrHeight.ValueChanged += new System.EventHandler(this.nmr_ValueChanged);
            // 
            // nmrWidth
            // 
            this.nmrWidth.Location = new System.Drawing.Point(62, 28);
            this.nmrWidth.Margin = new System.Windows.Forms.Padding(5);
            this.nmrWidth.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nmrWidth.Name = "nmrWidth";
            this.nmrWidth.ReadOnly = true;
            this.nmrWidth.Size = new System.Drawing.Size(101, 26);
            this.nmrWidth.TabIndex = 1;
            this.nmrWidth.ValueChanged += new System.EventHandler(this.nmr_ValueChanged);
            // 
            // nmrTop
            // 
            this.nmrTop.Location = new System.Drawing.Point(122, 31);
            this.nmrTop.Margin = new System.Windows.Forms.Padding(5);
            this.nmrTop.Name = "nmrTop";
            this.nmrTop.Size = new System.Drawing.Size(50, 26);
            this.nmrTop.TabIndex = 3;
            this.nmrTop.ValueChanged += new System.EventHandler(this.nmr_ValueChanged);
            // 
            // nmrBottom
            // 
            this.nmrBottom.Location = new System.Drawing.Point(122, 126);
            this.nmrBottom.Margin = new System.Windows.Forms.Padding(5);
            this.nmrBottom.Name = "nmrBottom";
            this.nmrBottom.Size = new System.Drawing.Size(50, 26);
            this.nmrBottom.TabIndex = 4;
            this.nmrBottom.ValueChanged += new System.EventHandler(this.nmr_ValueChanged);
            // 
            // nmrLeft
            // 
            this.nmrLeft.Location = new System.Drawing.Point(57, 77);
            this.nmrLeft.Margin = new System.Windows.Forms.Padding(5);
            this.nmrLeft.Name = "nmrLeft";
            this.nmrLeft.Size = new System.Drawing.Size(50, 26);
            this.nmrLeft.TabIndex = 5;
            this.nmrLeft.ValueChanged += new System.EventHandler(this.nmr_ValueChanged);
            // 
            // nmrRight
            // 
            this.nmrRight.Location = new System.Drawing.Point(223, 77);
            this.nmrRight.Margin = new System.Windows.Forms.Padding(5);
            this.nmrRight.Name = "nmrRight";
            this.nmrRight.Size = new System.Drawing.Size(50, 26);
            this.nmrRight.TabIndex = 6;
            this.nmrRight.ValueChanged += new System.EventHandler(this.nmr_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(171, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "mm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(171, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "mm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbxPaperSize);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nmrHeight);
            this.groupBox1.Controls.Add(this.nmrWidth);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 100);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khổ giấy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Chọn khổ giấy";
            // 
            // cbxPaperSize
            // 
            this.cbxPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPaperSize.FormattingEnabled = true;
            this.cbxPaperSize.Location = new System.Drawing.Point(223, 59);
            this.cbxPaperSize.Name = "cbxPaperSize";
            this.cbxPaperSize.Size = new System.Drawing.Size(156, 28);
            this.cbxPaperSize.TabIndex = 16;
            this.cbxPaperSize.SelectedIndexChanged += new System.EventHandler(this.cbxPaperSize_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nmrLeft);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.nmrRight);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.nmrBottom);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nmrTop);
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 163);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khoảng cách mép giấy";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnPrintSetting
            // 
            this.btnPrintSetting.Location = new System.Drawing.Point(329, 178);
            this.btnPrintSetting.Name = "btnPrintSetting";
            this.btnPrintSetting.Size = new System.Drawing.Size(164, 28);
            this.btnPrintSetting.TabIndex = 16;
            this.btnPrintSetting.Text = "Cài đặt máy in";
            this.btnPrintSetting.UseVisualStyleBackColor = true;
            this.btnPrintSetting.Click += new System.EventHandler(this.btnPrintSetting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Khổ giấy nên để là A3s (470 x 297)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(334, 265);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Chiều giấy in";
            this.label11.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "DỌC\t",
            "NGANG"});
            this.comboBox1.Location = new System.Drawing.Point(337, 294);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 28);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(325, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "Máy in :";
            // 
            // FrmSetupPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 343);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnPrintSetting);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetupPaper";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt khổ giấy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSetupPaper_FormClosing);
            this.Load += new System.EventHandler(this.FrmSetupPaper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmrHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrRight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Token: 0x0400011C RID: 284
        private global::System.ComponentModel.IContainer components;

        // Token: 0x0400011D RID: 285
        private global::System.Windows.Forms.Label label2;

        // Token: 0x0400011E RID: 286
        private global::System.Windows.Forms.Label label3;

        // Token: 0x0400011F RID: 287
        private global::System.Windows.Forms.Label label4;

        // Token: 0x04000120 RID: 288
        private global::System.Windows.Forms.Label label5;

        // Token: 0x04000121 RID: 289
        private global::System.Windows.Forms.Label label7;

        // Token: 0x04000122 RID: 290
        private global::System.Windows.Forms.Label label8;

        // Token: 0x04000123 RID: 291
        private global::System.Windows.Forms.NumericUpDown nmrHeight;

        // Token: 0x04000124 RID: 292
        private global::System.Windows.Forms.NumericUpDown nmrWidth;

        // Token: 0x04000125 RID: 293
        private global::System.Windows.Forms.NumericUpDown nmrTop;

        // Token: 0x04000126 RID: 294
        private global::System.Windows.Forms.NumericUpDown nmrBottom;

        // Token: 0x04000127 RID: 295
        private global::System.Windows.Forms.NumericUpDown nmrLeft;

        // Token: 0x04000128 RID: 296
        private global::System.Windows.Forms.NumericUpDown nmrRight;

        // Token: 0x04000129 RID: 297
        private global::System.Windows.Forms.Label label9;

        // Token: 0x0400012A RID: 298
        private global::System.Windows.Forms.Label label10;

        // Token: 0x0400012B RID: 299
        private global::System.Windows.Forms.GroupBox groupBox1;

        // Token: 0x0400012C RID: 300
        private global::System.Windows.Forms.GroupBox groupBox2;

        // Token: 0x0400012D RID: 301
        private global::System.Windows.Forms.Button btnPrintSetting;

        // Token: 0x0400012E RID: 302
        private global::System.Windows.Forms.ComboBox cbxPaperSize;

        // Token: 0x0400012F RID: 303
        private global::System.Windows.Forms.Label label1;

        // Token: 0x04000130 RID: 304
        private global::System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
    }
}
