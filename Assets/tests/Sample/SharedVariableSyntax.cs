using System;
using covise.attributes;
using covise.sharedstate;
using UnityEngine;

namespace tests.Sample
{
    [SharedClass]
    public class SharedVariableSyntax : MonoBehaviour
    {
        [SharedVariable]
        public bool position;

        [SharedVariable("LifeTime")]
        private int lifetime_shared = 20;

        [SharedVariable("com.namespace.other.classname", "floatValue")]
        protected float sharedByOther = 0.42f;

        public int hidden_variable;

        private void Start()
        {
            SharedStateManager.getInstance().registerSharedInstance(this);
            // Register this Type as shared here
        }
        
    }
}