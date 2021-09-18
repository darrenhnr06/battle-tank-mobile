using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace BattleTank
{
    public class EnemyService : MonoBehaviour
    {
        public EnemyScriptableObject enemyScriptable;
        private int enemyCount;
      
        private void Start()
        {
            enemyCount = 0;
            StartCoroutine(EnemyDrop());
        }

       
        IEnumerator EnemyDrop()
        {
            while (enemyCount < 5)
            {
                EnemyModel model = new EnemyModel(enemyScriptable);
                EnemyController tank = new EnemyController(model, enemyScriptable.gameObject);
                yield return new WaitForSeconds(3f);
                enemyCount += 1;
            }
        }

        private void Update()
        {
            if(EnemyCount.deathCount >= 4)
            {
                SceneManager.LoadScene("Lobby");
            }
        }
    }
}

