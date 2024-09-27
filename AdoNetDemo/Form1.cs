using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.getAll();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product{
                Name=tbxName.Text,
                StockAmount=Convert.ToInt32(tbxSAmount.Text),
                UnitPrice=Convert.ToDecimal(tbxUPrice.Text)
            });
            LoadProducts();

            MessageBox.Show("Product added.");
           
        }

       

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id= Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = txtNameUpdate.Text,
                UnitPrice =Convert.ToDecimal(txtUPriceUpdate.Text),
                StockAmount= Convert.ToInt32(txtSAmountUpdate.Text)
            };

            _productDal.Update(product);
            LoadProducts();
            MessageBox.Show("updated!");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            txtUPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            txtSAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);

            _productDal.Delete(id);
            LoadProducts();
            MessageBox.Show("deleted!");
        }
    }
}
