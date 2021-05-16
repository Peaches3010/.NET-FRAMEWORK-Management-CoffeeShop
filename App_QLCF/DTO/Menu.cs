using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLCF.DTO
{
    public class Menu
    {
        public Menu(string foodName, int count, float price, float totalprice)
        {
            this.FoodName = foodName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }
        public Menu (DataRow row)
        {
            this.FoodName = row["NameFood"].ToString();
            this.Count = (int)row["count"];
            this.Price = Convert.ToSingle((double)row["price"]);
            this.TotalPrice = Convert.ToSingle((double)row["totalPrice"]); 
        }
        private string foodName;
        private int count;
        private double price;
        private double totalPrice;
        

        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public double Price { get => price; set => price = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
       
    }
}
