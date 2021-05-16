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
    public partial class Admin : Form
    {
        BindingSource foodlist = new BindingSource();
        BindingSource categorylist = new BindingSource();
        BindingSource accountlist = new BindingSource();
        public Account loginAccount;
        public Admin()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            dtgvFood.DataSource = foodlist;
            dtgvAccount.DataSource = accountlist;
            dtgvCategory.DataSource = categorylist;
            LoadDateTimePickerBill();
            LoadDateTimePickerByDate(dtpkFrom.Value, dtpkTo.Value);
            LoadListFood();
            LoadAccount();
            AddFoodBiding();
            LoadCategoryFood();
            AddCategoryBinding();
            AddAccountBinding();
            LoadCategoryInfoCombox(cbCategory);
        }

        void LoadDateTimePickerByDate(DateTime checkIn, DateTime checkOut)
        {
            dataGridView1.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpkTo.Value = dtpkFrom.Value.AddMonths(1).AddDays(-1);

        }

        void AddFoodBiding()
        {
            txtName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "NameFood", true, DataSourceUpdateMode.Never));
            txtId.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            ndFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryInfoCombox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "NameCategory";

        }

        void LoadCategoryFood() {
            categorylist.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            LoadDateTimePickerByDate(dtpkFrom.Value, dtpkTo.Value);
        }
        void LoadListFood()
        {
            foodlist.DataSource = FoodDAO.Instance.LoadFood();
        }
        void AddCategoryBinding()
        {
            txtIdCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtNameCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "NameCategory", true, DataSourceUpdateMode.Never));
        }
        void AddAccountBinding()
        {
            txtUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtDisplayname.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void LoadAccount()
        {
            accountlist.DataSource = AccountDAO.Instance.GetListAccount();

        }
        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
               
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }
        
        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng đừng xóa chính bạn chứ");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }

        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["IDCategory"].Value;

                Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                cbCategory.SelectedItem = cateogory;

                int index = -1;
                int i = 0;
                foreach (Category item in cbCategory.Items)
                {
                    if (item.ID == cateogory.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbCategory.SelectedIndex = index;
            }

        }

        private void btn_AddFood_Click_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int idCategory = (cbCategory.SelectedItem as Category).ID;
            float price = (float)ndFoodPrice.Value;
            if (FoodDAO.Instance.InsertFood(name, idCategory, price))
            {
                MessageBox.Show("Thêm món ăn thành công");
                LoadListFood();
                if (insertFood != null)
                {
                    insertFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món");
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int id = Convert.ToInt32(txtId.Text);
            int idCategory = (cbCategory.SelectedItem as Category).ID;
            float price = (float)ndFoodPrice.Value;
            if (FoodDAO.Instance.EditFood(name, idCategory, price, id))
            {
                MessageBox.Show("Sửa món ăn thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa món");
            }
        }
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món ăn thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi Xóa món");
            }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            foodlist.DataSource = SearchFoodByName(name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btn_addAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string displayname = txtDisplayname.Text;
            int type = (int)numericUpDown1.Value;
            AddAccount(username, displayname, type);
        }

        private void btn_EditAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string displayname = txtDisplayname.Text;
            int type = (int)numericUpDown1.Value;

            EditAccount(username, displayname, type);
        }

        private void btn_DeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            DeleteAccount(username);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;

            ResetPass(username);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            txtPageBill.Text = "1";
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFrom.Value, dtpkTo.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            txtPageBill.Text = lastPage.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtPageBill.Text);

            if (page > 1)
                page--;

            txtPageBill.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtPageBill.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFrom.Value, dtpkTo.Value);

            if (page < sumRecord)
                page++;

            txtPageBill.Text = page.ToString();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryname = txtNameCategory.Text;
            InsertCategory(categoryname);
        }

        void InsertCategory(string categoryname)
        {
            if (CategoryDAO.Instance.InsertCategory(categoryname))
            {
                MessageBox.Show("Thêm danh mục thành công");
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại");
            }
            LoadCategoryFood();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string categoryname = txtNameCategory.Text;
            int idcategory = Convert.ToInt32(txtIdCategory.Text);
            EditCategory(categoryname,idcategory);
        }
        void EditCategory(string categoryname,int idcategory)
        {
            if (CategoryDAO.Instance.EditCategory(categoryname,idcategory))
            {
                MessageBox.Show("Sửa danh mục thành công");
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại");
            }
            LoadCategoryFood();
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadCategoryFood();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int categoryid = Convert.ToInt32(txtIdCategory.Text);
            DeleteCategory(categoryid);
        }
        void DeleteCategory(int idCategory)
        {
            if (CategoryDAO.Instance.DeleteCategory(idCategory))
            {
                MessageBox.Show("Xóa danh mục thành công");
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại");
            }
            LoadCategoryFood();
        }
    }
}