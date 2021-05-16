using App_QLCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLCF.DAO
{
   public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance 
        {
            get { if (instance == null) instance = new CategoryDAO() ; return CategoryDAO.instance; }
            set {  CategoryDAO.instance = value; }
        }
        public CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM FoodCategory");
            foreach(DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
 
            return list;
        }

        public Category GetCategoryByID(int id)
        {
            Category category = null;

            string query = "select * from FoodCategory where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }
        
        #region
        public bool InsertCategory(string namecategory)
        {
            string query = string.Format("INSERT dbo.FoodCategory (NameCategory) VALUES (N'{0}')",namecategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool EditCategory(string namecategory, int idcategory)
        {
            string query = string.Format("UPDATE dbo.FoodCategory SET NameCategory = N'{0}' WHERE id = {1}" , namecategory,idcategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteCategory(int idCategory)
        {
            FoodDAO.Instance.DeleteFoodByIDCategory(idCategory);
            string query = string.Format("DELETE dbo.Food WHERE id = " + idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        #endregion
    }
}
