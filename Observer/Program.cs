using System.Collections;

namespace ExampleObserverPattern
{
    public class Example
    {
        public static void Main()
        {
            Console.WriteLine("Example of Observar Pattern");
            var message = new Message();
            var cancellationObserver = new MessageCanceledObserver();
            var processedObserver = new MessageProcessedObserver();
            
            //Now we add the observers
            message.Attach(cancellationObserver);
            message.Attach(processedObserver);

            //Change states
            message.Send();
            message.Cancel();


        }
    }

    enum MessageState
    {
        Initial,
        Processed,
        Canceled
    }

    interface IMessage
    {
        MessageState State {get;set;}
        string Id { get; set; }

        void Attach(IMessageStateObserver observer);
        void Detach(IMessageStateObserver observer);
        void Notify();
        void Send();
        void Cancel();
    }
    interface IMessageStateObserver
    {
        void Update(IMessage message);
    }

    class MessageCanceledObserver : IMessageStateObserver
    {
        public void Update(IMessage message)
        {
            if (message.State == MessageState.Canceled)
            {
                Console.WriteLine("I have gotten a cancelled state on message Id: " + message.Id);
            }
        }
    }

    class MessageProcessedObserver : IMessageStateObserver
    {
        public void Update(IMessage message)
        {
            if (message.State == MessageState.Processed)
            {
                Console.WriteLine("I have gotten a processed state on message Id: " + message.Id);
            }
        }
    }

    class Message : IMessage
    {
        public MessageState State {get; set;}
        public string Id {get;set;}

        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        private List<IMessageStateObserver> _observers = new List<IMessageStateObserver>();

        private void SetState(MessageState state)
        {
            this.State = state;
            this.Notify();
        }
        public void Send()
        {
            Console.WriteLine("I am sending a message");
            SetState(MessageState.Processed);        
        }
        public void Attach(IMessageStateObserver observer)
        {
            Console.WriteLine("Subject attached to an observer");
            this._observers.Add(observer);
        }

        public void Detach(IMessageStateObserver observer)
        {
            Console.WriteLine("Subject detached from observer");
            this._observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var o in _observers)
            {
                o.Update(this);
            }
        }

        public void Cancel()
        {
            Console.WriteLine("I am canceling a message");
            SetState(MessageState.Canceled);
        }
    }
}
