using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema5_Ejer3
{
    public partial class Reproductor : UserControl
    {
        public Reproductor()
        {
            InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            lblTiempo.Text = xx + ":" + yy;


            if (FlagIcono)
            {
                btn.Image = Properties.Resources.pause;
               
            }
            else
            {
                btn.Image = Properties.Resources.play5;
                
            }


        }

     
        private bool flagIcono;

        [Category("Varios")]
        [Description("Cambia el icono del boton")]
        public bool FlagIcono
        {
            set
            {
                flagIcono = value;
                this.Refresh();
            }
            get
            {
                return flagIcono;
            }
        }


        private void Btn_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
            Refresh();

        }

        [Category("Tiempo")]
        [Description("restablece el valor de xx al llegar a 99")]

        private int xx;
        public int Xx
        {
            set
            {
             
                if (value>99 || value<0)
                {
                    xx = 0;
                    this.Refresh();

                }
                else
                {
                    xx = value;
                }
            }
            get
            {
                return xx;
            }
        }
        [Category("Accion")]
        [Description("Se lanza cuando yy supera 59")]
        public event System.EventHandler DesbordaTiempo;

        [Category("Tiempo")]
        [Description("cambia el valor de yy al llegar a 59")]

        private int yy;
        public int Yy
        {
            set
            {
              
                if (value > 59)
                {
                    yy = value % 60;
                    this.Refresh();

                    DesbordaTiempo?.Invoke(this,EventArgs.Empty);

                }else if (value<0)
                {
                    yy = 0;
                }
                else
                {
                    yy = value;
                }
                this.Refresh();
            }
            get
            {
                return yy;
            }
        }

       

    }
}
