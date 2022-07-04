using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables 

    private PlayerWeapon playerWeapon;
    private Move move;

    public Rigidbody2D bullet;

    private float speed = 3f;


    #endregion
    private void Start()
    {
        playerWeapon = gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<PlayerWeapon>();
        move = FindObjectOfType<Move>();
        
         
        bullet = GetComponent<Rigidbody2D>();

        StartCoroutine(destroyAfter());
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        bullet.position += move.Movement(bullet.transform.eulerAngles.z) * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 pom = collision.contacts[0].normal;
        Debug.Log("x = " + (pom.x));
        Debug.Log("y = " + (pom.y));
        if (collision.gameObject.CompareTag("Wall"))
        {
            int i = 0;
            if (Mathf.Abs(pom.x) >= 0.9)
            {
                i++;
                reflectVertical();
            }

            if (Mathf.Abs(pom.y) >= 0.9)
            {
                i++;
                reflectHorizontal();
            }

            (Mathf.Abs(pom.x) != 0  && Mathf.Abs(pom.y) != 0)
            {
                i++;
                bullet.transform.rotation = Quaternion.Euler(0, 0, -bullet.transform.eulerAngles.z);
            }
            i = 0;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            playerWeapon.shootBlockController();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            playerWeapon.shootBlockController();
            Destroy(gameObject);
        }

    }

    private void reflectVertical()
    {
        
        bullet.transform.rotation = Quaternion.Euler(0, 0, 180 - bullet.transform.eulerAngles.z);
    }

    private void reflectHorizontal()
    {
        bullet.transform.rotation = Quaternion.Euler(0, 0, 360 - bullet.transform.eulerAngles.z);
    }

    IEnumerator destroyAfter()
    {
        yield return new WaitForSeconds(10);

        playerWeapon.shootBlockController();
        Destroy(gameObject);
        
    }
}
