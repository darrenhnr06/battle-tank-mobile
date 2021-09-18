using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "TankScriptableObject1", menuName = "ScriptableObjects1/NewTank1")]
    public class TankScriptableObject1 : ScriptableObject
    {   
        public TankType tankType;
        public string TankName;
        public float Speed;
        public float Health;
        public GameObject gameObject;
        public float gravity = 9.8f;
        public float rotation_Speed = 0.15f;
        public float rotateDegreesPerSecond = 180f;
        public float m_LaunchForce = 10;
    }
}



