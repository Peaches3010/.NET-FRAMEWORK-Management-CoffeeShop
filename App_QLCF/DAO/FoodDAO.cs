using App_QLCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLCF.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance 
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            set { FoodDAO.instance = value; }
        }
        public FoodDAO() { }


        public List<Food> GetListFood(int id)
        {
            List<Food> listFood = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Food WHERE idCategory= "+ id);
            foreach(DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }

        public List<Food> LoadFood()
        {
            List<Food> listFood = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Food");
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }

       public bool InsertFood (string name,int idcategory, float price)
        {
            string query = string.Format("INSERT dbo.Food (NameFood,idCategory,price) VALUES(N'{0}',{1},{2})", name, idcategory, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public bool EditFood(string name, int idcategory,float price,int id)
        {
            string query = string.Format("UPDATE dbo.Food SET NameFood = N'{0}' ,idCategory = {1} ,price = {2} WHERE id = {3}", name, idcategory, price, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void DeleteFoodByIDCategory(int idCategory)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.Food WHERE idCategory = " + idCategory);
        }
        public bool DeleteFood( int idFood)
        {
           
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);
            string query = string.Format("DELETE dbo.Food WHERE id = " + idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public List<Food> SearchFoodByName(string name)
        {
            List<Food> list = new List<Food>();
            string query = string.Format("SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1(nameFood) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;

        }
    }
}
