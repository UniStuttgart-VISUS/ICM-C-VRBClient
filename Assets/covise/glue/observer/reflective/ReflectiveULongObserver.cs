using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveULongObserver : AbstractObserver<ulong> 
    {
        private ulong previousValue;
        
        private object instance;
        private FieldInfo observedField;

        public ReflectiveULongObserver()
        {
            
        }
        
        public ReflectiveULongObserver(object instance, FieldInfo field)
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
            observed = (ulong)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}