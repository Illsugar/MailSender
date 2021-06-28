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
            //ThreadsIntro.Run();
            //CriticalSection.Run();
            //ThreadSynchronization.Run();
            Intro.Run();


            Console.WriteLine("Работа завершена. Нажмите Enter для выхода");
            Console.ReadLine();
        }
    }
}
