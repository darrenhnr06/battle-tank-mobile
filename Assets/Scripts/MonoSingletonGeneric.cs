using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
    {
        private static T instance;
        public static T Instance { get { return instance; } }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }
    }

    public class PlayerTank : MonoSingletonGeneric<PlayerTank>
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public void AttackEnemy()
        {
            Debug.Log("Enemy attacked");
        }
    }

    public class EnemyTank : MonoSingletonGeneric<EnemyTank>
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public void AttackEnemy()
        {
            Debug.Log("Player attacked");
        }
    }
}
