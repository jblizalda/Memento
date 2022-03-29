using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;


namespace Memento
{
    public interface IMemento
    {
        string GetName();

        string GetState();

        DateTime GetDate();
    }
}
