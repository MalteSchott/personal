using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPWindowsForm
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Takes the User to the page for assignment 1
        private void button1_Click(object sender, EventArgs e)
        {
            Assignment1 assignment1 = new Assignment1();
            assignment1.Tag = this;
            assignment1.Show(this);
            Hide();
        }

        //Takes the User to the page for assignment 2
        private void button2_Click(object sender, EventArgs e)
        {
            Assignment2 assignment2 = new Assignment2();
            assignment2.Tag = this;
            assignment2.Show(this);
            Hide();
        }
    }
}
