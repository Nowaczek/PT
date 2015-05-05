using System;
using System.Diagnostics;

namespace Activity_Monitor_Client
{
    class Processes
    {
        //A method that takes an array of system processes.
        public static String[] getProcesses()
        {
            int n;
            int startIndex, endIndex;
            n = Process.GetProcesses().Length;              //Take amounts of processes in the system

            Process[] myProcesses = new Process[n];         //Creating an array of size quantities of processes in the system

            myProcesses = Process.GetProcesses();           //Rewrite into array processes of the system

            String[] processes = new String[n];
            for (int i = 0; i < n; i++)
            {
                startIndex = myProcesses[i].ToString().IndexOf('(');
                endIndex = myProcesses[i].ToString().IndexOf(')');

                processes[i] = myProcesses[i].ToString().Substring(startIndex + 1, endIndex - startIndex - 1);
            }

            return processes;
        }

        public void sendProcesses()
        {


            //String[] proces = new String[Process.GetProcesses().Length];
            //proces = getProcesses();

            ////byte[] procesArray = Encoding.UTF8.GetBytes("Royale With Cheese");

            //TcpListener mytcpl = new TcpListener(5000);
            //mytcpl.Start();
            //Socket mySocket = mytcpl.AcceptSocket();// 
            //NetworkStream myns = new NetworkStream(mySocket);//   
            //BinaryWriter mysw = new BinaryWriter(myns);
            //mySocket.SendPacketsAsync(proces);

        }

    }
}