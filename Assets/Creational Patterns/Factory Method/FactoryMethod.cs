using UnityEngine;


namespace DesignPatterns.FactoryDesignPatterns
{

    public class FactoryMethod : MonoBehaviour
    {
        CreatorClient creatorClient;
        void Awake()
        {
            creatorClient = new CreatorClient(new CharacterCreator());
            creatorClient.Create();
        }
    }

    public interface IEntity
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Vector3 Position { get; set; }
    }

    public class Character : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Vector3 Position { get; set; }
    }

    public class Enemy : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Vector3 Position { get; set; }
    }

    public abstract class Creator
    {
        public abstract IEntity Create();
    }

    public class CharacterCreator : Creator
    {
        public override IEntity Create()
        {
            return new Character
            {
                Id = 1,
                FirstName = "Player",
                LastName = "Hero",
                Position = Vector3.zero
            };
        }
    }

    public class EnemyCreator : Creator
    {
        public override IEntity Create()
        {
            return new Enemy(){
                Id = 1,
                FirstName = "Enemy",
                LastName = "Hero",
                Position = Vector3.zero
            };
        }
    }


    public class CreatorClient
    {
        private Creator creator;
        public CreatorClient(Creator _creator)
        {
            creator = _creator;
        }

        public IEntity Create()
        {
            return creator.Create();
        }
    }

}
