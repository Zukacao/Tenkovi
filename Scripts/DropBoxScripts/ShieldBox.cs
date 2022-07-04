using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBox : MonoBehaviour
{
    private PlayerBoost playerBoost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerBoost>();

        if (collision.CompareTag("Player") && playerBoost.haveBoost == false)
        {
            playerBoost.haveBoost = true;
            playerBoost.shield = true;

            Destroy(gameObject);
        }
    }
}
