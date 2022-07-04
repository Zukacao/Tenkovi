using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownsizeBox : MonoBehaviour
{
    private PlayerBoost playerBoost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerBoost>();

        if (collision.CompareTag("Player") && playerBoost.haveBoost == false)
        {
            playerBoost.haveBoost = true;
            playerBoost.downsize = true;

            Destroy(gameObject);
        }
    }
}
