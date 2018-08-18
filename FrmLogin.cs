using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;
using PriceTagPrint.Common;

namespace PriceTagPrint
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        public void chkUpd()
        {
            var url = "http://10.4.12.52:8000/Update/PriceTagPrint/UpdateList.xml";
            if (!File.Exists("UpdateList.xml"))
            {
                Common.HttpHelper.HttpDownload(url, AppDomain.CurrentDomain.BaseDirectory);
            }
            var appVer = new XmlFiles("UpdateList.xml").GetNodeValue("//Version");
            var appNewVer = new XmlFiles(url).GetNodeValue("//Version");
            if (appVer.Trim() != appNewVer.Trim())
            {
                if (MessageBox.Show("有新的更新程序", "系统更新", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                if (!File.Exists("AutoUpdate.exe"))
                {
                    MessageBox.Show("更新程序不存在,请联系管理员!");
                    txbUserPassWd.Enabled = false;
                    return;
                }
                System.Diagnostics.Process.Start("AutoUpdate.exe");
                Process.GetCurrentProcess().Kill();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txbUserId.Text != "admin")
            {
                MessageBox.Show("用户名错误!");
                return;
            }

            if (txbUserPassWd.Text != "admin")
            {
                MessageBox.Show("密码错误!");
                return;
            }
            
            new FrmMain().Show();
            this.Hide();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
            txbUserId.Properties.MaxLength = 6;
            txbUserPassWd.MaxLength = 10;
            chkUpd();}

        private void txbUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txbUserId.Text.IsEmpty())
                {
                    txbUserPassWd.Focus();
                }
                else
                {
                    MessageBox.Show("用户名不能为空!");
                }
            }
        }

        private void txbUserPassWd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txbUserPassWd.Text.IsEmpty())
                {
                    btnLogin.PerformClick();
                }
                else
                {
                    MessageBox.Show("密码不能为空!");
                }
            }
        }
    }
}
