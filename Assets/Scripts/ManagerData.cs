using System;
using System.Collections.Generic;
using Injection;
using UnityEngine;

namespace Core.Scripts
{
    public class ManagerData : MonoBehaviour
    {
        #region [Dependency]
        [Inject] public Player Player { get; set; }
        [Inject] public AccountData AccountData { get; set; }
        #endregion
        
        #region [Fields]
        [field:SerializeField] public List<ItemData> AllItems { get; set; }
        [field:SerializeField] public InventoryCell PrefabInventoryCell { get; set; }
        [field:SerializeField] public InventoryItem PrefabInventoryItem { get; set; }
        #endregion
        
        #region [Functions]

        public void AddItem(List<ItemData> dropList)
        {
            
        }
        
        #endregion
    }
}