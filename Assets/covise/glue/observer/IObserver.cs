using System;


namespace Covise.Glue.Observer
{
    public interface IObserver<T>
    {
        public void setObservedReference(ref T observed);
        
        public void invokeChangeEvent();

        public EventHandler getEventHandler();
    }
}