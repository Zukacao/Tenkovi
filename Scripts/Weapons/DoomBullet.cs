using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomBullet : MonoBehaviour
{
    #region Variables

    private Move move;

    private Rigidbody2D doom;

    private float speed = 3f;

    #endregion

    private void Awake()
    {
        move = FindObjectOfType<Move>();

        doom = GetComponent<Rigidbody2D>();

        StartCoroutine(destroyAfter());

        doom.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 361));
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        doom.position += move.Movement(doom.transform.eulerAngles.z) * speed * Time.fixedDeltaTime;
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator destroyAfter()
    {
        yield return new WaitForSeconds(10);

        Destroy(gameObject);
    }

}
