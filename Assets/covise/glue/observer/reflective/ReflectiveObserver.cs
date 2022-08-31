using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public abstract class ReflectiveObserver<T> : AbstractObserver<T> 
    {
        protected T previousValue;
        
        protected object instance;
        protected FieldInfo observedField;

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

        public void setValue(T value)
        {
            previousValue = value;
        }
    }
}