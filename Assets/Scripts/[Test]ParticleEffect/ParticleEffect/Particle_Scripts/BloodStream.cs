using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodStream : MonoBehaviour
{
    GameObject Player;
    //GameObject[] Monsters;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        //Monsters = GameObject.FindGameObjectsWithTag("Monster");
    }

    // Update is called once per frame
    void Update()
    {
        this.enabled = true;
        transform.position = GameObject.Find("Player").transform.position;
    }
}
