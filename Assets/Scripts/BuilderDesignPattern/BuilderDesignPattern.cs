using System;

namespace BuilderDesignPatterns
{
    namespace Example_1
    {
        
        public interface IEntity
        {
        }

        public class Computer  : IEntity
        {
            public string CPU { get; set; }
            public string RAM { get; set; }
            public bool HasGraphicsCard { get; set; }
            public bool HasBluetooth { get; set; }

            public void DisplaySpecs() =>
                Console.WriteLine($"PC Özellikleri: İşlemci: {CPU}, RAM: {RAM}, Ekran Kartı: {HasGraphicsCard}, Bluetooth: {HasBluetooth}");
        }

        public interface IEntityBuilder<T> where T : IEntity
        {
            T Build();
        }

        public class ComputerBuilder : IEntityBuilder<Computer>
        {
            private  Computer computer = new Computer();

        

            public ComputerBuilder SetCPU(string cpu)
            {
                computer.CPU = cpu;
                return this;
            }

            public ComputerBuilder SetRam(string ram)
            {
                computer.RAM = ram;
                return this;
            }

            public ComputerBuilder SetGraphicsCard(bool hasGraphicsCard)
            {
                computer.HasGraphicsCard = hasGraphicsCard;
                return this;
            }

            public ComputerBuilder SetBluetooth(bool hasBluetooth)
            {
                computer.HasBluetooth = hasBluetooth;
                return this;
            }

        
            public Computer Build()
            {
                return computer;
            }
        }
    }

    namespace Example_2
    {
        public interface IEntity
        {
            string Name { get; set; }
            int Health { get; set; }
        }
        
        public class Character : IEntity
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int Strength { get; set; }
        }

        public interface IEntityBuilder<T> where T : IEntity
        {
            T Build();
        }

        public class CharacterBuilder : IEntityBuilder<Character>
        {
            private Character character = new Character();

            public CharacterBuilder SetName(string name)
            {
                character.Name = name;
                return this;
            }

            public CharacterBuilder SetHealth(int health)
            {
                character.Health = health;
                return this;
            }

            public CharacterBuilder SetStrength(int strength)
            {
                character.Strength = strength;
                return this;
            }

            public Character Build()
            {
                return character;
            }
        }

    }
}