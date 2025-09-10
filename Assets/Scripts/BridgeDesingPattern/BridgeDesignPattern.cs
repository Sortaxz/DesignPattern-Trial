using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.BridgeDesignPattern
{
    public class BridgeDesignPattern : MonoBehaviour
    {
        Pistol pistol = new Pistol();
        Rifle rifle = new Rifle();


        void Start()
        {
            Character hitmanWithPistol = new Hitman(pistol);
            hitmanWithPistol.Attack();

            Character soldierWithRifle = new Soldier(rifle);
            soldierWithRifle.Attack();
        }
    }

    public interface IWeapon
    {
        void Use();
    }

    public class Pistol : IWeapon
    {
        public void Use()
        {
            Debug.Log("Using Pistol");
        }
    }

    public class Rifle : IWeapon
    {
        public void Use()
        {
            Debug.Log("Using Rifle");
        }
    }

    public abstract class Character
    {
        protected IWeapon weapon;

        public Character(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public abstract void Attack();
    }


    public class Hitman : Character
    {
        public Hitman(IWeapon weapon) : base(weapon) { }

        public override void Attack()
        {
            Debug.Log("Hitman attacks!");
            weapon.Use();
        }
    }

    public class Soldier : Character
    {
        public Soldier(IWeapon weapon) : base(weapon) { }

        public override void Attack()
        {
            Debug.Log("Soldier attacks!");
            weapon.Use();
        }
    }

}
