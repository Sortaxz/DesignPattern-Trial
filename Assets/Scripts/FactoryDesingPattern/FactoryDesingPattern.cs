using System;

namespace FactoryDesignPattern
{
    public enum NotificationType
    {
        None,
        SMS,
        Email
    }
    // Adım 1: Ortak arayüz
    public interface INotification
    {
        void Send(string message);
    }

    // Adım 2: Somut ürünler
    public class SmsNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"SMS gönderildi: {message}");
    }

    public class EmailNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"Email gönderildi: {message}");
    }

    // Adım 3: Fabrikamız
    public static class NotificationFactory
    {
        // Esneklik burada başlıyor. Yeni bir tür gelirse sadece buraya eklenir.
        public static INotification CreateNotification(NotificationType  notificationType)
        {
            return notificationType switch
            {
                NotificationType.SMS => new SmsNotification(),
                NotificationType.Email => new EmailNotification(),
                _ => throw new ArgumentException("Bilinmeyen bildirim türü!")
            };
        }
    }
}