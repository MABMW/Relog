using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircularProgressBar;
using System.Speech.Synthesis;
using System.Threading;
namespace Relog
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }


        //evento Tick de contador de tiempo
        private void timer1_Tick(object sender, EventArgs e)
        {
            //darle el formato para mostrar la hora y la fecha
            label1.Text = DateTime.Now.ToString("hh:mm");
            label2.Text = DateTime.Now.ToString("ss");
            lblfecha.Text = DateTime.Now.ToString("M-d");
            lblmes.Text = DateTime.Now.ToString("ddddd");

            circularProgressBar1.Value++;
            /*
             * el siguiente if nos sirve para reiniciar nuestro 
             * circularprogressbar. ya que hay que configurar el
             * maximo del  value en 60 ya que son los segundos los que se cuentan
             */
            if (circularProgressBar1.Value.Equals(60))
            {
                circularProgressBar1.Value = 0;
            }

            //este if sirve para configurar si es turno matutino o vespertino
            if (DateTime.Now.Hour>=12)
            {
                DesperMatu.Text = "PM";

            }
            else if(DateTime.Now.Hour<=11){
                DesperMatu.Text = "AM";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //establecer el valor del cicularprogressbar  igual que los segundos
            circularProgressBar1.Value = DateTime.Now.Second;
        }

        //metodo de configuracion de voz
        private void hablar(object text)
        {
            SpeechSynthesizer voz = new SpeechSynthesizer();
            voz.SetOutputToDefaultAudioDevice();
            voz.Rate = -3;
            voz.Volume = 100;
            voz.Speak(text.ToString());
        }

        //evento para decir la hora y los minutos actuales
        private void button1_Click(object sender, EventArgs e)
        {
            string hor = DateTime.Now.ToString("h:");
            string min = DateTime.Now.ToString("m:");
            Thread tar = new Thread(new ParameterizedThreadStart(hablar));
            tar.Start("La hora es!" + hor+"horas con"+min+"minutos."+ DesperMatu.Text);

        }

        //evento click para decir la fecha
        private void button2_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("d:");
            string fecha1 = DateTime.Now.ToString("MMMM:");
            string a = DateTime.Now.ToString("yyyy");
            Thread tar = new Thread(new ParameterizedThreadStart(hablar));
            tar.Start("Hoy es!" + lblmes.Text + fecha+"de"+fecha1+"de"+a);
        }

        /*
         * Librerias externas ocupadas es este proyecto: CircularProgressbar y MetroFramework
         */
    }
}
