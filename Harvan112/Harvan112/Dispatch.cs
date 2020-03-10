using Harvan112.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harvan112
{
    public interface Dispatch
    {
        void Dispatch(ClientMessage message, Session session);
    }

    public class DispatchService
    {
        public void Dispatch(Dispatch service, ClientMessage message, Session session)
        {
            service.Dispatch(message, session);
        }
    }

    public class Ambulance : Dispatch
    {
        public void Dispatch(ClientMessage message, Session session)
        {
            Console.WriteLine($"> Dispatching {nameof(Ambulance)}");

            session.Send($"DISPATCH:{nameof(Ambulance)}:{message.Priority}");
        }
    }

    public class Firetruck : Dispatch
    {
        public void Dispatch(ClientMessage message, Session session)
        {
            Console.WriteLine($"> Dispatching {nameof(Firetruck)}");

            session.Send($"DISPATCH:{nameof(Firetruck)}:{message.Priority}");
        }
    }

    public class Police : Dispatch
    {
        public void Dispatch(ClientMessage message, Session session)
        {
            Console.WriteLine($"> Dispatching {nameof(Police)}");

            session.Send($"DISPATCH:{nameof(Police)}:{message.Priority}");
        }
    }
}
