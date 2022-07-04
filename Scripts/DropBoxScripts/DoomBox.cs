using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomBox : MonoBehaviour
{
    private PlayerWeapon playerWeapon;

    public GameObject doom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerWeapon = collision.gameObject.GetComponent<PlayerWeapon>();

        if (collision.CompareTag("Player") && playerWeapon.haveWeapon == false)
        {
            playerWeapon.weapon = doom;
            playerWeapon.haveWeapon = true;
            playerWeapon.checkWeapon();

            Destroy(gameObject);
        }
    }
}
