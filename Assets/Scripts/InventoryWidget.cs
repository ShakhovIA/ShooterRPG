using System;
using System.Collections;
using System.Collections.Generic;
using Injection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.Scripts
{
    public class InventoryWidget : MonoBehaviour
    {
        #region [Dependency]
        [Inject] private InventoryView InventoryView { get; set; }
        #endregion
        
        #region [Fields]
        [field:SerializeField] public Button Button { get; private set; }
        #endregion
        
        #region [Functions]
        public void Start()
        {
            Initialize();
        }
        private void Initialize()
        {
            if (Button is null)
            {
                Button = gameObject.AddComponent<Button>();
            }
            Button.onClick.AddListener(OnClick);
        }
        public void OnClick()
        {
            Debug.Log("OnClick");
            InventoryView.Open();
        }
        #endregion
        
        
    }
}

