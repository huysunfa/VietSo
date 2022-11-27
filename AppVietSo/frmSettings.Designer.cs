
namespace AppVietSo
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.cb_SuDungCauHinhMayInMacDinh = new System.Windows.Forms.CheckBox();
            this.ckPageScaling = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cb_SuDungCauHinhMayInMacDinh
            // 
            this.cb_SuDungCauHinhMayInMacDinh.AutoSize = true;
            this.cb_SuDungCauHinhMayInMacDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_SuDungCauHinhMayInMacDinh.Location = new System.Drawing.Point(34, 36);
            this.cb_SuDungCauHinhMayInMacDinh.Name = "cb_SuDungCauHinhMayInMacDinh";
            this.cb_SuDungCauHinhMayInMacDinh.Size = new System.Drawing.Size(473, 33);
            this.cb_SuDungCauHinhMayInMacDinh.TabIndex = 0;
            this.cb_SuDungCauHinhMayInMacDinh.Text = "Sử dụng cấu hình máy in từ phần mềm";
            this.cb_SuDungCauHinhMayInMacDinh.UseVisualStyleBackColor = true;
            this.cb_SuDungCauHinhMayInMacDinh.CheckedChanged += new System.EventHandler(this.cb_SuDungCauHinhMayInMacDinh_CheckedChanged);
            // 
            // ckPageScaling
            // 
            this.ckPageScaling.AutoSize = true;
            this.ckPageScaling.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPageScaling.Location = new System.Drawing.Point(34, 114);
            this.ckPageScaling.Name = "ckPageScaling";
            this.ckPageScaling.Size = new System.Drawing.Size(364, 33);
            this.ckPageScaling.TabIndex = 1;
            this.ckPageScaling.Text = "Không sử dụng PageScaling";
            this.ckPageScaling.UseVisualStyleBackColor = true;
            this.ckPageScaling.CheckedChanged += new System.EventHandler(this.ckPageScaling_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 588);
            this.Controls.Add(this.ckPageScaling);
            this.Controls.Add(this.cb_SuDungCauHinhMayInMacDinh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.Text = "Cài đặt hệ thống";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_SuDungCauHinhMayInMacDinh;
        private System.Windows.Forms.CheckBox ckPageScaling;
    }
}