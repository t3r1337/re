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
    public partial class Form1 : Form
    {
        Database database = new Database();
        public string test;
        public Form1()
        {
            InitializeComponent();
            refresh1();
        }
        public void refresh1()
        {
            database.RefreshTables("Select School.ID, Sport.Sport, School.Number from School inner join Sport on School.Sports=Sport.ID", dataGridView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refresh1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.mode = "add";
            fr.table = dataGridView1;
            database.ComboBox("Select * from Sport", fr.comboBox1,"Sport","ID"); // пишешь таблицу, откуда берутся значения в основную, а потом комбобокс
            fr.Show();
        }

        private void asd_Click(object sender, EventArgs e)
        {
            database.RefreshTables("Select School.ID, Sport.Sport, School.Number from School inner join Sport on School.Sports=Sport.ID", dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            string id = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            database.SqlQuery($"Delete from School where ID = '{id}'");
            database.RefreshTables("Select School.ID, Sport.Sport, School.Number from School inner join Sport on School.Sports=Sport.ID", dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.mode = "edit";
            fr.table = dataGridView1;
            database.ComboBox("Select * from Sport", fr.comboBox1, "Sport", "ID");
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            fr.id = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            fr.comboBox1.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            fr.textBox1.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            fr.Show();
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataGridViewSelectedCellCollection DS = dataGridView1.SelectedCells;
            // string 
          
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form2 fr = new Form2();
            fr.mode = "edit";
            fr.table = dataGridView1;
            database.ComboBox("Select * from Sport", fr.comboBox1, "Sport", "ID");
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            fr.id = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            fr.comboBox1.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            fr.textBox1.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            fr.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    dataGridView1.Rows[i].Selected = false;
            //    for (int j = 0; j < dataGridView1.ColumnCount; j++)
            //        if (dataGridView1.Rows[i].Cells[j].Value != null)
            //            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
            //            {
            //                dataGridView1.Rows[i].Selected = true;
            //                break;
            //            }
            //}
            database.RefreshTables($"Select School.ID, Sport.Sport, School.Number from School inner join Sport on School.Sports=Sport.ID Where * like'{textBox1.Text}%'", dataGridView1);
        }
    }
}
