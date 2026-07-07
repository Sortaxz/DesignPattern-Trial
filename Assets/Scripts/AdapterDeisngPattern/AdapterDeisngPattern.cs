using System;

namespace AdapterDeisngPatterns
{
    using System;
    using UnityEngine;

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

    public interface ICharge
    {
        void Charge();
    }


    public class LaptopCharge : ICharge
    {
        public void Charge()
        {
            Debug.Log("Laptop şarjı ile cihaz şarj ediliyor.");
        }

    }

    public class LaptopPlusCharge
    {
        public void PlusCharge()
        {
            Debug.Log("Laptop Plus şarjı ile cihaz şarj ediliyor");
        }
    }


    public class LaptopChargeAdapte : ICharge
    {
        private LaptopPlusCharge laptopPlusCharge;

        public LaptopChargeAdapte(LaptopPlusCharge laptopPlusCharge)
        {
            this.laptopPlusCharge = laptopPlusCharge;
        }

        public void Charge()
        {
            laptopPlusCharge.PlusCharge();
        }
    }


    public interface IIOSDevice
    {
        void Connect(); 
    }

    public class MacBook
    {
        public void ConnectPhono(IIOSDevice appleDevice)
        {
            appleDevice.Connect();
        }
    }

    public class IOSPhone : IIOSDevice
    {
        public void Connect()
        {
            Debug.Log("IOS cihaz bağlandı.");
        }
    }

    public class AndroidPhone
    {
        public void ConnectAndroid()
        {
            Debug.Log("AOS cihaz bağlandı.");
        }
    }

    public class SamsungAdapter : IIOSDevice
    {
        private AndroidPhone androidPhone;
        public SamsungAdapter(AndroidPhone androidPhone)
        {
            this.androidPhone=androidPhone;
        }

        public void Connect()
        {
            androidPhone.ConnectAndroid();
        }
    }

}