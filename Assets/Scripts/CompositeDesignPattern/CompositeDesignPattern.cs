using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.CompositeDesignPatterns
{
    public class CompositeDesignPattern : MonoBehaviour
    {
        Pistol pistol = new Pistol("Pistol 212");
        Shoutgon shoutgon = new Shoutgon("Shoutgon 515");

        Character character = new Character();

        void Awake()
        {
            character.WeaponComposite.WeaponAdd(pistol);
            character.WeaponComposite.WeaponAdd(shoutgon);

            character.WeaponComposite.Use();
            character.WeaponComposite.Shoot();
        }

    }

    public class Character
    {
        private IWeaponComposite weaponComposite;
        public IWeaponComposite WeaponComposite => weaponComposite;

        public Character()
        {
            weaponComposite = new WeaponComposite();
        }

    }

    public interface IWeaponComposite
    {
        void WeaponAdd(IWeaponComponent weapon);
        IWeaponComponent GetWeapon(string weaponName);

        void Use();
        void Use(string weaponName);

        void Shoot();
        void Shoot(string weaponName);
    }

    public class WeaponComposite : IWeaponComposite
    {
        Dictionary<string, IWeaponComponent> weapons = new Dictionary<string, IWeaponComponent>();

        public void WeaponAdd(IWeaponComponent weapon)
        {
            if (!weapons.ContainsKey(weapon.WeaponName))
            {
                weapons.Add(weapon.WeaponName, weapon);
            }
        }

        public IWeaponComponent GetWeapon(string weaponName)
        {
            if (weapons.TryGetValue(weaponName, out IWeaponComponent weapon))
            {
                return weapon;
            }

            throw new System.NullReferenceException($"{weaponName} bu isimde koleksiyonda eleman yok");

        }

        public void Use()
        {
            foreach (var item in weapons)
            {
                item.Value.Use();
            }
        }

        public void Use(string weaponName)
        {
            weapons[weaponName].Use();
        }

        public void Shoot()
        {
            foreach (var item in weapons)
            {
                item.Value.Shoot();
            }
        }

        public void Shoot(string weaponName)
        {
            weapons[weaponName].Shoot();
        }
    }



    public interface IWeaponComponent
    {
        string WeaponName { get; }
        void Use();
        void Shoot(); 
    }

    public class Pistol : IWeaponComponent
    {


        private string weaponName;
        public string WeaponName => weaponName;

        public Pistol(string _weaponName)
        {
            weaponName = _weaponName;
        }

        public void Use()
        {
            Debug.Log("Karakter tabanca silahı seçti");
        }
        public void Shoot()
        {
            Debug.Log("Karakter tabanca silahı ile ateş ediyor");
        }
    }

    public class Shoutgon : IWeaponComponent
    {
        private string weaponName;
        public string WeaponName => weaponName;

        public Shoutgon(string _weaponName)
        {
            weaponName = _weaponName;
        }

        public void Use()
        {
            Debug.Log("Karakter pompolı silahı seçti");
        }
        public void Shoot()
        {
            Debug.Log("Karakter pompolı silahı ile ateş ediyor");
        }
    }


}

