using System;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class AbstractObserver<T> : MonoBehaviour, IObserver<T>
    {
        protected T observed;
        public EventHandler changeEventHandler;
        
        public AbstractObserver() {
            
        }

        public AbstractObserver(ref T observed) {
            setObservedReference(ref observed);
        }

        public virtual void setObservedReference(ref T observed)
        {
            this.observed = observed;
        }

        public virtual void invokeChangeEvent()
        {
            changeEventHandler.Invoke(this, EventArgs.Empty);
        }

        public virtual EventHandler getEventHandler()
        {
            return changeEventHandler;
        }
    }
}