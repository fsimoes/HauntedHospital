using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationController : MonoBehaviour {

    Animator animator;
    public int speed;
   
	// Use this for initialization
	void Awake() {
        animator = GetComponentInChildren<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Horizontal", horizontalInput);
        this.transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime);
    }
}
