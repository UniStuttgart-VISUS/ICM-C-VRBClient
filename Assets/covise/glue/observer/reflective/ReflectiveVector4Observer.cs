using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveVector4Observer : AbstractObserver<Vector4> 
    {
        private Vector4 previousValue;
        
        private object instance;
        private FieldInfo observedField;

        public ReflectiveVector4Observer()
        {
            
        }
        
        public ReflectiveVector4Observer(object instance, FieldInfo field)
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
            observed = (Vector4)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}