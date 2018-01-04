using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmiter : MonoBehaviour {

   public GameObject bullet;
   //public GameObject bulletEffect; //Test:Particle

    // Use this for initialization
    void Start () {

    }
	
	public void Shoot()
    {
        Quaternion bulletRotation = transform.rotation;
        //bulletRotation.y = Quaternion.identity.y;
        Vector3 bulletPosition = transform.position;

        //Test:Particle
        //Quaternion bulletParticleRotation = transform.rotation;
        //Vector3 bulletParticlePosition = transform.position;


        Instantiate(bullet, bulletPosition, bulletRotation);
        // Instantiate(bullet,transform,false);

        //Test:Particle
        //Instantiate(bulletEffect, bulletParticlePosition, bulletParticleRotation);
    }
}
