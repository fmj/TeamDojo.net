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
                button2_Click(sender, e);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Choose a file first please.");
                return;
            }
            txtRes.Text = "";
            List<XmlParser.Class.Programmer> prog = XmlParser.Util.GetProgrammersFromXmlFile(filePath);
            foreach (var p in prog)
            {
                p.currentKudus = 1;
                p.oldKudus = 1;
            }
            do
            {
                prog.ForEach(p => p.UpdateOldKudusFromCurrent());
                prog.ForEach(p => p.GetKudos(prog));
            } while (prog.Count(m => !m.Delta()) > 0);

            foreach (var p in prog.OrderByDescending(m => m.currentKudus).ToList())
                txtRes.Text += p.name + "\t" + p.currentKudus.ToString("f2") + Environment.NewLine;
        }
    }
}
