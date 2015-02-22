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

namespace VerificareParola
{
    public partial class Form1 : Form
    {
        int punctaj = 0;
        int[] verificare = new int[10];
        
        
        string path;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Hide();
            pictureBox2.Hide();
        }

        string[] parole;
        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName ;
            textBox2.Text = path;
            
            
            
            
        }
        public void literaM(string cuv)
    {
        verificare[0] = 0;
            for(int i = 0;i<cuv.Length;i++)
            {
                if(cuv[i]<=90 && cuv[i]>=65)
                {
                    verificare[0]++;
                }
            }
    }
        public void cifre(string cuv)
        {
            verificare[2] = 0;
            for (int i = 0; i < cuv.Length; i++)
            {
                if (cuv[i] <= 57 && cuv[i] >= 48)
                {
                    verificare[2]++;
                }
            }
        }
        public void speciale(string cuv)
        {
            verificare[3] = 0;
            for (int i = 0; i < cuv.Length; i++)
            {
                if ((cuv[i] >= 32 && cuv[i] <= 47) || (cuv[i] >= 58 && cuv[i] <= 64) || (cuv[i] >= 91 && cuv[i] <= 96) || (cuv[i] >= 123 && cuv[i] <= 126)) 
                {
                    verificare[3]++;
                }
            }
        }
        
        public void literam(string cuv)
        {
            verificare[1] = 0; ;
            for (int i = 0; i < cuv.Length; i++)
            {
                if (cuv[i] <= 122 && cuv[i] >= 97)
                {
                    verificare[1]++;
                }
            }
        }
        public void puncta()
        {
            if (punctaj < 250)
            {
                label1.Text = "Parola nu este sigura!";
                pictureBox2.Show();
                pictureBox1.Hide();
            }
            else if (punctaj < 275 && punctaj>=250)
            {
                label1.Text = "Parola este slaba!";
                pictureBox2.Show();
                pictureBox1.Hide();
            }
            else if (punctaj >= 325)
            {
                label1.Text = "Parola este foarte sigura!";
                pictureBox1.Show();
                pictureBox2.Hide();
            }
            else if (punctaj < 300 && punctaj >=275)
            {
                label1.Text = "Parola este acceptabila!";
                pictureBox1.Show();
                pictureBox2.Hide();
            }
            else if (punctaj < 325 && punctaj >=300)
            {
                label1.Text = "Parola este sigura!";
                pictureBox1.Show();
                pictureBox2.Hide();
            }

        }
        
        public void pun()
        {
            int i;
            if(verificare[0] == 1 )
            {
                punctaj = punctaj + 50;
            }else if(verificare[0] >1)
            {
                punctaj = punctaj + 10;
                for(i = 1;i<verificare[0];i++)
                {
                    
                    {
                    punctaj = punctaj + punctaj/8;
                    }
                }
            }
            if (verificare[1] == 1)
            {
                punctaj = punctaj + 50;
            }
            else if (verificare[1] > 1)
            {
                punctaj = punctaj + 10;
                for (i = 1; i < verificare[1]; i++)
                {
                    
                    {
                        punctaj = punctaj + punctaj / 8;
                    }
                }
            }
            if (verificare[2] == 1)
            {
                punctaj = punctaj + 50;
            }
            else if (verificare[2] > 1)
            {
                punctaj = punctaj + 10;
                for (i = 1; i < verificare[2]; i++)
                {
                     
                    {
                    punctaj = punctaj + punctaj/8;
                    }
                }
            }
            if (verificare[3] == 1)
            {
                punctaj = punctaj + 50;
            }
            else if (verificare[3] > 1)
            {
                punctaj = punctaj + 10;
                for (i = 1; i < verificare[3]; i++)
                {
                    if(punctaj/8 <0)
                    {
                        punctaj = punctaj - punctaj / 8;
                    }
                    else
                    {
                        punctaj = punctaj + punctaj / 8;
                    }
                }
            }

            
            
        }
        public void consecutive(string cuv)
        {
            bool ok = false;
            for(int i = 0;i<cuv.Length-2;i++)
            {
                if (cuv[i] <= 122 && cuv[i] >= 97 && cuv[i + 1] <= 122 && cuv[i + 1] >= 97 && cuv[i + 2] <= 122 && cuv[i + 2] >= 97)
                {
                    ok = true;
                }
                
                
                if (cuv[i] <= 57 && cuv[i] >= 48 && cuv[i+1] <= 57 && cuv[i+1] >= 48 && cuv[i+2] <= 57 && cuv[i+2] >= 48)
                {
                    ok = true;
                }
                if(cuv[i]<=90 && cuv[i]>=65 && cuv[i+1]<=90 && cuv[i+1]>=65 && cuv[i+2]<=90 && cuv[i+2]>=65)
                {
                    ok = true;
                }
                if (
((cuv[i] >= 32 && cuv[i] <= 47) && (cuv[i + 1] >= 32 && cuv[i + 1] <= 47) && (cuv[i + 2] >= 32 && cuv[i + 2] <= 47)) 
||
((cuv[i] >= 58 && cuv[i] <= 64) && (cuv[i + 1] >= 58 && cuv[i + 1] <= 64) && (cuv[i + 2] >= 58 && cuv[i + 2] <= 64))
||
((cuv[i] >= 91 && cuv[i] <= 96) && (cuv[i + 1] >= 91 && cuv[i + 1] <= 96) && (cuv[i + 2] >= 91 && cuv[i + 2] <= 96))
||
((cuv[i] >= 123 && cuv[i] <= 126) && (cuv[i+1] >= 123 && cuv[i+1] <= 126) && (cuv[i+2] >= 123 && cuv[i+2] <= 126))
)
                {
                    ok = true;
                }

            }
            if(ok == true)
            {
                punctaj = punctaj - punctaj/8;
            }
        }
        public void consecutivecar(string cuv)
        {
            bool ok = false;
            for (int i = 0; i < cuv.Length - 2; i++)
            {
                if(cuv[i+2] == cuv[i]+2 && cuv[i+1] == cuv[i]+1)
                {
                    ok = true;
                    
                }
                
            }
            if(ok == true)
            {
                punctaj = punctaj - punctaj / 8;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            punctaj = 100;
            pictureBox1.Hide();
            pictureBox2.Hide();
            label1.Text = "";
            string cuv = textBox1.Text;
            if (path == null)
            {
                MessageBox.Show("Selectati fisierul txt cu parolele !");
            }
            else
            {
                string[] parole = System.IO.File.ReadAllLines(path);


                string cuv2 = cuv.ToLower();
                for (long i = 0; i < parole.Length; i++)
                {
                    if (parole[i].CompareTo(cuv2) == 0)
                    {
                        punctaj = punctaj - 50;
                    }
                }
                
                
                 for (long i = 0; i < parole.Length; i++)
                 {
                     if (cuv2.Contains(parole[i]) == true)
                     {
                         punctaj = punctaj - 25;
                     }
                 }
                 
                literam(cuv);
                cifre(cuv);
                speciale(cuv);
                literaM(cuv);
                consecutivecar(cuv);
                consecutive(cuv);
                
                pun();
                puncta();
                if (cuv.Length < 10)
                {
                    punctaj = punctaj - 1000;
                    label1.Text = "Parola este prea scurta!";
                    label5.Text = "";
                    
                }
                else{
                label5.Text = punctaj.ToString();
                punctaj = punctaj + 25;
                }
            }
            if(cuv == "")
            {
                pictureBox1.Hide();
                pictureBox2.Hide();
                label1.Text = "";
                label5.Text = "";

            }
            
        }
        
    }
}
