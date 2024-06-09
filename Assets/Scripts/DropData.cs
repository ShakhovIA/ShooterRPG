using System;
using UnityEngine;

namespace Core.Scripts
{
    [Serializable]
    public class DropData
    {
        #region [Fields]
        [field: SerializeField] public int Id;
        [field: SerializeField] public float Chance;
        #endregion
    }
}