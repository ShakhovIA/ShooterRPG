using UnityEngine;
namespace Core.Scripts
{
    public interface IView
    {
        public virtual void Open(){}
        public virtual void Close(){}
        public virtual void Initialize(){}
    }
}