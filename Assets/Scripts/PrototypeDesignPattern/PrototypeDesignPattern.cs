using System.Collections.Generic;

namespace PrototypeDesignPatterns
{
    public interface IPrototype<T>
    {
        T Clone();
    }


    public class Character : IPrototype<Character>
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public List<int> Ints;

        public Character Clone()
        {
            Character prototypeCharacter = (Character)this.MemberwiseClone();
            prototypeCharacter.Ints = new List<int>(this.Ints);
            return prototypeCharacter;
        }
    }
}