using System;
using System.Collections.Generic;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class GenericObserver<T>: AbstractObserver<T> 
    {
        private T previousValue;
        
        private EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        public void LateUpdate()
        {
            if (!comparer.Equals(observed,previousValue))
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}