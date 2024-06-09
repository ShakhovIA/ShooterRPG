using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Scripts
{
    [Serializable]
    public class DropList
    {
        #region [Fields]
        [field: SerializeField] public List<DropConfig> DropConfigs;
        #endregion
    }
}