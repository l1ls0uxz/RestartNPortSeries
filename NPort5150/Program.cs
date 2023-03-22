using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NPort5150
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a new telnet connection to hostname "192.168.3.37" on port "23"
            TelnetConnection tc = new TelnetConnection("192.168.3.37", 23);

            //login with password "moxa", using a timeout of 100ms, and show server output
            string s = tc.Login("moxa" + Environment.NewLine, 1000);

            Console.Write(s);

            // server output should end with "$" or ">", otherwise the connection failed
            string prompt = s.TrimEnd();
            prompt = s.Substring(prompt.Length - 1, 1);
            if (prompt != "$" && prompt != ">" && prompt != ":")
                throw new Exception("Connection failed");

            prompt = "";
            tc.WriteLine("s" + Environment.NewLine);
            Thread.Sleep(500);
            tc.WriteLine("y" + Environment.NewLine);

            /*
            // while connected
            //while (tc.IsConnected && prompt.Trim() != "exit")
            //    {
            //        // display server output
            //        Console.Write(tc.Read());
            //    // send client input to server
            //    prompt = Console.ReadLine();
            //        tc.WriteLine(prompt);
            //        // display server output
            //        Console.Write(tc.Read());
            //    }
            //    Console.WriteLine("***DISCONNECTED");
            //    Console.ReadLine();
            */
        }
    }
}
