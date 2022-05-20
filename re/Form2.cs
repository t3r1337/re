using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace re
{
    public partial class Form2 : Form
    {
        public string mode;
        public string id;
        public DataGridView table;
        Database database = new Database();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mode == "add")
            {
                database.SqlQuery($"Insert into School (Sports, Number) Values ('{comboBox1.SelectedValue.ToString()}', '{textBox1.Text}')");
                database.RefreshTables("Select School.ID, Sport.Sport, School.Number from School inner join Sport on School.Sports=Sport.ID", table);
                this.Close();
            }
            else if (mode == "edit")
                {
                database.SqlQuery($"Update school SET Sports ='{comboBox1.SelectedValue.ToString()}', Number='{textBox1.Text}' WHERE ID ='{id}'");
                database.RefreshTables("Select School.ID, Sport.Sport, School.Number from School inner join Sport on School.Sports=Sport.ID", table);
                this.Close();
            }
        }
    }
}
