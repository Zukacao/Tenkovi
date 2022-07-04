using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    #region Variables
    public Transform god;

    public Rigidbody2D player;
    public Transform weaponSpawner;
    
    public string shootKey;

    public GameObject bullet;
    public GameObject weapon;

    public bool haveWeapon = false;
    public bool shootBlock = false;
    public bool safety = false;

    #endregion

    private void Start()
    {
        weapon = bullet;
    }

    private void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            if (shootBlock == false)
            {
                shoot();
            }
        }
    }

    public void shoot()
    {
        shootBlock = true;
        GameObject cao = Instantiate(weapon, weaponSpawner.position, weaponSpawner.rotation);
        cao.transform.SetParent(god);
    }

    public void checkWeapon()
    {
        if(shootBlock == true)
        {
            safety = true;
            shootBlock = false;
        }
    }

    public void shootBlockController()
    {
        if (safety == true)
        {
            safety = false;
        }
        else
        {
            shootBlock = false;
        }

    }

    public void resetWeapon()
    {
        haveWeapon = false;
        if(safety == true)
        {
            safety = false;
        }
        else
        {
            shootBlock = false;
        }

        weapon = bullet;
    }
}
