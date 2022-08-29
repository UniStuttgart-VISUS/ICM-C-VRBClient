using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveObserver : AbstractObserver<object> 
    {
        private object previousValue;
        
        private object instance;
        private FieldInfo observedField;

        public ReflectiveObserver()
        {
            
        }
        
        public ReflectiveObserver(object instance, FieldInfo field)
        {
            this.instance = instance;
            this.observedField = field;
        }

        public void setObserved(object instance, FieldInfo field)
        {
            this.instance = instance;
            this.observedField = field;
        }

        private EqualityComparer<object> comparer = EqualityComparer<object>.Default;
        public void LateUpdate()
        {
            observed = observedField.GetValue(instance);
            if (!comparer.Equals(observed,previousValue))
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}