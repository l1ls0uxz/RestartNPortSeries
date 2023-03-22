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
            //create a new telnet connection to hostname "192.168.3.27" on port "23"
            TelnetConnection ta = new TelnetConnection("192.168.3.27", 23);

            //create a new telnet connection to hostname "192.168.3.37" on port "23"
            TelnetConnection tb = new TelnetConnection("192.168.3.37", 23);

            //create a new telnet connection to hostname "192.168.3.13" on port "23"
            TelnetConnection tc = new TelnetConnection("192.168.3.13", 23);

            //create a new telnet connection to hostname "192.168.3.14" on port "23"
            TelnetConnection td = new TelnetConnection("192.168.3.14", 23);

            //create a new telnet connection to hostname "192.168.3.15" on port "23"
            TelnetConnection te = new TelnetConnection("192.168.3.15", 23);

            //create a new telnet connection to hostname "192.168.3.17" on port "23"
            TelnetConnection tf = new TelnetConnection("192.168.3.17", 23);

            //login with password "moxa", using a timeout of 100ms, and show server output
            string  s = ta.Login("moxa" + Environment.NewLine, 900);
                    s = tb.Login("moxa" + Environment.NewLine, 900);
                    s = tc.Login("moxa" + Environment.NewLine, 900);
                    s = td.Login("moxa" + Environment.NewLine, 900);
                    s = te.Login("moxa" + Environment.NewLine, 900);
                    s = tf.Login("moxa" + Environment.NewLine, 900);

            Console.Write(s);

            // server output should end with "$" or ">", otherwise the connection failed
            string prompt = s.TrimEnd();
            prompt = s.Substring(prompt.Length - 1, 1);
            if (prompt != "$" && prompt != ">" && prompt != ":")
                throw new Exception("Connection failed");

            prompt = "";

            // ta
            ta.WriteLine("s" + Environment.NewLine);
            Thread.Sleep(500);
            ta.WriteLine("y" + Environment.NewLine);
            // tb
            tb.WriteLine("s" + Environment.NewLine);
            Thread.Sleep(500);
            tb.WriteLine("y" + Environment.NewLine);
            // tc
            tc.WriteLine("s" + Environment.NewLine);
            Thread.Sleep(500);
            tc.WriteLine("y" + Environment.NewLine);
            // td
            td.WriteLine("s" + Environment.NewLine);
            Thread.Sleep(500);
            td.WriteLine("y" + Environment.NewLine);
            // te
            te.WriteLine("s" + Environment.NewLine);
            Thread.Sleep(500);
            te.WriteLine("y" + Environment.NewLine);
            // tf
            tf.WriteLine("s" + Environment.NewLine);
            Thread.Sleep(500);
            tf.WriteLine("y" + Environment.NewLine);

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
