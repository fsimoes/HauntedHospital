using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour {


    float deathTime;



    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");

        if (Time.time > deathTime)
        {
            this.gameObject.SetActive(false);                  
        }

    }


    public void SetDeath( float sec )
    {
        //Debug.Log("Enable");

        deathTime = Time.time + sec;

        GetComponent<Rigidbody>().WakeUp(); 
    }

    public void Sleep()
    {
        //Debug.Log("Disable");
        GetComponent<Rigidbody>().Sleep();
    }

}
