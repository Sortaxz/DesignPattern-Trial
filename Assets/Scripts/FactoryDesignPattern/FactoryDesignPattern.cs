using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.FactoryDesignPatterns
{
    public interface IFactoryCreator
    {
        IFactoryProduct CreateProduct();
    }

    public interface IFactoryProduct
    {
        void UseProduct();
    }

    public class FactoryEnemyCreator : IFactoryCreator
    {
        public IFactoryProduct CreateProduct()
        {
            return new FactoryEnemyProduct();
        }
    }


    public class FactoryEnemyProduct : IFactoryProduct
    {
        public void UseProduct()
        {
            Debug.Log("Enemy Created");
        }
    }
    
}
