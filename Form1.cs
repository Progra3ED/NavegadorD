using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void Guardar(string fileName, string texto)
        {
          
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);          
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);          
            writer.Close();
        }

        private void buttonIr_Click(object sender, EventArgs e)
        {
            string uri = "";
            if (comboBox1.Text != null)
                uri = comboBox1.Text;
            else if (comboBox1.SelectedItem != null)    
                uri = comboBox1.SelectedItem.ToString();

            if (!uri.Contains("."))
                uri = "https://www.google.com/search?q=" + uri;

            if (!uri.Contains("https://"))
                uri = "https://" + uri;

            


            webBrowser1.Navigate(new Uri(uri));

            int yaEsta = 0;
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items[i].ToString() == uri)
                    yaEsta++;
            }

            if (yaEsta == 0)
            {
                comboBox1.Items.Add(uri);
                Guardar("Historial.txt", uri);
            }
        }

        private void siguienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void anteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navegarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void Leer(string fileName)
        {
                        
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {                
                comboBox1.Items.Add(reader.ReadLine());
            }

            reader.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Leer("Historial.txt");
        }
    }
}
