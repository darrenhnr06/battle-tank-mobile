using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;

        private CharacterController charController;

        public GameObject shell;

        public Transform fireTransform;

        private TankService tankService;

        private float waitSeconds = 2f;

        private Joystick joystick;

        private Joystick joystickRotate;

        public GameObject turret;
        
        
        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        public void SetJoystickController(Joystick _joystick)
        {
            joystick = _joystick;
        }

        public void SetJoystickRotate(Joystick _joystick)
        {
            joystickRotate = _joystick;
        }

        private void Awake()
        {
            charController = GetComponent<CharacterController>();
            tankService = GameObject.Find("TankService").GetComponent<TankService>();
        }

        private void Start()
        {
            Fire();
        }


        private void FixedUpdate()
        {
           if (tankController != null)
            {
                Debug.Log(joystick.Vertical);
                Debug.Log(joystick.Horizontal);

                tankController.Move(gameObject.transform, charController, joystick);
                //tankController.Rotate(gameObject.transform, joystick.Horizontal);
               
                tankController.RotateTurret(turret, joystickRotate);
            }
           else
            {
                Debug.Log("Tank Controller is null");
            }
        }

        private void Fire()
        {
            StartCoroutine(TimeFire());
        }

        IEnumerator TimeFire()
        {
            while(true)
            {
                yield return new WaitForSeconds(1f);
                tankController.Fire(shell, fireTransform);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
           if(collision.gameObject.CompareTag("Shell Enemy"))
            {
                StartCoroutine(HoldDestroy());
            }
        }

        IEnumerator HoldDestroy()
        {
            yield return new WaitForSeconds(waitSeconds);
            Destroy(gameObject);
            tankService.CreateNewTank();
        }
    }
}
