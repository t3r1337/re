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
    class Database
    {
        private string connectionString = (@"Data Source=ZXC123\SQLEXPRESS;Initial Catalog=tr;Integrated Security=True");
        public void RefreshTables(string sql, DataGridView dataGridView)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView.DataSource = ds.Tables[0];
                    connection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте соединение");
            }
        }
        public void SqlQuery(string sql)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
        public void ComboBox(string sql, ComboBox comboBox, string displayMember, string valueMember)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataTable tb = new DataTable();
                    adapter.Fill(tb);
                    comboBox.DataSource = tb;
                    comboBox.DisplayMember = displayMember;
                    comboBox.ValueMember = valueMember;
                    connection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка");
            }
        }

        public void Role(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand commandLogin = new SqlCommand(sql, connection);
                    string role = commandLogin.ExecuteScalar().ToString();
                    if (role.Trim() == "op")
                    {
                        Op op = new Op();
                        op.Show();
                    }
                    else if (role.Trim() == "ad")
                    {
                        Form1 form1 = new Form1();
                        form1.Show();
                    }
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Проверьте логин и пароль");
                }
            }
            }
    }
}

