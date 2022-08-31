using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class ReflectiveVector2IntObserver : ReflectiveObserver<Vector2Int> 
    {

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