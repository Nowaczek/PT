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

namespace PTSerwer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            zainicjuj();
            
        }


         List<string> listurl = new List<string>();
         List<user> listuser = new List<user>();
         List<string> listaStringow = new List<string>();
         public string ip;
         private string adresIP = "none";
         private bool podglad = false;
         private bool pobierzURL = false;
         public string user;
         public string urlblock;
       
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


        private void zainicjuj()
        {
             List<user> listuser = new List<user>();
            button1.Enabled = false;
            button5.Enabled = false;
            button10.Enabled = false;
            button13.Enabled = false;
            button9.Enabled = false;
            button11.Enabled = false;
            IPHostEntry adresIP = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var s in adresIP.AddressList)
            {
                string[] parts = s.ToString().Split('.');
                if (parts.Length == 4)
                {
                    comboBox1.Items.Add(s.ToString());
                }
            }
            comboBox1.Items.Add("127.0.0.1");
        }

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
                
            }


        }

         public void delay(int sekundy)
         {
             for (int i = 0; i < sekundy * 2000000; i++)
             {
                 Application.DoEvents(); // rekakcja na guzik
             }
         }

        private void print()
        {
            takeaddress();




            if (adresIP == "none")
            {
                MessageBox.Show("Nie wybrałeś użytkownika");
                timer_print.Stop();
            }
            else
            {

                label1.Text = "podgląd włączony";
                


                try
                {


                    TcpClient klient = new TcpClient(adresIP, 1978);
                    NetworkStream ns = klient.GetStream();
                    byte[] bufor = new byte[5];
                    bufor = Encoding.ASCII.GetBytes("##S##");
                    ns.Write(bufor, 0, bufor.Length);
                    if (odbierzobraz.IsBusy == false)
                        odbierzobraz.RunWorkerAsync();
                    //czysz adres
                    adresIP = "none";
                    /*else
                           MessageBox.Show("Nie mozna teraz zrealizowac zrzutu ekranu");*/
                }
                catch
                {
                    MessageBox.Show("print error");
                }
            }
        }

        private void proces()
        {

            takeaddress();

            if (adresIP == "none")
            {
                MessageBox.Show("Nie wybrałeś użytkownika");
            }
            else
            {


                try
                {

                    TcpClient klient = new TcpClient(adresIP, 1978);
                    NetworkStream ns = klient.GetStream();
                    byte[] bufor = new byte[5];
                    bufor = Encoding.ASCII.GetBytes("##P##");
                    ns.Write(bufor, 0, bufor.Length);
                    timer_proces.Start();
                }
                catch
                {
                    // MessageBox.Show("Nie zaznaczyłeś użytkownika");
                }
            }
        }

        private void processkill()
        {
            try
            {
                string adresIP = String.Empty;

                foreach (user u in listuser)
                {
                    if (u.imienazwisko == listBox1.Items[listBox1.SelectedIndex].ToString())
                        adresIP = u.adres;
                }

                TcpClient klient = new TcpClient(adresIP, 1978);
                NetworkStream ns = klient.GetStream();
                byte[] bufor = new byte[100];
                bufor = Encoding.ASCII.GetBytes("##PB##" + listBox2.Items[listBox2.SelectedIndex].ToString() + "##END##");
                ns.Write(bufor, 0, bufor.Length);
            }
            catch
            {
            }
        }

        private void SetTextURL(string tekst)
        {
            if (listBox4.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetTextURL);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.listBox4.Items.Add(tekst);
            }
        }



        private void odbierzobraz_DoWork(object sender, DoWorkEventArgs e)
        {
            TcpListener serwer2 = new TcpListener(IPAddress.Parse(ip), 10000);
            //tutaj port 10000


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

        private void nasluchiwanie_DoWork(object sender, DoWorkEventArgs e)
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
                   string[] tablica = cmd[2].Split(';');

                    foreach (string proces in tablica)
                    {
                        listaStringow.Add(proces);
                    }
                }
                if (cmd[1] == "STRING")
                {
                    MessageBox.Show("wiadomość od - " + cmd[0] + " - " + cmd[2]);
                }
                if (cmd[1] == "URL")
                {

                    if (pobierzURL)
                    {
                        string adresIP = String.Empty;
                        string nick = String.Empty;

                        foreach (user u in listuser)
                        {
                            if (u.adres == cmd[0])
                            {
                                nick = u.imienazwisko;
                            }
                        }
                        try
                        {

                            DateTime saveNow = DateTime.Now;
                            this.SetTextURL(saveNow + " - " + nick + " - " + cmd[2] + cmd[3]);

                        }
                        catch
                        {

                        }
                    }

                    try
                    {
                        
                        string url = cmd[2] + cmd[3];
                        string name = String.Empty;

                        foreach (string u in listurl)
                        {
                            if (url.Contains(u))
                            {
                                foreach (user osoba in listuser)
                                {
                                    if (osoba.adres == cmd[0])
                                        name = osoba.imienazwisko;
                                    else
                                        name = cmd[0];
                                }

                                if (user != name )
                                {
                                    MessageBox.Show("Użytkownik - " + name + " korzysta z niedozwolonej strony " + cmd[2] + cmd[3], "Uwaga");
                                    user = name;
                                    
                                }
                            }
                        }
                    }
                    catch { }
                }




            }
        }

        private void Serwer_on_Click(object sender, EventArgs e)
        {
            
                try
                {
                    ip = comboBox1.SelectedItem.ToString();
                    nasluchiwanie.RunWorkerAsync();

                    l_stan.Text = "Serwer włączony";
                    button1.Enabled = true;
                    button5.Enabled = true;
                    button10.Enabled = true;
                    Serwer_on.Enabled = false;
                    button13.Enabled = true;
                    button9.Enabled = true;
                    button11.Enabled = true;

                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Wybierz adres IP serwera");
                }
            
           

            
        }

        private void timer_print_Tick(object sender, EventArgs e)
        {
            print();
        }

        private void timer_proces_Tick(object sender, EventArgs e)
        {
            if (listaStringow.Count > 0)
            {
                listBox2.Items.Clear();
                foreach (string proces in listaStringow)
                {
                    listBox2.Items.Add(proces);
                }
                listaStringow.Clear();
                timer_proces.Stop();
            }
        }

        private void Stream_ON_OFF_Click(object sender, EventArgs e)
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
                    timer_print.Start();
                    label1.Text = "podgląd włączony";
                    adresIP = "none";
                    podglad = true;
                }

            }
            else
            {
                timer_print.Stop();
                label1.Text = "podgląd wyłączony";
                adresIP = "none";
                podglad = false;
                pictureBox1.Image = null;

            }
        }

        private void pobierz_procesy_Click(object sender, EventArgs e)
        {
            proces();
        }

        private void wyczyszc_liste_procesow(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            if (pobierzURL == false)
            {
                pobierzURL = true;
                button9.Text = "Zakończ podgląd";
            }
            else
            {
                pobierzURL = false;
                button9.Text = "Rozpocznij podgląd";
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listurl.Add(tb_www.Text);
            listBox3.Items.Add(tb_www.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (string u in listurl)
            {
                if (u == listBox3.SelectedItem.ToString())
                {
                    listurl.Remove(listBox3.SelectedItem.ToString());
                    break;
                }
            }

            listBox3.Items.RemoveAt(listBox3.SelectedIndex);



        }

        private void button13_Click(object sender, EventArgs e)
        {
            processkill();
            delay(1);
            proces();
        }

        
    }
}
