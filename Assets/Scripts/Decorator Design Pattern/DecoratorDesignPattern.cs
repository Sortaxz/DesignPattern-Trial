using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DesignPatterns.DecoratorDesignPatterns
{
    public class DecoratorDesignPattern : MonoBehaviour
    {

    }

    #region  Example-1

    public interface ICharacter
    {
        void Movement();
    }


    public class Character : ICharacter
    {
        public void Movement()
        {

        }

    }

    public abstract class CharacterDecorator : ICharacter
    {
        protected ICharacter character;
        public CharacterDecorator(ICharacter _character)
        {
            character = _character;
        }

        public abstract void Movement();
    }


    public class Armor : CharacterDecorator
    {
        public Armor(ICharacter _character) : base(_character)
        {

        }

        public override void Movement()
        {

        }
    }

    public class SpeedBoat : CharacterDecorator
    {
        public SpeedBoat(ICharacter _character) : base(_character)
        {
        }

        public override void Movement()
        {

        }
    }

    #endregion

    #region  Example-2

    public interface IWeapon
    {
        void Use();
        void Shoot();
        void Refresh();

    }

    #region  WeaponComposite

    public interface IWeaponEquipmentComposite
    {
        void WeaponEquipmentAdd(WeaponEquipment weaponEquipment);
        WeaponEquipment GetWeaponEquipment(string weaponName);

        

    }

    public class WeaponEquipmentComposite : IWeaponEquipmentComposite
    {
        private Dictionary<string, WeaponEquipment> weaponEquipmentDictionary = new Dictionary<string, WeaponEquipment>();
        public void WeaponEquipmentAdd(WeaponEquipment weaponEquipment)
        {
            weaponEquipmentDictionary.Add(weaponEquipment.WeaponName, weaponEquipment);
        }
        public WeaponEquipment GetWeaponEquipment(string weaponName)
        {
            if (weaponEquipmentDictionary.TryGetValue(weaponName, out WeaponEquipment weaponEquipment))
                return weaponEquipment;
            throw new System.NullReferenceException();
        }

        

    }

    #endregion

    public class PistolWeapon : IWeapon
    {
        private WeaponEquipmentComposite weaponEquipmentComposite;

        public PistolWeapon()
        {
            weaponEquipmentComposite = new WeaponEquipmentComposite();

            WeaponScope weaponScope = new WeaponScope(this);
            weaponScope.WeaponName = "weaponScope";

            WeaponExtendedMagazine weaponExtendedMagazine = new WeaponExtendedMagazine(this);
            weaponExtendedMagazine.WeaponName = "WeaponExtendedMagazine";


            WeaponEquipmentAdd(weaponScope);
            WeaponEquipmentAdd(weaponExtendedMagazine);

        }

        public void Refresh()
        {
        }

        public void Shoot()
        {
        }

        public void Use()
        {
        }

        public void WeaponEquipmentAdd(WeaponEquipment weaponEquipment)
        {
            weaponEquipmentComposite.WeaponEquipmentAdd(weaponEquipment);
        }

        public WeaponEquipment GetWeaponEquipment(string weaponEquipmentName)
        {
            return weaponEquipmentComposite.GetWeaponEquipment(weaponEquipmentName);
        }

    }

    public class RifleWeapon : IWeapon
    {
        private WeaponEquipmentComposite weaponEquipmentComposite;

        public RifleWeapon()
        {
            weaponEquipmentComposite = new WeaponEquipmentComposite();

            WeaponScope weaponScope = new WeaponScope(this);
            weaponScope.WeaponName = "weaponScope";

            WeaponExtendedMagazine weaponExtendedMagazine = new WeaponExtendedMagazine(this);
            weaponExtendedMagazine.WeaponName = "WeaponExtendedMagazine";


            WeaponEquipmentAdd(weaponScope);
            WeaponEquipmentAdd(weaponExtendedMagazine);    
        }

        public void Refresh()
        {
            GetWeaponEquipment("WeaponExtendedMagazine").Refresh();
        }

        public void Shoot()
        {
            GetWeaponEquipment("weaponScope").Shoot();
        }

        public void Use()
        {
        }

        public void WeaponEquipmentAdd(WeaponEquipment weaponEquipment)
        {
            weaponEquipmentComposite.WeaponEquipmentAdd(weaponEquipment);
        }

        public WeaponEquipment GetWeaponEquipment(string weaponEquipmentName)
        {
            return weaponEquipmentComposite.GetWeaponEquipment(weaponEquipmentName);
        }

    }


    public abstract class WeaponEquipment : IWeapon
    {
        protected string weaponName;
        public string WeaponName { get => weaponName; set => weaponName = value; }

        protected IWeapon weapon;

        public WeaponEquipment(IWeapon _weapon)
        {
            weapon = _weapon;
        }

        public abstract void Use();

        public  abstract void Shoot();

        public abstract void Refresh();

    }


    public class WeaponScope : WeaponEquipment
    {
        public WeaponScope(IWeapon _weapon) : base(_weapon)
        {
        }

        public override void Refresh()
        {
        }

        public override void Shoot()
        {
        }

        public override void Use()
        {
        }
    }

    public class WeaponExtendedMagazine : WeaponEquipment
    {
        public WeaponExtendedMagazine(IWeapon _weapon) : base(_weapon)
        {
        }

        public override void Refresh()
        {
        }

        public override void Shoot()
        {
        }

        public override void Use()
        {
        }

    }

    #endregion

}
