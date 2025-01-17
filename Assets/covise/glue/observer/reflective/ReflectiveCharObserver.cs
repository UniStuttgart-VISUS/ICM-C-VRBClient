﻿using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveCharObserver : ReflectiveObserver<char> 
    {
        public ReflectiveCharObserver(object instance, FieldInfo field)
        {
            this.instance = instance;
            this.observedField = field;
        }

        public new void setObserved(object instance, FieldInfo field)
        {
            this.instance = instance;
            this.observedField = field;
        }

        public void LateUpdate()
        {
            observed = (char)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}