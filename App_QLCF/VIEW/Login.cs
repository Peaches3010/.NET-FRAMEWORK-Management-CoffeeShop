
using App_QLCF.DAO;
using App_QLCF.DTO;
using App_QLCF.VIEW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QLCF
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            if(ktLogin(userName,passWord)) // true
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                Home h = new Home(loginAccount);
                this.Hide();
                h.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!!! ");
            }
        }
        bool ktLogin(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void btncheckout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
