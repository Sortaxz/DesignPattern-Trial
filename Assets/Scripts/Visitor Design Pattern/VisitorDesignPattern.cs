using System.Collections;
using UnityEngine;

namespace DesignPatterns.VisitorDesignPattern
{

    public class VisitorDesignPattern : MonoBehaviour
    {
        ICharacter[] characters = new ICharacter[]
        {
            new Knight(),
            new Archer(),
            new Wizard()
        };


        ICharacterVisitor characterVisitor = new HealingVisitor();

        void Start()
        {
            foreach (var character in characters)
            {
                character.Accept(characterVisitor);
                print(character.Health);
            }
        }
    }

    public interface ICharacterVisitor
    {
        void Visit(Knight knight);
        void Visit(Archer archer);
        void Visit(Wizard wizard);
    }
    public interface ICharacter
    {
        float Health { get; set; }
        void Accept(ICharacterVisitor visitor);
    }


    public class Knight : ICharacter
    {
        private float health = 30;
        public float Health { get => health; set => health = value; }

        public void Accept(ICharacterVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Archer : ICharacter
    {
        private float health = 70;
        public float Health { get => health; set => health = value; }
        public void Accept(ICharacterVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Wizard : ICharacter
    {
        private float health = 120;
        public float Health { get => health; set => health = value; }
        public void Accept(ICharacterVisitor visitor)
        {
            visitor.Visit(this);
        }
    }


    public class HealingVisitor :ICharacterVisitor
    {

        public void Visit(Knight knight)
        {
            knight.Health += 20;
            Debug.Log($"Knight healed. New health: {knight.Health}");
        }

        public void Visit(Archer archer)
        {
            archer.Health += 15;
            Debug.Log($"Archer healed. New health: {archer.Health}");
        }

        public void Visit(Wizard wizard)
        {
            wizard.Health += 7.5f;
            Debug.Log($"Wizard healed. New health: {wizard.Health}");
        }
    }


    
}
