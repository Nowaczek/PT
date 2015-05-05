using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Activity_Monitor_Client;

namespace PTKlient
{
    public partial class Form1 : Form
    {
        string localIP;
        IPAddress serverIP;
        int serverPort;
        int serwerKomendPort = 1978;
        Bitmap obraz;
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

            WyslijWiadomoscUDP(localIP + ":LOGIN:" + "Nowaczek:" + "Nowaczek:" + "106");//+ tb_imie.Text + ":" + tb_nazwisko.Text + ":" + tb_index.Text);

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
                            TcpClient klient2 = new TcpClient(serverIP.ToString(), serverPort);//
                            NetworkStream ns2 = klient2.GetStream();
                            //this.SetText("Wysyłanie zrzutu ...");
                            using (BinaryWriter bw = new BinaryWriter(ns2))
                            {
                                bw.Write((int)obrazByte.Length);
                                bw.Write(obrazByte);
                            }
                            //this.SetText("Zrzut ekranu przesłany");
                        }
                        catch { }
                    }

                    if (wiadomosc.Contains("##P##"))
                    {
                        string[] proc = Processes.getProcesses();
                        string wiadomoscudp = String.Empty;
                        foreach (string p in proc)
                        {
                            wiadomoscudp += p + ";";
                        }
                        WyslijWiadomoscUDP(localIP + ":PROC:" + wiadomoscudp);
                    }
                    if (wiadomosc.Contains("##PB##"))
                    {
                        string name = wiadomosc + "#";
                        name = wyciagnij(name, "##PB##", "##END##");

                        foreach (var process in Process.GetProcessesByName(name))
                        {
                            process.Kill();
                        }
                    }
                    
                }
                catch { }
            }
        }

        private Bitmap wykonajScreenshot()
        {
            Bitmap bitmapa = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            Graphics screenshot = Graphics.FromImage(bitmapa);
            screenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            bitmapa = zmien(bitmapa, new Size(800, 450));
            return bitmapa;
        }


        public Bitmap zmien(Bitmap imgToResize, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            }
            return bitmap;
        }



        public string wyciagnij(string source, string poczatek, string koniec)
        {
            try
            {
                string x;

                int indexpoczatek = (source.IndexOf(poczatek)) + poczatek.Length;
                x = source.Substring(indexpoczatek, source.Length - indexpoczatek);

                int indexkoniec = x.IndexOf(koniec);

                x = x.Substring(0, indexkoniec);

                return x;
            }
            catch
            {
                return "0";
            }
        }
    }
}