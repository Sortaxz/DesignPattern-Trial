using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.AbstractFactoryDesignPattern
{
    public interface IAbstractFactoryEnemyCreator
    {
        IAbstractProductAttackEnemy CreateAttackEnemy();
        IAbstractProductDefenseEnemy CreateDefenseEnemy();
        IAbstractProductAbilityEnemy CreateAbilityEnemy();
    }

    public interface IAbstractProductAttackEnemy
    {
        void Use();
    }

    public interface IAbstractProductDefenseEnemy
    {
        void Use();
    }

    public interface IAbstractProductAbilityEnemy
    {
        void Use();
    }


    public class AbstractFactoryEnemyCreator : IAbstractFactoryEnemyCreator
    {
        public IAbstractProductAttackEnemy CreateAttackEnemy()
        {
            return new AbstractFactoryAttackEnemy();
        }

        public IAbstractProductDefenseEnemy CreateDefenseEnemy()
        {
            return new AbstractFactoryDefenseEnemy();
        }

        public IAbstractProductAbilityEnemy CreateAbilityEnemy()
        {
            return new AbstractFactoryAbilityEnemy();
        }
    }

    public class AbstractFactoryAttackEnemy : IAbstractProductAttackEnemy
    {
        public void Use()
        {
            Debug.Log("Attack Enemy used");
        }
    }

    public class AbstractFactoryDefenseEnemy : IAbstractProductDefenseEnemy
    {
        public void Use()
        {
            Debug.Log("Defense Enemy used");
        }
    }

    public class AbstractFactoryAbilityEnemy : IAbstractProductAbilityEnemy
    {
        public void Use()
        {
            Debug.Log("Ability Enemy used");
        }
    }


}
