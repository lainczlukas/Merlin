using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Commands
{
    public interface IAction<T>
    {
        public void Execute(T t);
    }
}
