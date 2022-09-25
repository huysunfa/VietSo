using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVietSo
{
    public partial class frmWellCome : Form
    {
        public frmWellCome()
        {
            InitializeComponent();
        }
        public void OuputOK(String INPUT)
        {
            this.Invoke(new Action(() =>
            {
                label1.Text += "\n" + INPUT;
            }));
        }
        private void frmWellCome_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            Task.Run(() =>
            {
                OuputOK("--- Kiểm tra bản quyền ---");
                var licence = CheckLogin();
                if (licence == false)
                {
                    Application.Exit();
                    return;
                }
                OuputOK("1. Tải dữ liệu font chữ hán");

                loadFont.loadListFontCN();
                OuputOK("2.  Tải dữ liệu font chữ việt");
                loadFont.loadListFontVN();
                OuputOK("3.  Tải dữ liệu thư viện chữ hán");
                CNDictionary.loadDatabase();
                OuputOK("4.  Tải dữ liệu lòng sớ đang mở");
                Models.LongSo.GetLongSos(true);
                OuputOK("5.  GetLabelTexts");
                LabelText.GetLabelTexts(true);  
           //     OuputOK("6.  InstallFonts");
                var check=  loadFont.CheckFontNoInstall();

                if (check)
                {
                     Application.Exit();
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    return;
                }
                 //OuputOK("6. Mở phần mềm");
                this.Invoke(new Action(() =>
               {

                   var frm = new Form1();

                   // Thread.Sleep(500);
                   this.Hide();
                   frm.WindowState = FormWindowState.Maximized;
                   frm.ShowDialog();
                   this.Close();
               }));



            });
        }
        public void StartForm()
        {
            Application.Run(new Form1());
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            textBox.PasswordChar = '*';

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public bool CheckLogin()
        {

            string value = CheckKey.LocalKey();

            var check = false;
            check = CheckKey.checkOnline(value);

            if (check == false)
            {
                if (InputBox("Nhập key kích hoạt", "Nhập key kích hoạt", ref value) == DialogResult.OK)
                {
                    check = CheckKey.checkOnline(value);
                }
            }


            if (check)
            {


                CheckKey.UpdateKeyOnline(value);


                value = Security.Encrypt(value);
                File.WriteAllText("Data/" + "licence", value);

                return true;
            }
            else
            {
                MessageBox.Show("Key không chính xác ...");
                Application.Exit();
                return false;
            }
        }
    }
}
