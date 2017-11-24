using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmiter : MonoBehaviour {

   public GameObject bullet;
	// Use this for initialization
	void Start () {

    }
	
	public void Shoot()
    {
        Quaternion bulletRotation = transform.rotation;
        Vector3 bulletPosition = transform.position;
        Instantiate(bullet, bulletPosition, bulletRotation);
    }
}
