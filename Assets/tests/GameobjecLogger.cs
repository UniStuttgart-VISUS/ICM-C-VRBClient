using System;
using System.Collections;
using System.Collections.Generic;
using Covise.Glue.Observer;
using UnityEngine;

[ExecuteInEditMode]
public class GameobjecLogger : MonoBehaviour
{
    private TransformObserver observer;
    
    // Start is called before the first frame update
    void Start()
    {
        observer = GetComponent<TransformObserver>();
        Transform observed = transform;
        observer.setObservedReference(ref observed);
        
        observer.changeEventHandler += (sender, args) => Debug.Log("Observed Object Changed !" + transform.position);
        
    }

    private void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime;
    }
}
