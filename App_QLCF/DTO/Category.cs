using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLCF.DTO
{
    public class Category
    {

        public Category (int id , string nameCategory)
        {
            this.ID = id;
            this.NameCategory = nameCategory;
        }
        public Category(DataRow row)
        {
            this.ID = (int)row["id"];
            this.NameCategory = row["NameCategory"].ToString();
        }
        private int iD;
        private string nameCategory;
        public int ID { get => iD; set => iD = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
    }
}
