using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveVector3IntObserver : ReflectiveObserver<Vector3Int> 
    {
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