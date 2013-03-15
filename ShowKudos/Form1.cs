using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowKudos
{
    public partial class Form1 : Form
    {
        private string filePath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (file.ShowDialog() == DialogResult.OK)
            {
                filePath = file.FileName;
                textBox1.Text = filePath;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Choose a file first please.");
                return;
            }
            List<XmlParser.Class.Programmer> prog = XmlParser.Util.GetProgrammersFromXmlFile(filePath);
             
            foreach(var p in  prog.OrderByDescending(m => m.currentKudus).ToList())
                txtRes.Text += p.name + "\t" + p.currentKudus + Environment.NewLine;
                }
    }
}
