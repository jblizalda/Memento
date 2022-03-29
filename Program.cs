using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator("Inicia el Editor");
            Caretaker caretaker = new Caretaker(originator);

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            Console.WriteLine();
            caretaker.ShowHistory();

            Console.WriteLine("\nClient: Ejecutamos comando Deshacer!\n");
            caretaker.Undo();

            Console.WriteLine("\n\nClient: Repetimos Deshacer!\n");
            caretaker.Undo();

            Console.WriteLine();
        }
    }
}
