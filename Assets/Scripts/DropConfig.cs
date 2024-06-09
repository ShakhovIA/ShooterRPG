using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Scripts
{
    [Serializable]
    public class DropConfig
    {
        #region [Fields]
        [field: SerializeField] public string Key;
        [field: SerializeField] public List<DropData> DropData;
        #endregion
    }
}