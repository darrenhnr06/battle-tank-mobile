using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankController
    {
        public TankModel TankModel { get; private set; }
        public TankView TankView { get; private set; }

        private Vector3 cameraPos;
        public TankController(TankModel tankModel,GameObject tankPrefab, GameObject cameraRig, Joystick joystick, Joystick joystickRotate)
        {
            TankModel = tankModel;
            GameObject tank = GameObject.Instantiate(tankPrefab);
            
            cameraPos = tank.gameObject.transform.position;
            cameraPos.y = 0;
            cameraRig.gameObject.transform.position = cameraPos;
            cameraRig.gameObject.transform.LookAt(tank.gameObject.transform.forward);
            cameraRig.gameObject.transform.SetParent(tank.gameObject.transform);  

            TankView = tank.gameObject.GetComponent<TankView>();
            TankView.SetTankController(this);
            tankModel.SetTankController(this);
            TankView.SetJoystickController(joystick);
            TankView.SetJoystickRotate(joystickRotate);
        }

        public void Fire(GameObject shell, Transform fireTransform)
        {
            GameObject gameObject = GameObject.Instantiate(shell, fireTransform.position, fireTransform.rotation);
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.velocity = TankModel.m_LaunchForce * fireTransform.forward;
        }

        public void Move(Transform transform, CharacterController charController, Joystick joystick)
        {
            Vector3 moveDirection;

            moveDirection.y = 0;
            moveDirection.x = joystick.Horizontal;
            moveDirection.z = joystick.Vertical;
            moveDirection.y -= TankModel.gravity * Time.deltaTime;

            

            charController.Move(moveDirection * TankModel.Speed * Time.deltaTime);
            
        }

        public void RotateTurret(GameObject turret, Joystick joystickRotate)
        {
            Vector3 rotation_Direction = Vector3.zero;

            if (joystickRotate.Horizontal > 0)
            {
                rotation_Direction = turret.gameObject.transform.TransformDirection(Vector3.right);
            }
            else if (joystickRotate.Horizontal < 0)
            {
                rotation_Direction = turret.gameObject.transform.TransformDirection(Vector3.left);
            }
            if (rotation_Direction != Vector3.zero)
            {
                turret.gameObject.transform.rotation = Quaternion.RotateTowards(turret.gameObject.transform.rotation, Quaternion.LookRotation(rotation_Direction), TankModel.rotateDegreesPerSecond * Time.deltaTime);
            }
        }

       /* public void Rotate(Transform transform, float horizontal)
        {
            Vector3 rotation_Direction = Vector3.zero;

            if (horizontal < 0)
            {
                rotation_Direction = transform.TransformDirection(Vector3.left);
            }
            else if (horizontal > 0)
            {
                rotation_Direction = transform.TransformDirection(Vector3.right);
            }
            if (rotation_Direction != Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotation_Direction), TankModel.rotateDegreesPerSecond * Time.deltaTime);
            }
        }
       */
   
    }
}
