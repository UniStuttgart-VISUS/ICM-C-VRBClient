using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveMatrix4x4Observer : AbstractObserver<Matrix4x4> 
    {
        private Matrix4x4 previousValue;
        
        private object instance;
        private FieldInfo observedField;

        public ReflectiveMatrix4x4Observer()
        {
            
        }
        
        public ReflectiveMatrix4x4Observer(object instance, FieldInfo field)
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
            observed = (Matrix4x4)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}