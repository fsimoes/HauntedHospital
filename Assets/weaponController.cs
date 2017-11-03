using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour {

    [SerializeField] Transform hand;
    // Use this for initialization
    void Awake () {
        this.transform.SetParent(hand);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
