using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject spawnGO;

    public int spawnTotal;
    public int spawnCount;
    public float interval;
    float nextSpawn = 0;
    public int minStartOffset = 0;
    public int maxStartOffset = 10;
    // Use this for initialization
    void Start () {

        //Instantiate(spawnGO, this.transform.position, new Quaternion(-90, 0, 0, 0), this.transform);
        nextSpawn += Random.Range(minStartOffset, maxStartOffset);
    }

    // Update is called once per frame
    void Update ()
    {

        if (nextSpawn < Time.time && spawnCount < spawnTotal)
        {
            nextSpawn = Time.time + interval;
            Instantiate(spawnGO, this.transform.position, new Quaternion(-90, 0, 0, 0), this.transform);
            spawnCount++;
        }
    }   
}
