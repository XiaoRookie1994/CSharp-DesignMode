using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static 策略模式.strategy;

namespace 策略模式
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            strategy s= null;
            switch (comboBox1.SelectedIndex)
            {               
                case 0:
                     s = new strategy(new zhengchang() { _price = int.Parse(textBox1.Text) });break;
                case 1:
                     s = new strategy(new zhekou(double.Parse(comboBox1.SelectedItem.ToString())) { _price = int.Parse(textBox1.Text) }); break;
            }
            label1.Text = s.getResult(double.Parse(textBox1.Text)).ToString(); 
        }
    }
}
