using Injection;
using UnityEngine;

namespace Core.Scripts
{
    public class ManagerInput: MonoBehaviour
    {
        #region [Dependency]
        [Inject] private Player Player { get; set; }
        [Inject] private InventoryView InventoryView { get; set; }
        #endregion
        
        #region [Fields]
        private float _speed = 6f;
        private Vector3 _direction = Vector3.zero;
        #endregion
        
        #region [Functions]
        private void Update()
        {
            ControllerWASD();
        }
        private void ControllerWASD()
        {
            _direction = Vector3.zero;
            
            if (Input.GetKey(KeyCode.W))
                _direction += new Vector3(0, 0, _speed);
            else if (Input.GetKey(KeyCode.S))
                _direction -= new Vector3(0, 0, _speed);
            else if (Input.GetKey(KeyCode.A))
                _direction -= new Vector3(_speed, 0, 0);
            else if (Input.GetKey(KeyCode.D))
                _direction += new Vector3(_speed, 0, 0);

            if (_direction != Vector3.zero)
            {
                Player.Move(_direction * Time.deltaTime);
            }
            
            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryView.Open();
            }
        }

        
        #endregion
    }
}