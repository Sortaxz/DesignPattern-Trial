using System;

namespace AbstractFactoryDesignPattern
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