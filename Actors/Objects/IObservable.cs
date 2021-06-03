using Merlin2.Actors.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Objects
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);

        void Unsubscribe(IObserver observer);
    }
}
