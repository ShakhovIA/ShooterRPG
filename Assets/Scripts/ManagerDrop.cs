using System;
using System.Collections.Generic;
using System.Linq;
using Injection;
using UnityEngine;

namespace Core.Scripts
{
    public class ManagerDrop : MonoBehaviour
    {
        #region [Dependency]
        [Inject] public Player Player { get; set; }
        [Inject] public AccountData AccountData { get; set; }
        #endregion
        
        #region [Fields]
        [field: SerializeField] public DropList DropList { get; private set; }
        [field: SerializeField] private TextAsset DropJson { get; set; }
        #endregion
        
        #region [Functions]
        public DropConfig GetDrop(EUnit eUnit)
        {
            DropConfig drop = DropList.DropConfigs.Find(x => x.Key.ToString() == eUnit.ToString());

            if ( drop != null)
            {
                return drop;
            }
            Debug.LogError($"Не найден список дропа для eUnit ={eUnit.ToString()} возвращаем FirstOrDefault");
            return DropList.DropConfigs.FirstOrDefault();
        }
        public void Initialize()
        {
            DropList = new DropList();
            DropList.DropConfigs = new List<DropConfig>();
            var temp = JsonUtility.FromJson<DropList>(DropJson.text);
            DropList = temp;
        }
        #endregion
    }

    
    
}