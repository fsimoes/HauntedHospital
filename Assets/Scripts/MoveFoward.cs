using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour {
    //speed
    public float speed;
    //rigidbody
    Rigidbody rb;
    //target position
    Vector3 targetPostion;
    // Use this for initialization
    void Start()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) 
        {
            targetPostion = hit.point;
        }
        //direct it to the player position + a random area around it
        Vector3 direction = (targetPostion - transform.position);
        //normalize the direction
        direction = Vector3.Normalize(direction);
        //change foward to new direction
        transform.forward = direction;
        //get rigidbody
        rb = GetComponent<Rigidbody>();
      
        //add speed to foward
        rb.velocity = transform.forward * speed;
    }
}
