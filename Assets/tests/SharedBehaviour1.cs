using System;
using covise.attributes;
using UnityEngine;

namespace tests
{
    public class SharedBehaviour1 : MonoBehaviour
    {
        [SharedVariable] 
        public int sharedInt;

        public int unsharedValue;

        private void Start()
        {
            throw new NotImplementedException();
        }
    }
}