using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLCF.DTO
{
   public class Account
    {

        public Account(string username, int type, string displayname, string password = null)
        {
            this.UserName = username;
            this.Type = type;
            this.DisplayName = displayname;
            this.PassWord = password;
        }

        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.Type = (int)row["type"];
            this.PassWord = row["password"].ToString();
        }


        private string userName;
        private string passWord;
        private string displayName;
        private int type;



        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public int Type { get => type; set => type = value; }

        
    }
}
