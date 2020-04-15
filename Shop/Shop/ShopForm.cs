using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class ShopForm : Form
    {
        public ShoppingCart shoppingCart = new ShoppingCart();

        public BindingSource bindingSourceForShoppingCart = new BindingSource();
        public BindingSource bindingSourceForMenu = new BindingSource();

        decimal CashBox = 0.0m;
        public ShopForm()
        {
            InitializeComponent();

            UpdateUI();

            SetGridColumns();

            SetDataSource();

            SetDataBindings();
        }

        #region  Methods
        private void SetDataBindings()
        {
            ClearDataBindings(this);

            tbShoppingCartSum.Text = string.Format("{0:C}", shoppingCart.SumOfAllProducts);
            tbCashBox.Text = string.Format("{0:C}", CashBox);
            //var binding = tbShoppingCartSum.DataBindings.Add("Text", shoppingCart, "SumOfAllProducts");
            //binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        }

        private void ClearDataBindings(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                ctrl.DataBindings.Clear();

                ClearDataBindings(ctrl);
            }
        }

        private void SetDataSource()
        {
            bindingSourceForMenu.DataSource = Product.GetProducts();
            gvMenu.DataSource = bindingSourceForMenu;

            bindingSourceForShoppingCart.DataSource = shoppingCart.Products;

            gvShoppingCart.DataSource = bindingSourceForShoppingCart;
        }

        private void UpdateUI()
        {
            gvMenu.AutoGenerateColumns = false;
            gvShoppingCart.AutoGenerateColumns = false;
        }

        private void SetGridColumns()
        {

            DataGridViewColumn col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Име";
            col.DataPropertyName = "Name";
            col.ReadOnly = true;
            gvMenu.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Цена";
            col.DataPropertyName = "Price";
            col.ReadOnly = true;
            gvMenu.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "к-во";
            col.DataPropertyName = "Qty";
            col.ReadOnly = false;
            gvMenu.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Име";
            col.DataPropertyName = "Name";
            col.ReadOnly = true;
            gvShoppingCart.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Цена";
            col.DataPropertyName = "Price";
            col.ReadOnly = true;
            gvShoppingCart.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "к-во";
            col.DataPropertyName = "Qty";
            col.ReadOnly = false;
            gvShoppingCart.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Обща цена";
            col.DataPropertyName = "Sum";
            col.ReadOnly = false;
            gvShoppingCart.Columns.Add(col);
        }

        private void AddProductToShoppingCart(Product product)
        {
            Product productToAdd = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Qty = product.Qty
            };

            shoppingCart.Products.Add(productToAdd);
            bindingSourceForShoppingCart.ResetBindings(false);

            product.Qty = 0;
            bindingSourceForMenu.ResetBindings(false);
        }

        private void ClearShoppingCart()
        {
            shoppingCart.Products.Clear();
            bindingSourceForShoppingCart.ResetBindings(false);
            tbShoppingCartSum.Text = "0";
        }

        #endregion

        #region Events
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var view = sender as DataGridView;

            Product product = (Product)view.CurrentRow.DataBoundItem;

            if (product.Qty > 0)
            {
                AddProductToShoppingCart(product);

            }
            else
            {
                MessageBox.Show("Моля въведете количество на желания продукт");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetDataBindings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearShoppingCart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CashBox += shoppingCart.SumOfAllProducts;

            SetDataBindings();

            ClearShoppingCart();
        }

        #endregion
    }
}
