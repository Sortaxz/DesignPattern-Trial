using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.AdapterDesignPattern
{
    public class AdapterDesignPattern : MonoBehaviour
    {
        void Start()
        {
            IEnemy bossEnemy = new BossEnemy();
            bossEnemy.Attack();
            bossEnemy.Move();

            Alien alien = new Alien();
            IEnemy alienAdapter = new EnemyAdapter(alien);
            alienAdapter.Attack();
            alienAdapter.Move();
        }
    }

    public interface IEnemy
    {
        void Attack();
        void Move();
    }

    public class BossEnemy : IEnemy
    {
        public void Attack()
        {
            Debug.Log("Boss Enemy Attacking");
        }

        public void Move()
        {
            Debug.Log("Boss Enemy Moving");
        }
    }


    public class Alien
    {
        public void AlienAttack()
        {
            Debug.Log("Alien Attacking");
        }

        public void AlienMove()
        {
            Debug.Log("Alien Moving");
        }
    }
    

    public class EnemyAdapter : IEnemy
    {
        private Alien _alien;

        public EnemyAdapter(Alien alien)
        {
            SetLegacyEnemy(alien);  
        }

        public void SetLegacyEnemy(Alien alien)
        {
            _alien = alien;
        }

        public void Attack()
        {
            _alien.AlienAttack();
        }

        public void Move()
        {
            _alien.AlienMove();
        }
    }



}

