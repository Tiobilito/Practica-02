using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Práctica_02
{
    public partial class Form1 : Form
    {
        string selectedfolder;

        public Form1()
        {
            InitializeComponent();
        }

        private string newName(string cad)
        {
            string newcad="";
            int numRan,i;
            Random rnd = new Random();
            for (i=0; i<cad.Length; i++)
            {
                if(cad[i]<123 && cad[i]>64)
                {
                    numRan = rnd.Next(65, 123);
                    newcad += Convert.ToChar(numRan);
                } else
                {
                    numRan = rnd.Next(48, 57);
                    newcad += Convert.ToChar(numRan);
                }
            }
            return newcad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] archives;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK) 
            { 
                selectedfolder = fbd.SelectedPath;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indice;
            string[] archivos;
            string Nombre;
            archivos = Directory.GetFiles(selectedfolder);
            for (int i = 0; i < archivos.Length; i++)
            {
                indice = archivos[i].LastIndexOf("\\") + 1;
                Nombre = archivos[i].Substring(indice);
                File.Copy(archivos[i], selectedfolder + Convert.ToChar(92) + newName(Path.GetFileNameWithoutExtension(Nombre)) + Path.GetExtension(archivos[i]));
            }
            archivos = Directory.GetDirectories(selectedfolder);
            for (int i = 0; i < archivos.Length; i++)
            {
                indice = archivos[i].LastIndexOf("\\") + 1;
                Nombre = archivos[i].Substring(indice);
                Directory.CreateDirectory(selectedfolder + Convert.ToChar(92) + newName(Nombre));
                richTextBox1.Text += Nombre + "\n";
            }
        }
    }
}
