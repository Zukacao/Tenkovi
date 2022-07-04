using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    #region Variables 

    public bool protect = false;

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            playerDeath();
        }
    } 
    
    private void playerDeath()
    {
        if(protect == true)
        {
            protect = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
