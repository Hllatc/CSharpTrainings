using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productdal=new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            dgwProducts.DataSource = _productdal.getAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productdal.Add(new Product
            {
                Name = tbxName.Text,
                StockAmount = Convert.ToInt32(tbxSAmount.Text),
                UnitPrice = Convert.ToDecimal(tbxUPrice.Text)
            });
            LoadData();
            MessageBox.Show("Product added.");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            txtUPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            txtSAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productdal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = txtNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(txtUPriceUpdate.Text),
                StockAmount = Convert.ToInt32(txtSAmountUpdate.Text)
            });

            LoadData();
            MessageBox.Show("updated!");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);

            _productdal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadData();
            MessageBox.Show("deleted!");
        }
    }
}
