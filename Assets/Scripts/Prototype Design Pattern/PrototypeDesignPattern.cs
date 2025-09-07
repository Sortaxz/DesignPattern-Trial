using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.PrototypeDesignPattern
{
    public class PrototypeDesignPattern : MonoBehaviour
    {
        void Start()
        {
            Enemy goblin = new Enemy();
            goblin.EnemyProperties.SetEnemyProperties(new EnemyProperties() { enemyName = "Goblin", health = 50, damage = 10, speed = 3, idInfo = new IdInfo(0) });
            Enemy goblin2 = goblin.DeepCopy(new EnemyProperties() { enemyName = "Goblin2", health = 80, damage = 20, speed = 2, idInfo = new IdInfo(1) });

            goblin.EnemyProperties.health = 200;
        }
    }

    public class EnemyProperties
    {
        public IdInfo idInfo;
        public string enemyName;
        public float health;
        public float damage;
        public float speed;

        public void SetEnemyProperties(EnemyProperties enemyProperties)
        {
            enemyName = enemyProperties.enemyName;
            health = enemyProperties.health;
            damage = enemyProperties.damage;
            speed = enemyProperties.speed;
            idInfo = new IdInfo(enemyProperties.idInfo.IdNumber);
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }

    } 

    public class Enemy
    {
        private EnemyProperties enemyProperties;
        public EnemyProperties EnemyProperties => enemyProperties;

        public Enemy()
        {
            enemyProperties = new EnemyProperties();
        }

        public Enemy ShallowCopy()
        {
            return (Enemy)this.MemberwiseClone();
        }

        public Enemy DeepCopy(EnemyProperties newEnemyProperties)
        {
            Enemy enemy = (Enemy)this.MemberwiseClone();
            enemy.enemyProperties = new EnemyProperties();
            enemy.enemyProperties.SetEnemyProperties(newEnemyProperties);
            return enemy;
        }
    }

    

}
