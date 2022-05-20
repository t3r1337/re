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
    public partial class Auto : Form
    {
        Database database = new Database();
        public Auto()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                database.Role($"Select Role from Users Where Login='{textBox1.Text}' and Password='{textBox2.Text}'");
        }
    }
}
