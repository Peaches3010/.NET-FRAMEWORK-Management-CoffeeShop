using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLCF.DTO
{
    public class Food
    {
        public Food(int id, string nameFood, int iDCategory, float price)
        {
            this.ID = id;
            this.NameFood = nameFood;
            this.IDCategory = iDCategory;
            this.Price = price;
        }

        public Food (DataRow row)
        {
            this.ID = (int)row["id"];
            this.NameFood = row["NameFood"].ToString();
            this.IDCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
        private int iD;
        private string nameFood;
        private int iDCategory;
        private float price;


        public int ID { get => iD; set => iD = value; }
        public string NameFood { get => nameFood; set => nameFood = value; }
        public int IDCategory { get => iDCategory; set => iDCategory = value; }
        public float Price { get => price; set => price = value; }
    }
}
