using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankModel
    {
        private TankController tankController;
        public TankModel(TankScriptableObject1 tankScriptableObject)
        {
            Speed = tankScriptableObject.Speed;
            Health = tankScriptableObject.Health;
            gravity = tankScriptableObject.gravity;
            rotation_Speed = tankScriptableObject.rotation_Speed;
            rotateDegreesPerSecond = tankScriptableObject.rotateDegreesPerSecond;
            m_LaunchForce = tankScriptableObject.m_LaunchForce;
        }

        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        public float Speed { get; }
        public float Health { get; }
        public float gravity { get;  }
        public float rotation_Speed { get; }
        public float rotateDegreesPerSecond { get; }
        public float m_LaunchForce { get; }
    }
}
