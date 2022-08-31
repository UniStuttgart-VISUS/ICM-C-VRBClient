using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveULongObserver : ReflectiveObserver<ulong> 
    {
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