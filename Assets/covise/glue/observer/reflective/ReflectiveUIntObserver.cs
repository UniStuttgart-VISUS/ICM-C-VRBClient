using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveUIntObserver : ReflectiveObserver<uint> 
    {
        public void LateUpdate()
        {
            observed = (uint)observedField.GetValue(instance);
            if (observed != previousValue)
            {
                invokeChangeEvent();
                previousValue = observed;
            }
        }
    }
}