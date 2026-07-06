using System;

namespace AdapterDeisngPatterns
{
    using System;

    // Target Interface
    public interface IMessageService
    {
        void Send(string message);
    }

    // Adaptee (3. parti kütüphane)
    public class SmsProvider
    {
        public void SendSms(string text)
        {
            Console.WriteLine($"SMS Gönderildi: {text}");
        }
    }

    // Adapter
    public class SmsAdapter : IMessageService
    {
        private readonly SmsProvider _smsProvider;

        public SmsAdapter(SmsProvider smsProvider)
        {
            _smsProvider = smsProvider;
        }

        public void Send(string message)
        {
            // Gerekirse burada dönüşüm, loglama, hata yönetimi yapılabilir.
            _smsProvider.SendSms(message);
        }
    }

    // Client
    public class NotificationService
    {
        private readonly IMessageService _messageService;

        public NotificationService(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Notify(string message)
        {
            _messageService.Send(message);
        }
    }


}