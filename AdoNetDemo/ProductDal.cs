using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    public class ProductDal
    {
        SqlConnection _sqlConnection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");

        public List<Product> getAll()
        {
            ConnectionControl();
            

            SqlCommand sqlCommand = new SqlCommand("Select * from Products", _sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);
            }

            reader.Close();
            _sqlConnection.Close();

            return products;

        }

        private void ConnectionControl()
        {
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand(
                "Insert into Products values(@name,@unitPrice,@stockAmount)", _sqlConnection);

            sqlCommand.Parameters.AddWithValue("@name",product.Name);
            sqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            

            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand(
                "Update Products set Name=@name, UnitPrice=@unitPrice, StockAmount=@stockAmount where Id=@id", _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", product.Id);
            sqlCommand.Parameters.AddWithValue("@name", product.Name);
            sqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@stockAmount", product.StockAmount);


            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand(
                "Delete from Products where Id=@id", _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);

            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        public DataTable getAll2() 
        {
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
           
            SqlCommand sqlCommand = new SqlCommand("Select * from Products", _sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            DataTable datatable= new DataTable();
            datatable.Load(reader);

            reader.Close();
            _sqlConnection.Close();

            return datatable;

        }
    }
}
