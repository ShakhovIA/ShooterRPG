using System;
using System.Collections.Generic;
using Injection;
using Tool;
using UnityEngine;
namespace Core.Scripts
{
    public class InventoryView:BaseView
    {
        #region [Dependency]
        [Inject] public Injector Injector { get; set; }
        [Inject] private AccountData AccountData { get; set; }
        [Inject] private ManagerData ManagerData { get; set; }
        #endregion
        
        #region [Fields]
        [field: SerializeField] public List<InventoryCell> InventoryCells { get; private set; }
        [field: SerializeField] public List<InventoryItem> InventoryItems { get; private set; }
        [field: SerializeField] private TextAsset DropJson { get; set; }
        #endregion
        
        #region [Functions]
        public override void Open()
        {
            if (Initialize())
                base.Open();
        }
        
        public override void Close()
        {
            Clear();
            base.Close();
        }

        private bool Initialize()
        {
            try
            {
                //ManagerData.PrefabInventoryCell
                AccountData.Items.ForEach(item =>
                {
                    
                });
            }
            catch (Exception e)
            {
                ManagerLog.LogError($"Inventory initialize failed.\tDetail:\t{e}");
                return false;
            }
            return true;
        }

        private void Clear()
        {
            InventoryCells.ForEach(cell => Destroy(cell.gameObject));
            InventoryItems.ForEach(item => Destroy(item.gameObject));
        }
        #endregion
    }

    public class InventoryCell : MonoBehaviour
    {
        #region [Fields]
        [field: SerializeField] public InventoryItem Item { get; private set; }
        [field: SerializeField] public EItem CellType { get; private set; }
        #endregion
    }

    
}