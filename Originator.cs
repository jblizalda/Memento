using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace Memento
{
    class Originator
    {
        private string _state;

        public Originator(string state)
        {
            this._state = state;
            Console.WriteLine("Originator: Mi estado Inicial es: " + state);
        }

        // The Originator's business logic may affect its internal state.
        // Therefore, the client should backup the state before launching
        // methods of the business logic via the save() method.
        public void DoSomething()
        {
            Console.WriteLine("Originator: Escribiendo Texto.");
            this._state = this.GenerateRandomString(30);
            Console.WriteLine($"Originator: Mi Estado ha cambiado: {_state}");
        }

        private string GenerateRandomString(int length = 10)
        {
            string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = string.Empty;

            while (length > 0)
            {
                result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];

                Thread.Sleep(12);

                length--;
            }

            return result;
        }

        // Saves the current state inside a memento.
        public IMemento Save()
        {
            return new ConcreteMemento(this._state);
        }

        // Restores the Originator's state from a memento object.
        public void Restore(IMemento memento)
        {
            if (!(memento is ConcreteMemento))
            {
                throw new Exception("Clase memento desconocida " + memento.ToString());
            }

            this._state = memento.GetState();
            Console.Write($"Originator: Mi Estado ha cambiado: {_state}");
        }

    }
}
