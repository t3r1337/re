using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace re
{
    class test
    {
        private string connectionString = (@"Data Source=ZXC123\SQLEXPRESS;Initial Catalog=tr;Integrated Security=True");

      public void RefreshTables(string sql, DataGridView dataGridView)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView.DataSource = ds.Tables[0];
                connection.Close();
            }
        }
        public void SqlQuery (string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void CB (string sql, ComboBox comboBox, string displayMember, string valueMember)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable tb = new DataTable();
                adapter.Fill(tb);
                comboBox.DataSource = tb;
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
                connection.Close();
            }
        }
        public void Auto (string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                string role = command.ExecuteScalar().ToString();
                connection.Close();
            }
        }
    }
}
