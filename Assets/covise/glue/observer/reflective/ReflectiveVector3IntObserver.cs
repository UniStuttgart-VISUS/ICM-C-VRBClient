using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveVector3IntObserver : AbstractObserver<Vector3Int> 
    {
        private Vector3Int previousValue;
        
        private object instance;
        private FieldInfo observedField;

        public ReflectiveVector3IntObserver()
        {
            
        }
        
        public ReflectiveVector3IntObserver(object instance, FieldInfo field)
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
            observed = (Vector3Int)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}