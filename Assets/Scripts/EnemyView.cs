using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyController enemyController;

        [SerializeField]
        private GameObject shell;

        [SerializeField]
        private Transform fireTransform;

        public void SetEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }

      
        public void Fire()
        {
            if (enemyController != null)
            {
                StartCoroutine(TimeFire());
            }
        }

        IEnumerator TimeFire()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                enemyController.Fire(shell, fireTransform);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Shell Tank"))
            {
                Destroy(gameObject);
                EnemyCount.deathCount++;
            }
        }
    }
}
