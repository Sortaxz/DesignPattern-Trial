using System;
using UnityEngine;

namespace SingletonDesignPattern
{
    public class DatabaseManager : MonoBehaviour
    {
        private static DatabaseManager _instance;
        private static readonly object _lock = new object();

        private DatabaseManager()
        {
            Console.WriteLine("Veritabanı bağlantısı kuruldu (Bu yazı sadece 1 kere çıkmalı).");
        }

        public static DatabaseManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = FindAnyObjectByType<DatabaseManager>();
                    }
                    return _instance;
                }
            }
        }

        // Sınıfın yapacağı asıl işler
        public void ExecuteQuery(string sql)
        {
            Console.WriteLine($"Sorgu çalıştırıldı: {sql}");
        }
    }

    public class GameManager : MonoBehaviour
    {
        private static GameManager intance;
        private static readonly object _lock = new object();

        public GameManager Instance
        {
            get
            {
                if(intance == null)
                {
                    lock(_lock)
                    {
                        intance = this;
                        return intance;
                    }
                }
                return intance;
            }
        }


        void Awake()
        {
            lock(_lock)
            {
                if(intance == null)
                {
                    intance = this;
                    DontDestroyOnLoad(gameObject);
                    return;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }



    }
}