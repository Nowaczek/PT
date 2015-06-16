using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Activity_Monitor_Client;
using NDde.Client;

namespace PTKlient
{
    public partial class PTKlient : Form
    {
        bool logowanie = true;
        string localIP;
        IPAddress serverIP;
        int serverPort;
        int serwerKomendPort = 1978;
        Bitmap obraz;
        Browsers przegladarka = new Browsers();
        public PTKlient()
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

            sendUDP(localIP + ":LOGIN:" + "Nowaczek:" + "Nowaczek:" + "106");

            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();
            timer1.Start();
        }



        private void sendUDP(string wiadomosc)
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
            while (true)
            {
                sendUDP(localIP + ":URL:" + przegladarka.GetBrowserFirefox());

                try
                {
                    TcpClient klientKomend = serwer.AcceptTcpClient();
                    NetworkStream ns = klientKomend.GetStream();
                    Byte[] bufor = new Byte[100];
                    int odczyt = ns.Read(bufor, 0, bufor.Length);
                    String s = Encoding.ASCII.GetString(bufor);
                    string message = Encoding.ASCII.GetString(bufor);
                    
                    if (message.Contains("##S##"))
                    {
                        obraz = zrobScreena();
                        MemoryStream ms = new MemoryStream();
                        obraz.Save(ms, ImageFormat.Jpeg);
                        byte[] obrazByte = ms.GetBuffer();
                        ms.Close();
                        try
                        {
                            TcpClient klient2 = new TcpClient(serverIP.ToString(), serverPort);
                            NetworkStream ns2 = klient2.GetStream();
                            using (BinaryWriter bw = new BinaryWriter(ns2))
                            {
                                bw.Write((int)obrazByte.Length);
                                bw.Write(obrazByte);
                            }
                        }
                        catch { }
                    }

                    if (message.Contains("##P##"))
                    {
                        string[] proc = Processes.getProcesses();
                        string wiadomoscudp = String.Empty;
                        foreach (string p in proc)
                        {
                            wiadomoscudp += p + ";";
                        }
                        sendUDP(localIP + ":PROC:" + wiadomoscudp);
                    }

                    if (message.Contains("##PB##"))
                    {
                        string proces = message.Substring(6);
                        while (proces.Contains("#"))
                        {
                            proces = proces.Substring(0, proces.Length - 1);
                        }
                        foreach (var process in Process.GetProcessesByName(proces))
                        {
                            process.Kill();
                        }
                        
                    }
                    
                }
                catch { }
            }
        }

        private Bitmap zrobScreena()
        {
            Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            Graphics screenshot = Graphics.FromImage(screen);
            screenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            screen = zmienRozmiar(screen, new Size(800, 450));
            return screen;
        }


        public Bitmap zmienRozmiar(Bitmap imgToResize, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            }
            return bitmap;
        }
        private void buttonRozlacz_Click(object sender, EventArgs e)
        {
            sendUDP(localIP + ":BYE:");
            backgroundWorker1.CancelAsync();
        } 
        private void buttonWyslijWiadomosc_Click(object sender, EventArgs e)
        {
            if (textBoxWiadomosc.Text == "")
            {
                MessageBox.Show("Nie wpisano wiadomości");
                return;
            }
            sendUDP(localIP + ":STRING:" + textBoxWiadomosc.Text);
        }
        public string GetBrowserFirefox()
        {
            try
            {
                DdeClient dde = new DdeClient("Firefox", "WWW_GetWindowInfo");
                dde.Connect();
                string url = dde.Request("URL", int.MaxValue);
                string[] text = url.Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
                dde.Disconnect();
                return text[0].Substring(1);
            }
            catch
            {
                return null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!logowanie)
                sendUDP(localIP + ":URL:" + przegladarka.GetBrowserFirefox());
            else
                logowanie = false;
        }


    }
}