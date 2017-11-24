using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFromTime : MonoBehaviour {

    public float lifeTime;
    private void Start()
    {
        //destroy the object after this period
        Destroy(gameObject, lifeTime);
    }
}
