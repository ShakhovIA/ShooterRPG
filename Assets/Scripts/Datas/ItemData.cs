using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Scripts
{
    public class ItemData: MonoBehaviour
    {
        #region [Dependency]
        //[field:SerializeField] public EItem EItemType { get; private set; }
        #endregion
        
        #region [Fields]
        [field:SerializeField] public int Id { get; private set; }
        [field:SerializeField] public EItem EItemType { get; private set; }
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public string Description { get; private set; }
        [field:SerializeField] public Sprite Sprite { get; private set; }
        [field:SerializeField] public Object Prefab { get; private set; }
        [field:SerializeField] public float Weight { get; private set; }
        [field:SerializeField] public int Count { get; private set; }
        [field:SerializeField] public int PriceBuy { get; private set; }
        [field:SerializeField] public int PriceSell { get; private set; }
        [field:SerializeField] public Dictionary<EAttribute,int> Attributes { get; private set; }
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
