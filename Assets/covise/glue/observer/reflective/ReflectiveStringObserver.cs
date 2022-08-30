using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveStringObserver : AbstractObserver<string> 
    {
        private string previousValue;
        
        private object instance;
        private FieldInfo observedField;

        public ReflectiveStringObserver()
        {
            
        }
        
        public ReflectiveStringObserver(object instance, FieldInfo field)
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
            observed = (string)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}