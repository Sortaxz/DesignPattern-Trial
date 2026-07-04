using System;
using System.Diagnostics;

namespace AbstractFactoryDesignPattern
{
    #region  Example_1
    namespace Example_1
    {
        // Adım 1: Ürün Ailelerinin Arayüzleri ve Somut Halleri
        public interface IButton { void Render(); }
        public interface ICheckbox { void Toggle(); }

        // Windows Ailesi Ürünleri
        public class WindowsButton : IButton { public void Render() => Console.WriteLine("Windows Butonu Çizildi."); }
        public class WindowsCheckbox : ICheckbox { public void Toggle() => Console.WriteLine("Windows Checkbox İşaretlendi."); }

        // Mac Ailesi Ürünleri
        public class MacButton : IButton { public void Render() => Console.WriteLine("Mac Butonu Çizildi."); }
        public class MacCheckbox : ICheckbox { public void Toggle() => Console.WriteLine("Mac Checkbox İşaretlendi."); }

        public interface IUIFactory
        {
            IButton CreateButton();
            ICheckbox CreateCheckBox();
        }


        public class WindowsFactory : IUIFactory
        {
            public IButton CreateButton()
            {
                return new WindowsButton();
            }

            public ICheckbox CreateCheckBox()
            {
                return new WindowsCheckbox();
            }
        }

        public class MacFactory : IUIFactory
        {
            public IButton CreateButton()
            {
                return new MacButton();
            }

            public ICheckbox CreateCheckBox()
            {
                return new MacCheckbox();
            }
        }


        public class UIFactoryInvoker
        {
            private IUIFactory uIFactory;

            public void ChangeUIFactory(IUIFactory uIFactory)
            {
                this.uIFactory = uIFactory;
            }

            public IUIFactory GetUIFactory()
            {
                return uIFactory;
            }

        }
    }

    #endregion

    #region  Example_2

    public abstract class IEntity
    {
        protected IWeapon weapon;
        protected IEffect effect;

        public void SetWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
        }
        public void SetEffect(IEffect effect)
        {
            this.effect = effect;
        }
    }

    public interface IWeapon
    {
        void Fire();
    }

    public interface IEffect
    {
        void Enable();
        void Disable();
        void Start();
        void Stop();
    }

    public interface IEntityFactory
    {
        IEntity CreateEntity();
        IWeapon CreateWeapon();
        IEffect CreateEffect();
    }

    public class Alien : IEntity
    {

    }


    public class BloodEffect : IEffect
    {
        public void Disable()
        {
        }

        public void Enable()
        {
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }

    public class AlienWeapon : IWeapon
    {
        public void Fire()
        {
        }
    }

    public class AlienFactory : IEntityFactory
    {
        public IEntity CreateEntity()
        {
            return new Alien();
        }

        public IWeapon CreateWeapon()
        {
            return new AlienWeapon();
        }

        public IEffect CreateEffect()
        {
            return new BloodEffect();
        }
    }

    #endregion

    namespace Example_3
    {   
    #region  Example_3

    public interface IButton
    {
        void Open();
        void Close();
    }

    public interface IPanel
    {
        void Open();
        void Close();
    }

    public interface IPopup
    {
        void Open();
        void Close();
    }

    #region  Window

    public class WindowButton : IButton
    {
        public void Close()
        {
            Console.WriteLine("WindowButton kapatıldı");
        }

        public void Open()
        {
            Console.WriteLine("WindowButton açıldı");
        }
    }


    public class WindowPanel : IPanel
    {
        public void Close()
        {
            Console.WriteLine("WindowButton kapatıldı");
        }

        public void Open()
        {
            Console.WriteLine("WindowButton açıldı");
        }
    }

    public class WindowPopup : IPopup
    {
        public void Close()
        {
            Console.WriteLine("WindowButton kapatıldı");
        }

        public void Open()
        {
            Console.WriteLine("WindowButton açıldı");
        }
    }

    #endregion

    #region  Pc

    public class PcButton : IButton
    {
        public void Close()
        {
            Console.WriteLine("WindowButton kapatıldı");
        }

        public void Open()
        {
            Console.WriteLine("WindowButton açıldı");
        }
    }


    public class PcPanel : IPanel
    {
        public void Close()
        {
            Console.WriteLine("WindowButton kapatıldı");
        }

        public void Open()
        {
            Console.WriteLine("WindowButton açıldı");
        }
    }

    public class PcPopup : IPopup
    {
        public void Close()
        {
            Console.WriteLine("WindowButton kapatıldı");
        }

        public void Open()
        {
            Console.WriteLine("WindowButton açıldı");
        }
    }

    #endregion

    public interface IUIFactory
    {
        IButton CreateButton();
        IPanel CreatePanel();
        IPopup CreatePopup();
    }


    public class WindowsUIFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowButton();
        }

        public IPanel CreatePanel()
        {
            return new WindowPanel();
        }

        public IPopup CreatePopup()
        {
            return new WindowPopup();
        }
    }

    public class PcUIFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new PcButton();
        }

        public IPanel CreatePanel()
        {
            return new PcPanel();
        }

        public IPopup CreatePopup()
        {
            return new PcPopup();
        }
    }
    


    #endregion
    }


    namespace Example_4
    {
        #region  Example_4



        #endregion

    }
}

/*
Orman ve Çöl temalarına göre farklı düşman (Enemy), silah (Weapon) ve mermi (Projectile) üreten bir sistem geliştir.
Mobil ve PC platformları için farklı UI butonu (Button), panel (Panel) ve açılır pencere (Popup) oluşturan bir arayüz sistemi tasarla.
Buz ve Ateş bölgelerine göre farklı karakter (Character), özel yetenek (Ability) ve efekt (Effect) üreten bir yapı kur.
Modern ve Orta Çağ temalarına göre farklı bina (House), kule (Tower) ve duvar (Wall) nesneleri oluşturan bir şehir kurma sistemi geliştir.
Kolay, Orta ve Zor zorluk seviyelerine göre farklı düşman (Enemy), boss (Boss) ve ödül (Reward) oluşturan bir oyun sistemi tasarla.
Uzay ve Deniz ortamlarına göre farklı araç (Vehicle), yakıt sistemi (FuelSystem) ve hareket kontrolü (MovementController) üreten bir mimari oluştur.
İnsan, Elf ve Ork ırklarına göre farklı savaşçı (Warrior), büyücü (Mage) ve okçu (Archer) karakterleri oluşturan bir RPG sistemi geliştir.
Bilim Kurgu ve Fantastik dünyalarına göre farklı görev (Quest), NPC ve eşya (Item) üreten bir görev sistemi tasarla.
Gündüz ve Gece oyun modlarına göre farklı aydınlatma (Lighting), arka plan müziği (Music) ve çevre efektleri (EnvironmentEffect) oluşturan bir atmosfer sistemi geliştir.
Zombi, Uzaylı ve Robot temalarına göre farklı düşman (Enemy), saldırı davranışı (AttackBehavior) ve ölüm efekti (DeathEffect) üreten, yeni tema eklendiğinde mevcut kodu değiştirmeden genişletilebilen bir sistem geliştir.

*/