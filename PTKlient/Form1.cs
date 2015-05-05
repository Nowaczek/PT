using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTKlient
{
    public partial class Form1 : Form
    {
        string localIP;
        IPAddress serverIP;
        int serverPort;
        int serwerKomendPort = 1978;
        public Form1()
        {
            InitializeComponent();
            IPHostEntry adresIP = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var s in adresIP.AddressList)
            {
                string[] parts = s.ToString().Split('.');
                if (parts.Length == 4)
                {
                    comboBoxLocalIP.Items.Add(s.ToString());
                }
            }
        }

        private void buttonPołącz_Click(object sender, EventArgs e)
        {
            localIP = comboBoxLocalIP.SelectedItem.ToString();
            serverIP = IPAddress.Parse(textBoxserverIP.Text);
            serverPort = 10000;

            WyslijWiadomoscUDP(localIP + ":LOGIN:" + "Piotr:" + "Nowak:" + "106");//+ tb_imie.Text + ":" + tb_nazwisko.Text + ":" + tb_index.Text);

            //notifyIcon1.Visible = true;
            //notifyIcon1.Text = "Program Minimalizujący";
            //notifyIcon1.Icon = this.Icon;
            //notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            //this.ShowInTaskbar = false;
            //this.Visible = false;

            //timer1.Start(); // wysyla strony www
            backgroundWorker1.RunWorkerAsync(); // oczekuje na komunikaty
        }



        private void WyslijWiadomoscUDP(string wiadomosc)
        {
            UdpClient klient = new UdpClient(serverIP.ToString(), 43210);
            byte[] bufor = Encoding.ASCII.GetBytes(wiadomosc);
            klient.Send(bufor, bufor.Length);
            klient.Close();
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            TcpListener serwer = new TcpListener(IPAddress.Parse(localIP), serwerKomendPort);
            serwer.Start();
            //this.SetText("Oczekuje na komendy...");
            while (true)
            {
                try
                {
                    TcpClient klientKomend = serwer.AcceptTcpClient();
                    //this.SetText("Otrzymano komende.");
                    NetworkStream ns = klientKomend.GetStream();
                    Byte[] bufor = new Byte[100];
                    int odczyt = ns.Read(bufor, 0, bufor.Length);
                    String s = Encoding.ASCII.GetString(bufor);
                    string wiadomosc = Encoding.ASCII.GetString(bufor);
                    /*
                    if (wiadomosc.Contains("##S##"))
                    {
                        //this.SetText("Zrzut ekranu w trakcie wykonywania ...");
                        obraz = wykonajScreenshot();
                        MemoryStream ms = new MemoryStream();
                        obraz.Save(ms, ImageFormat.Jpeg);
                        byte[] obrazByte = ms.GetBuffer();
                        ms.Close();
                        try
                        {
                            TcpClient klient2 = new TcpClient(serwerDanychIP.ToString(), serwerDanychPort);//
                            NetworkStream ns2 = klient2.GetStream();
                            //this.SetText("Wysyłanie zrzutu ...");
                            using (BinaryWriter bw = new BinaryWriter(ns2))
                            {
                                bw.Write((int)obrazByte.Length);
                                bw.Write(obrazByte);
                            }
                            //this.SetText("Zrzut ekranu przesłany");
                        }

                    }*/
                    
                }
                catch { }
            }
        }
    }
}