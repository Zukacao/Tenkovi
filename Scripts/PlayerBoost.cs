using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    #region Variables

    private PlayerMove playerMove;
    private PlayerLife playerLife;
    private Rigidbody2D player;

    public string boostKey;

    public bool haveBoost = false;

    public bool shield = false;
    public bool speed = false;
    public bool downsize = false;

    #endregion

    private void Start()
    {
        playerMove = gameObject.GetComponent<PlayerMove>();
        playerLife = gameObject.GetComponent<PlayerLife>();

        player = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(boostKey))
        {
            if(haveBoost == true)
            {
                if(shield == true)
                {
                    StartCoroutine(activeShield());
                }
                
                if(speed == true)
                {
                    StartCoroutine(activeSpeed());
                }

                if (speed == true)
                {
                    StartCoroutine(activeDownsize());
                }
            }
        }
    }

    IEnumerator activeShield()
    {
        shield = false;

        playerLife.protect = true;

        yield return new WaitForSeconds(15);

        playerLife.protect = false;

        haveBoost = false;

    }

    IEnumerator activeSpeed()
    {
        speed = false;

        playerMove.speed = 6f;

        yield return new WaitForSeconds(15);

        haveBoost = false;

        playerMove.speed = 3f;
    }

    IEnumerator activeDownsize()
    {
        downsize = false;

        player.transform.localScale = new Vector3(0.5f, 0.5f, 1);

        yield return new WaitForSeconds(15);

        haveBoost = false;

        player.transform.localScale = new Vector3(1, 1, 1);
    }
}
