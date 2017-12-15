using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    [SerializeField] Transform hand;
    public bool IsShooting { set; get; }
    public bool NeedReload { protected set; get; }


    private Vector3 startingShootingPosition = new Vector3(0.09375913f, -0.02560178f, 0.1680344f);
    private Quaternion startingShootingRotation = Quaternion.Euler(179.992f, -1.525879f, 270);
    private Vector3 shootingPosition = new Vector3(0, -0.039f, 0.111f);
    private Quaternion shootingRotation = Quaternion.Euler(179.993f, -28.853f, 269.996f);

    public int magazine;
    private int currentAmmo;
    public float fireRate;
    float currentTime;
    float nextShot;

    public GameObject bulletEmiterGO;
    BulletEmiter bullerEmiter;
    // Use this for initialization
    void Awake () {
        this.transform.SetParent(hand);
        bullerEmiter = bulletEmiterGO.GetComponent<BulletEmiter>();
        currentAmmo = magazine;
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
       
        if(IsShooting && currentTime > nextShot)
        {
            nextShot = currentTime + fireRate;
            bullerEmiter.Shoot();
            currentAmmo--;
            NeedReload = currentAmmo == 0;
        }

        if (IsShooting)
        {
            this.transform.localPosition = shootingPosition;
            this.transform.localRotation = shootingRotation;
        }
        else
        {
            this.transform.localPosition = startingShootingPosition;
            this.transform.localRotation = startingShootingRotation;
        }
        //IsShooting = false;
    }

    public int Shoot()
    {
        IsShooting = currentAmmo > 0;
        return currentAmmo;
    }

    public void Reload(int amount = 0)
    {
        if(amount == 0)
        {
            amount = magazine;
        }
        currentAmmo = magazine;
    }
}
