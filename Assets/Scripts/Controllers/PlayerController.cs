﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.
    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    public float speed = 6f;            // The speed that the player will move at.

  
    [HideInInspector] public float h;
    [HideInInspector] public float v;

    WeaponController weaponController;

    PlayerAnimationController anim;

    private bool isReloading = false;
    private bool isShooting = false;
    private float reloadingTime = 0;
    private float currentTime = 0;
    private bool noAmmo = false;

    // variables for the pickups and key
    private int pickedHealth;
    private int pickedAmmo;
    private bool hasKey = false;

    // audio for the pickups and key
    AudioSource audioSource;
    public AudioClip[] sounds;


    // Use this for initialization
    void Awake ()
    {

        playerRigidbody = GetComponent<Rigidbody>();
        weaponController = GetComponentInChildren<WeaponController>();
        anim = GetComponent<PlayerAnimationController>();
    }

    // function to get audio source
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void FixedUpdate() {
        currentTime += Time.deltaTime;
        // Store the input axes.
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // Move the player around the scene.
        Move(h, v);

        // Turn the player to face the mouse cursor.
        Turning();
        Shoot();
        Reload();
       }
    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && !isReloading)
        {
            if (noAmmo)
            {
                Reload(true);
                isShooting = false;               
            }
            else
            {
                noAmmo = weaponController.Shoot() == 0;
                isShooting = true;     
            }
           
        }
        else
        {
            isShooting = false;
        }
        weaponController.IsShooting = isShooting;
        
    }
    void Reload(bool forceReload = false)
    {
        if ((Input.GetKeyDown(KeyCode.R) && !isReloading) || forceReload)
        {
          
            isReloading = true;
            weaponController.Reload();
            reloadingTime = anim.Reload() + currentTime;
            
        }

        if(currentTime > reloadingTime && isReloading)
        {
            isReloading = false;
            noAmmo = false;
        }
        
    }
    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    // below comes the code for the key and pickups

    private void pickupHealth()
    {
        // since player's health ("curHealth") is in another script ("PlayerHealthScript"), this line is the way to access it
        // and increase by 25 when Health Box is picked up
        pickedHealth = GameObject.Find("Player").GetComponent<PlayerHealthScript>().curHealth;
        pickedHealth += 25;
        Debug.Log(pickedHealth);

        if (pickedHealth > 100)
        {
            pickedHealth = 100;
        }

        GameObject.Find("Player").GetComponent<PlayerHealthScript>().curHealth = pickedHealth;

        audioSource.PlayOneShot(sounds[1], 1F);
    }

    private void pickupAmmo()
    {
        // getting player's ammo ("currentAmmo")  from "WeaponControler.cs"
        pickedAmmo = GameObject.Find("Player").GetComponent<WeaponController>().magazine;
        pickedAmmo += 10;
        Debug.Log(pickedAmmo);

        if (pickedAmmo > 30)
        {
            pickedAmmo = 30;
        }

        GameObject.Find("Player").GetComponent<WeaponController>().magazine = pickedAmmo;
        audioSource.PlayOneShot(sounds[0], 10F);
    }

    private void pickupKey()
    {
        // update UI;
        hasKey = true;
        
        // key sound
        audioSource.PlayOneShot(sounds[2], 1F);
        // yes sound
        audioSource.PlayOneShot(sounds[3], 1F);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            pickupKey();
        }

        if (other.gameObject.CompareTag("AmmoBox"))
        {
            other.gameObject.SetActive(false);
            pickupAmmo();
            
        }

        if (other.gameObject.CompareTag("HealthBox"))
        {
            other.gameObject.SetActive(false);
            pickupHealth();
        }
    }


}
