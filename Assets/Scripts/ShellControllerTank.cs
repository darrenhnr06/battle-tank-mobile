using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class ShellControllerTank : MonoBehaviour
    {
        private float fireTime = 0.5f;
        private void OnCollisionEnter(Collision collision)
        {
            StartCoroutine(FireShell());
        }

        IEnumerator FireShell()
        {
            yield return new WaitForSeconds(fireTime);
            Destroy(gameObject);
        }
    }
}


