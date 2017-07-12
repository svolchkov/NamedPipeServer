using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            StartServer();
            //Task.Delay(1000).Wait();


            ////Client
            //var client = new NamedPipeClientStream("PipesOfPiece");
            //client.Connect();
            //StreamReader reader = new StreamReader(client);
            //StreamWriter writer = new StreamWriter(client);

            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    if (String.IsNullOrEmpty(input)) break;
            //    writer.WriteLine(input);
            //    writer.Flush();
            //    Console.WriteLine(reader.ReadLine());
            //}
        }

        static void StartServer()
        {
            //Task.Factory.StartNew(() =>
            //{
                var server = new NamedPipeServerStream("PipesOfPeace");
                //server.WaitForConnection();
                while (true)
                {
                    server.WaitForConnection();
                    List<string> lines = new List<string>();

                StreamReader reader = new StreamReader(server);
                
                    while (!reader.EndOfStream)
                    {
                        lines.Add(reader.ReadLine());
                    }
                
                //StreamWriter writer = new StreamWriter(server);
                //    var line = reader.Read();
                //writer.WriteLine(String.Join("", line.Reverse()));
                //writer.Flush();
                foreach (string line in lines)
                {
                    if (line.Contains(".txt")){
                        Console.WriteLine(line);
                    }
                    
                }
                try
                {
                    server.Disconnect();
                }
                catch (ObjectDisposedException ode)
                {
                    Console.WriteLine(ode.Message);
                } 
                }
            //});
        }
    }
}
