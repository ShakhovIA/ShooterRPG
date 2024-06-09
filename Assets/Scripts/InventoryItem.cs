using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Scripts
{
    public class InventoryItem : MonoBehaviour,IDragHandler,IDropHandler,IEndDragHandler
    {
        
        public void OnDrag(PointerEventData eventData)
        {
            
        }

        public void OnDrop(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}