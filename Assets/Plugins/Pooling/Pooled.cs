using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pooled : MonoBehaviour {

    private Pooling _pooling;

    public Pooling pooling { set { _pooling = value; } }


    public UnityEvent onEnable;
    public UnityEvent onDisable;




    private void OnEnable()
    {

        onEnable.Invoke();

    }


    private void OnDisable()
    {

        onDisable.Invoke();

        _pooling.Return(this.gameObject);
   
    }


}
