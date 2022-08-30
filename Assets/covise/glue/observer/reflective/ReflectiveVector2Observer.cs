using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveVector2Observer : AbstractObserver<Vector2> 
    {
        private Vector2 previousValue;
        
        private object instance;
        private FieldInfo observedField;

        public ReflectiveVector2Observer()
        {
            
        }
        
        public ReflectiveVector2Observer(object instance, FieldInfo field)
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
            observed = (Vector2)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}