using System;
using covise.attributes;
using UnityEngine;

namespace tests.Sample
{
    [SharedClass]
    public class SharedClassSyntax : MonoBehaviour
    {
        public Transform position;
        private int hidden_variable;
        private void Awake()
        {
            // Register this Type as shared here
        }
        
    }
}