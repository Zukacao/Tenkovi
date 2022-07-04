using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doom : MonoBehaviour
{
    #region Variables 

    private PlayerWeapon playerWeapon;
    private Move move;

    public Rigidbody2D doomBullet;

    public Transform spawner;

    public GameObject doom;

    private float speed = 3f;

    #endregion
    private void Awake()
    {
        playerWeapon = gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<PlayerWeapon>();
        move = FindObjectOfType<Move>();

        doomBullet = GetComponent<Rigidbody2D>();

        StartCoroutine(destroyAfter());
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        doomBullet.position += move.Movement(doomBullet.transform.eulerAngles.z) * speed * Time.fixedDeltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 pom = collision.contacts[0].normal;

        if (collision.gameObject.CompareTag("Wall"))
        {
            if (Mathf.Abs(pom.x) > 0.9)
            {
                reflectVertical();
            }

            if (Mathf.Abs(pom.y) > 0.9)
            {
                reflectHorizontal();
            }

            if (pom.x != 0 && pom.y != 0)
            {
                doomBullet.transform.rotation = Quaternion.Euler(0, 0, -doomBullet.transform.eulerAngles.z);
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {

            playerWeapon.resetWeapon();

            exposion();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            playerWeapon.resetWeapon();

            exposion();
            Destroy(gameObject);
        }

    }

    private void reflectVertical()
    {
        doomBullet.transform.rotation = Quaternion.Euler(0, 0, 180 - doomBullet.transform.eulerAngles.z);
    }

    private void reflectHorizontal()
    {
        doomBullet.transform.rotation = Quaternion.Euler(0, 0, 360 - doomBullet.transform.eulerAngles.z);
    }

    IEnumerator destroyAfter()
    {
        yield return new WaitForSeconds(2);

        playerWeapon.resetWeapon();

        exposion();
        Destroy(gameObject);
    }

    private void exposion()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(doom, spawner.position, spawner.rotation);
        }
        Destroy(gameObject);
    }


}

