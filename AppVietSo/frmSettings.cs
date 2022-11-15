﻿using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVietSo
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            var printsetting = ActiveData.Get("@SuDungCauHinhMayInMacDinh").ToBool();

            cb_SuDungCauHinhMayInMacDinh.Checked =  printsetting;

        }

        private void cb_SuDungCauHinhMayInMacDinh_CheckedChanged(object sender, EventArgs e)
        {
            ActiveData.Update("@SuDungCauHinhMayInMacDinh", cb_SuDungCauHinhMayInMacDinh.Checked.ToString());
        }
    }
}
