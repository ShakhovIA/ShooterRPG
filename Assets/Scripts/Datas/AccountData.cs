using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Scripts
{
    public class AccountData : MonoBehaviour
    {
        #region [Dependency]
        //[field:SerializeField] public EItem EItemType { get; private set; }
        #endregion
        
        #region [Fields]
        [field:SerializeField] public int Id { get; private set; }
        [field:SerializeField] public List<ItemData> Items { get; private set; }
        #endregion
        
        #region [Functions]
        public void Initialize()
        {
            
        }
        public void Activate()
        {
            
        }
        
        #endregion
    }
}
