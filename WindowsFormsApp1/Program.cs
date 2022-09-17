using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
  		public static UserSetting Stg;
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            CNDictionary.loadDatabase();


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

                Application.Run(new frmWellCome());

            }
            else
            {
                MessageBox.Show("Key không chính xác ...");
                Application.Exit();
                return;
            }
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

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
             MessageBox.Show("Có lỗi xảy ra, vui lòng gọi tới 0827.298.555 hoặc  zalo 0911.108.297 \n " + e.Exception.ToString());
        }
    }
}
