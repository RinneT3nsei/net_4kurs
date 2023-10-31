using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Bridge
    {
        public interface IMessageFormatter
        {
            string FormatMessage(string message);
        }

        public class TextMessageFormatter : IMessageFormatter
        {
            public string FormatMessage(string message)
            {
                return message;
            }
        }

        public class HtmlMessageFormatter : IMessageFormatter
        {
            public string FormatMessage(string message)
            {
                return $"<html>{message}</html>";
            }
        }

        public interface IMessageSender
        {
            void SendMessage(string message);
        }

        public class EmailMessageSender : IMessageSender
        {
            public void SendMessage(string message)
            {
                Console.WriteLine($"Sending email: {message}");
            }
        }

        public class SmsMessageSender : IMessageSender
        {
            public void SendMessage(string message)
            {
                Console.WriteLine($"Sending SMS: {message}");
            }
        }

        public class MessageService
        {
            private IMessageFormatter formatter;
            private IMessageSender sender;

            public MessageService(IMessageFormatter formatter, IMessageSender sender)
            {
                this.formatter = formatter;
                this.sender = sender;
            }

            public void Send(string message)
            {
                string formattedMessage = formatter.FormatMessage(message);
                sender.SendMessage(formattedMessage);
            }
        }

        public interface IDevice
        {
            void TurnOn();
            void TurnOff();
        }

        public class TV : IDevice
        {
            public void TurnOn()
            {
                Console.WriteLine("TV is turned on");
            }

            public void TurnOff()
            {
                Console.WriteLine("TV is turned off");
            }
        }

        public class Radio : IDevice
        {
            public void TurnOn()
            {
                Console.WriteLine("Radio is turned on");
            }

            public void TurnOff()
            {
                Console.WriteLine("Radio is turned off");
            }
        }

        public abstract class RemoteControl
        {
            protected IDevice device;

            public RemoteControl(IDevice device)
            {
                this.device = device;
            }

            public abstract void TurnOn();
            public abstract void TurnOff();
        }

        public class TVRemoteControl : RemoteControl
        {
            public TVRemoteControl(IDevice device) : base(device) { }

            public override void TurnOn()
            {
                device.TurnOn();
            }

            public override void TurnOff()
            {
                device.TurnOff();
            }
        }
    }
}
