using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveBoolObserver : AbstractObserver<bool> 
    {
        private bool previousValue;
        
        private object instance;
        private FieldInfo observedField;

        public ReflectiveBoolObserver()
        {
            
        }
        
        public ReflectiveBoolObserver(object instance, FieldInfo field)
        {
            this.instance = instance;
            this.observedField = field;
        }

        public void setObserved(object instance, FieldInfo field)
        {
            this.instance = instance;
            this.observedField = field;
        }

        public void LateUpdate()
        {
            observed = (bool)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}