using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveVector2IntObserver : AbstractObserver<Vector2Int> 
    {
        private Vector2Int previousValue;
        
        private object instance;
        private FieldInfo observedField;

        public ReflectiveVector2IntObserver()
        {
            
        }
        
        public ReflectiveVector2IntObserver(object instance, FieldInfo field)
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
            observed = (Vector2Int)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}