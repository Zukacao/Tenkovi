using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    #region Variables 

    private PlayerMove playerMove;
    private PlayerWeapon playerWeapon;
    private Move move;

    public Rigidbody2D rocket;

    private float speed = 3f;

    #endregion
    private void Start()
    {
        playerMove = gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<PlayerMove>();
        playerWeapon = gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<PlayerWeapon>();
        move = FindObjectOfType<Move>();

        playerMove.moveBlock = true;

        rocket = GetComponent<Rigidbody2D>();

        StartCoroutine(destroyAfter());
    }

    private void Update()
    {
        Movement();

        if (playerMove.moveBlock == true)
        {
            Rotation();
        }
    }

    private void Movement()
    {
        rocket.position += move.Movement(rocket.transform.eulerAngles.z) * speed * Time.fixedDeltaTime;
    }

    private void Rotation()
    {
        if (Input.GetKey(playerMove.leftKey))
        {
            rocket.transform.rotation = Quaternion.Euler(0, 0, rocket.transform.eulerAngles.z + 1);
        }

        if (Input.GetKey(playerMove.rightKey))
        {
            rocket.transform.rotation = Quaternion.Euler(0, 0, rocket.transform.eulerAngles.z - 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerWeapon.resetWeapon();
        playerMove.moveBlock = false;
        
        Destroy(gameObject);
    }

    IEnumerator destroyAfter()
    {
        yield return new WaitForSeconds(10);

        playerWeapon.resetWeapon();
        playerMove.moveBlock = false;
        
        Destroy(gameObject);
    }
}
