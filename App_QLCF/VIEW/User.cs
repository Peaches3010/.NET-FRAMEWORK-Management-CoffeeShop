using App_QLCF.DAO;
using App_QLCF.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QLCF.VIEW
{
    public partial class User : Form
    {
        private Account loginAccount;

        
        public User(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }

        public Account LoginAccount
        {
            get => loginAccount;
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        void ChangeAccount(Account acc)
        {
            txtUserName.Text = LoginAccount.UserName;
            txtDisplayName.Text = LoginAccount.DisplayName;
        }

       
        void UpdateAccount()
        {
            string displayname = txtDisplayName.Text;
            string password = txtPassWord.Text;
            string newPass = txtNewPass.Text;
            string reenterPass = txtReEnterPass.Text;
            string username = txtUserName.Text;
            
            if(!newPass.Equals(reenterPass))
            {
                MessageBox.Show("Mật Khẩu không khớp");
            }    
            else
            {
                if (AccountDAO.Instance.UpdateAccount(username, displayname, password, newPass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                       updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(username)));
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin");
                }    
            }    
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateInAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        public class AccountEvent : EventArgs 
        {
            private Account acc;

            public Account Acc { get => acc; set => acc = value; }


            public AccountEvent (Account acc)
            {
                this.Acc = acc;
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }
    }
}
