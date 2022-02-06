using System;
using System.Diagnostics;


namespace ExampleFactoryPattern
{

    static class Example
    {
        public static void Main()
        {
            Console.WriteLine("Hello, lets test the factory pattern:");

            var objEmail = NotificationFactory.Create(NotificationType.Email);
            objEmail.Notify();

            var objSMS = NotificationFactory.Create(NotificationType.SMS);
            objSMS.Notify();
            
        }
    }

    enum NotificationType
    {
        Email, SMS
    }

    class NotificationFactory
    {
        public static INotifyer Create(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Email: return new NotifyByEmail();
                case NotificationType.SMS: return new NotifyBySMS();
                default: throw new Exception("Indefined type of INotifyer");
            }
        }
    }

    interface INotifyer
    {
        void Notify();
    }

    class NotifyByEmail : INotifyer
    {
        public void Notify()
        {
            Console.WriteLine("Notifyed by e-Mail");
        }
    }

    class NotifyBySMS : INotifyer
    {
        public void Notify()
        {
            Console.WriteLine("Notifyed by SMS");
        }
    }

}