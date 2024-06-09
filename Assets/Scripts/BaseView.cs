using UnityEngine;

namespace Core.Scripts
{
    public class BaseView : MonoBehaviour,IView
    {
        
        #region [Dependency]
        
        #endregion
        
        #region [Fields]
        [field:SerializeField] public GameObject Container { get; private set; }
        #endregion
        
        #region [Functions]

        public virtual void Open()
        {
            Debug.Log($"BaseView Open");
            Container.SetActive(true);
        }

        public virtual void Close()
        {
            Debug.Log($"BaseView Close");
            Container.SetActive(false);
        }
        #endregion
        
    }
}