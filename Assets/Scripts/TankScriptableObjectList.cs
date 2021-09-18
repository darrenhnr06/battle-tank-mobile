using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects1/TankLists")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject1[] tankList;
    }
}
