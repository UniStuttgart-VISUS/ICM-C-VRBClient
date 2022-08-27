using System;
using UnityEngine;

namespace Covise.Glue.Observer
{
    public class TransformObserver: AbstractObserver<Transform>
    {
        public void LateUpdate()
        {
            if (observed.hasChanged)
            {
                invokeChangeEvent();
                observed.hasChanged = false;
            }
        }
    }
}