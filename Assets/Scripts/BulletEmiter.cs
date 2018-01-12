using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmiter : MonoBehaviour {

   public GameObject bullet;
    public ParticleSystem BulletMuzzle;
    public ParticleSystem BulletEjection;

    // Use this for initialization
    void Start () {

    }
	
	public void Shoot()
    {
        Quaternion bulletRotation = transform.rotation;
        //bulletRotation.y = Quaternion.identity.y;
        Vector3 bulletPosition = transform.position;

        Instantiate(bullet, bulletPosition, bulletRotation);

        BulletMuzzle.Play();
        BulletEjection.Play();
    }
}
