using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveMatrix4x4Observer : ReflectiveObserver<Matrix4x4> 
    {
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