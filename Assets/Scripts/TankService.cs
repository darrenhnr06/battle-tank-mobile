using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankService : MonoBehaviour
    {
        public TankScriptableObjectList tanks;
        public GameObject cameraRig;
        public Joystick joystick;
        public Joystick joystickRotate;

        private void Start()
        {
            CreateNewTank();
        }

        public void CreateNewTank()
        {
            TankScriptableObject1 tankScriptableObject;
            tankScriptableObject = tanks.tankList[Random.Range(0, tanks.tankList.Length)];
            TankModel model = new TankModel(tankScriptableObject);
            TankController tank = new TankController(model, tankScriptableObject.gameObject, cameraRig, joystick, joystickRotate);
        }
    }
}


