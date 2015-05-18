using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace ZdalnyScreemshotSerwer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Enabled = false;
            button5.Enabled = false;
            button10.Enabled = false;


            
            IPHostEntry adresIP = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var s in adresIP.AddressList)
            {
                string[] parts = s.ToString().Split('.');
                if (parts.Length == 4)
                {
                    comboBox1.Items.Add(s.ToString());
                }
            }
            //comboBox1.Items.Add("127.0.0.1");
        }

       
       
       
        List<string> listaStringow = new List<string>();

       
       
        public string ip;

        

        delegate void SetTextCallBack(string tekst);
        private void SetText(string tekst)
        {
            if (listBox1.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetText);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.listBox1.Items.Add(tekst);
            }
        }

        delegate void RemoveTextCallBack(int pozycja);
        private void RemoveText(int pozycja)
        {
            if (listBox1.InvokeRequired)
            {
                RemoveTextCallBack f = new RemoveTextCallBack(RemoveText);
                this.Invoke(f, new object[] { pozycja });
            }
            else
            {
                listBox1.Items.RemoveAt(pozycja);
            }
        }

       

        
        

       

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {




            IPEndPoint zdalnyIP = new IPEndPoint(IPAddress.Any, 0);
            UdpClient klient = new UdpClient(43210);
            while (true)
            {
                Byte[] bufor = klient.Receive(ref zdalnyIP);
                string dane = Encoding.ASCII.GetString(bufor);
                string[] cmd = dane.Split(new char[] { ':' });

                //MessageBox.Show(cmd[1]);

                if (cmd[1] == "BYE")
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                        if (listBox1.Items[i].ToString() == cmd[0])
                            this.RemoveText(i);

                    foreach (user u in listuser)
                    {
                        if (u.adres == cmd[0])
                        {
                            for (int i = 0; i < listBox1.Items.Count; i++)
                                if (listBox1.Items[i].ToString() == u.imienazwisko)
                                    this.RemoveText(i);
                        }
                    }
                        
                }
                if (cmd[1] == "LOGIN")
                {
                    bool znalazl = false;

                    foreach (user u in listuser)
                    {
                        if (u.index == cmd[4])
                        {
                            znalazl = true;
                        }
                    }

                    if (znalazl == false)
                    {
                        user nowy = new user(cmd[2], cmd[3], cmd[4], cmd[0]);
                        listuser.Add(nowy);
                        this.SetText(cmd[2] + " " + cmd[3]);
                    }
                    else
                    {
                        znalazl = false;
                    }
                }
               
                

                if (cmd[1] == "PROC")
                {
                    //MessageBox.Show("wiadomość od - " + cmd[0] + " - " + cmd[2]);
                    string[] tablica = cmd[2].Split(';');
                    
                    foreach (string proces in tablica)
                    {
                        listaStringow.Add(proces);
                    }
                }

                
                

            }
        }


       private  string adresIP = "none";

        private void takeaddress()
        {
            try
            {
                foreach (user u in listuser)
                {
                    if (u.imienazwisko == listBox1.Items[listBox1.SelectedIndex].ToString())
                        adresIP = u.adres;
                }
            }
            catch
            {
                adresIP = "none";
            }


        }
        private bool podglad = false;

        private void button1_Click(object sender, EventArgs e)
        {

            takeaddress();


            if (podglad == false)
            {

                if (adresIP == "none")
                {
                    MessageBox.Show("Nie wybrałeś użytkownika");
                }
                else
                {
                    timer1.Start();
                    label1.Text = "podgląd włączony";
                    adresIP = "none";
                }

            }
            else
            {
                timer1.Stop();
                label1.Text = "podgląd wyłączony";
                adresIP = "none";
                
            }


    }

        private void print()
        {
            try
            {
                
               
                   
               

                
                

                    TcpClient klient = new TcpClient(adresIP, 1978);
                    NetworkStream ns = klient.GetStream();
                    byte[] bufor = new byte[5];
                    bufor = Encoding.ASCII.GetBytes("##S##");
                    ns.Write(bufor, 0, bufor.Length);
                    if (backgroundWorker1.IsBusy == false)
                        backgroundWorker1.RunWorkerAsync();
                
                /*else
                   MessageBox.Show("Nie mozna teraz zrealizowac zrzutu ekranu");*/
            }
            catch
            {
                //MessageBox.Show("Nie zaznaczyłeś użytkownika");
            }
        }



        private void proces()
        {

            string adresIPp = "none";

            foreach (user u in listuser)
            {
                if (u.imienazwisko == listBox1.Items[listBox1.SelectedIndex].ToString())
                    adresIPp = u.adres;
            }

            if (adresIPp == "none")
            {
                MessageBox.Show("Nie wybrałeś użytkownika");
            }
            else
            {


                try
                {

                    TcpClient klient = new TcpClient(adresIPp, 1978);
                    NetworkStream ns = klient.GetStream();
                    byte[] bufor = new byte[5];
                    bufor = Encoding.ASCII.GetBytes("##P##");
                    ns.Write(bufor, 0, bufor.Length);
                    timer2.Start();
                }
                catch
                {
                    // MessageBox.Show("Nie zaznaczyłeś użytkownika");
                }
            }
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
                TcpListener serwer2 = new TcpListener(IPAddress.Parse(ip), 10000);
                //tutaj port 1000


                serwer2.Start();
                TcpClient klient2 = serwer2.AcceptTcpClient();
                NetworkStream ns = klient2.GetStream();
                byte[] obrazByte;
                using (BinaryReader odczytObrazu = new BinaryReader(ns))
                {
                    int rozmiarObrazu = odczytObrazu.ReadInt32();
                    obrazByte = odczytObrazu.ReadBytes(rozmiarObrazu);
                }
                using (MemoryStream ms = new MemoryStream(obrazByte))
                {
                    Image obraz = Image.FromStream(ms);
                    pictureBox1.Image = obraz;
                }
                serwer2.Stop();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            print();
        }

        

        List<user> listuser = new List<user>();

       

       

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (listaStringow.Count >0 )
            {
                listBox2.Items.Clear();
                foreach(string proces in listaStringow){
                    listBox2.Items.Add(proces);
                }
                listaStringow.Clear();
                timer2.Stop();
            }
        }

       

       

        private void button5_Click(object sender, EventArgs e)
        {
            proces();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool ifon = false;

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (ifon == false)
            {
                try
                {
                    ip = comboBox1.SelectedItem.ToString();
                    backgroundWorker2.RunWorkerAsync();
                   
                    l_stan.Text = "Serwer włączony";
                    button1.Enabled = true;
                    button5.Enabled = true;
                    button10.Enabled = true;

                    ifon = true;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Wybierz adres IP serwera");
                }
            }
            else
            {
                if (backgroundWorker2.IsBusy)
                {
//TO trzeba ogarnac!
                    
                   backgroundWorker2.CancelAsync();
                }
                try
                {
                    timer1.Stop();
                    
                }
                catch
                {

                } try
                {
                    
                    timer2.Stop();
                }
                catch
                {

                }
                l_stan.Text = "Serwer wyłączony";
                button1.Enabled = false;
                button5.Enabled = false;
                button10.Enabled = false;
                ifon = false;

            }
            

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        

        

        

        private void button10_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

       

        public void delay(int sekundy)
        {
            for (int i = 0; i < sekundy * 2000000; i++)
            {
                Application.DoEvents(); // rekakcja na guzik
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
