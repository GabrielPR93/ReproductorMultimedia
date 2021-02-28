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

namespace Prueba
{
    public partial class Form1 : Form
    {
        private List<Image> TodasImagenes= new List<Image>();
        int cont = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Reproductor1_Click(object sender, EventArgs e)
        {
          
            if (reproductor1.FlagIcono)
            {
            timer1.Enabled = false;
            reproductor1.FlagIcono = !reproductor1.FlagIcono;

            }
            else
            {
                timer1.Enabled = true;
                reproductor1.FlagIcono = !reproductor1.FlagIcono;
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    FileInfo[] archivos;
                    Image[] imagenes;
                  
                    string path = folderBrowserDialog.SelectedPath;
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    archivos = directoryInfo.GetFiles();

                    foreach (FileInfo item in archivos)
                    {
                        try
                        {
                            Image img = Image.FromFile(item.FullName);
                            TodasImagenes.Add(img);

                        }
                        catch (OutOfMemoryException x)
                        {
                            Console.WriteLine(x.Message);
                            
                        }
                     
                    }
                    
                }
            }
        }
        
        private void controlImagenes()
        {
            if (cont>=TodasImagenes.Count)
            {
                cont = 0;
            }
            else if(cont>0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;//Ajusta el tamaño de la imagen
                pictureBox1.Image = TodasImagenes[cont];
            }
            cont++;
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
         
            reproductor1.Yy++;
            controlImagenes();
          

        }
        private void Reproductor1_DesbordaTiempo(object sender, EventArgs e)
        {
            reproductor1.Xx++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
