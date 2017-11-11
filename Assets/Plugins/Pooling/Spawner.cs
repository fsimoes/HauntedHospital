using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public float spanwTime = 0.5f;


    //public GameObject spawnable;
    public Transform position;

    float nextSpawn = 0f;


    public Pooling pool;

	// Use this for initialization
	void Start () {
		
	}




    // Update is called once per frame
    void Update () {


        if ( Time.time > nextSpawn )
        {
            nextSpawn += spanwTime;

            //Instantiate(spawnable, position);

            GameObject go = pool.Pull();

            if (go != null)
            {
                go.transform.position = position.position;
                go.SetActive(true);
            }

         
        }


	}
}
