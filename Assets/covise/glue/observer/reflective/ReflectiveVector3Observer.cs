using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveVector3Observer : AbstractObserver<Vector3> 
    {
        private Vector3 previousValue;
        
        private object instance;
        private FieldInfo observedField;

        public ReflectiveVector3Observer()
        {
            
        }
        
        public ReflectiveVector3Observer(object instance, FieldInfo field)
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
            observed = (Vector3)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}