using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveLongObserver : ReflectiveObserver<long> 
    {
        public void LateUpdate()
        {
            observed = (long)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}