using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDAL productDAL = new ProductDAL();

        private void Form1_Load(object sender, EventArgs e)
        {         
            dgvProducts.DataSource = productDAL.ProductList();                                                      
        }
      
        // Search a product from textBox;
        public void SearchProducts(string key)
        {
            dgvProducts.DataSource = productDAL.GetByProductName(key);
        }
      

        // Adding Products;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            productDAL.ProductAdd(new Product
            {
                Name = txtAddName.Text,
                Price = Convert.ToDecimal(txtAddPrice.Text),
                StockAmount = Convert.ToInt32(txtAddAmount.Text)
            });

            dgvProducts.DataSource = productDAL.ProductList();
            MessageBox.Show("Product Added!");
            txtAddName.Clear();
            txtAddPrice.Clear();
            txtAddAmount.Clear();

            // OR;

            /*
             
            Product p = new Product();
            p.Name = txtAddName.Text;
            p.Price = Convert.ToDecimal(txtAddPrice.Text);
            p.StockAmount = Convert.ToInt32(txtAddAmount.Text);
            productDAL.ProductAdd(p);

            dgvProducts.DataSource = productDAL.ProductList();
            MessageBox.Show("Product Added!");
            txtAddName.Clear();
            txtAddPrice.Clear();
            txtAddAmount.Clear();

            */
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            productDAL.ProductUpdate(new Product
            {
                Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value),
                Name = txtUpdateName.Text,
                Price = Convert.ToInt32(txtUpdatePrice.Text),
                StockAmount=Convert.ToInt32(txtUpdateAmount.Text)
            });

            dgvProducts.DataSource = productDAL.ProductList();
            MessageBox.Show("Product Updated!");
            txtUpdateName.Clear();
            txtUpdatePrice.Clear();
            txtUpdateAmount.Clear();

            // OR;

            /*
             
            Product p = new Product();
            p.Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
            p.Name = txtUpdateName.Text;
            p.Price = Convert.ToInt32(txtUpdatePrice.Text);
            p.StockAmount=Convert.ToInt32(txtUpdateAmount.Text);
            productDAL.ProductUpdate(p);

            dgvProducts.DataSource = productDAL.ProductList();
            MessageBox.Show("Product Updated!");
            txtUpdateName.Clear();
            txtUpdatePrice.Clear();
            txtUpdateAmount.Clear();

            */

        }

        // Select the product by clicking the cell and send the data to the textboxes for update.
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUpdateName.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtUpdatePrice.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            txtUpdateAmount.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            productDAL.ProductDelete(new Product
            {
                Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value)
            });
            dgvProducts.DataSource = productDAL.ProductList();
            MessageBox.Show("Product Deleted!");

            // OR;

            /*
        
            Product p = new Product();
            p.Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
            productDAL.ProductDelete(p);

            dgvProducts.DataSource = productDAL.ProductList();
            MessageBox.Show("Product Updated!");

            */

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(txtSearch.Text);        
        }

       
    }
}
