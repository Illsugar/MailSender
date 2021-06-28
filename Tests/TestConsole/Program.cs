using System;
using System.Net;
using System.Net.Mail; //пространтво имён для работы с почтой 
using System.Threading;

namespace TestConsole
{
    class Program
    {
        static void Main (string[] args)
        {
            var time_thread = new Thread(TimeThreadMethod);
            time_thread.IsBackground = true;
            time_thread.Start();

            var message1 = "Message 1";
            var printer1_thread = new Thread(() => PrintMessage(message1, 50));
            
            var message2 = "Message 2";
            var printer2_thread = new Thread(() => PrintMessage(message2, 50));
            
            var message3 = "Message 3";
            var printer3_thread = new Thread(PrintMessageParametr);

            printer1_thread.Start();
            printer1_thread.Join();
            printer2_thread.Start();
            //printer3_thread.Start(message3);

            Console.WriteLine("Работа завершена!");
            Console.ReadLine();
        }

        private static void TimeThreadMethod()
        {
            while(true)
            {
                Console.Title = DateTime.Now.ToString("HH.mm.ss");
                Thread.Sleep(100);
            }
        }

        private static void PrintMessageParametr(object p) => PrintMessage((string)p, 20);

        private static void PrintMessage(string Message, int Count, int Timeout = 300)
        {
            var thread_id = Thread.CurrentThread.ManagedThreadId;

            for (int i = 1; i < 0; i++)
            {
                Console.WriteLine($"{1} - {2}:{3}", thread_id, Count, Message);
                Thread.Sleep(Timeout);
            }

            Console.WriteLine($"{0} - Print message {1} completed.", thread_id, Message); 
            
        }
        
        
    }
}
