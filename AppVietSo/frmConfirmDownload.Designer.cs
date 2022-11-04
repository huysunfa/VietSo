
namespace AppVietSo
{
    partial class frmConfirmDownload
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvParent = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Download = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParent)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvParent
            // 
            this.dgvParent.AllowUserToAddRows = false;
            this.dgvParent.AllowUserToDeleteRows = false;
            this.dgvParent.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Download,
            this.LoaiSo,
            this.FileName});
            this.dgvParent.Location = new System.Drawing.Point(14, 142);
            this.dgvParent.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgvParent.Name = "dgvParent";
            this.dgvParent.ReadOnly = true;
            this.dgvParent.RowHeadersVisible = false;
            this.dgvParent.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvParent.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvParent.RowTemplate.Height = 35;
            this.dgvParent.Size = new System.Drawing.Size(534, 377);
            this.dgvParent.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(31, 528);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 59);
            this.button1.TabIndex = 7;
            this.button1.Text = "Đồng ý tải về";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(289, 528);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(233, 59);
            this.button2.TabIndex = 8;
            this.button2.Text = "Không đồng ý";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(14, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(534, 121);
            this.textBox1.TabIndex = 10;
            // 
            // Download
            // 
            this.Download.HeaderText = "Download";
            this.Download.MinimumWidth = 6;
            this.Download.Name = "Download";
            this.Download.ReadOnly = true;
            this.Download.Width = 125;
            // 
            // LoaiSo
            // 
            this.LoaiSo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LoaiSo.DataPropertyName = "LoaiSo";
            this.LoaiSo.HeaderText = "Lòng sớ cần tải về";
            this.LoaiSo.MinimumWidth = 6;
            this.LoaiSo.Name = "LoaiSo";
            this.LoaiSo.ReadOnly = true;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "FileName";
            this.FileName.MinimumWidth = 6;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Visible = false;
            this.FileName.Width = 125;
            // 
            // frmConfirmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 609);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvParent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfirmDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận tải về";
            this.Load += new System.EventHandler(this.frmConfirmDownload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvParent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Download;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
    }
}