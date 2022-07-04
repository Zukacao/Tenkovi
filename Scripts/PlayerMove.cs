using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    #region Variables

    private Move move;

    private Rigidbody2D player;

    public string forwardKey;
    public string backwardKey;
    public string leftKey;
    public string rightKey;

    public bool moveBlock = false;

    public float speed = 3f;
    private Vector2 movePlayer;

    #endregion

    public void Awake()
    {
        player = GetComponent<Rigidbody2D>();

        move = FindObjectOfType<Move>();
    }


    void Update()
    {
        if (moveBlock == false)
        {
            Movement();
            Rotation();
        }
    }

    #region Movement

    private void Movement()
    {

        if (Input.GetKey(forwardKey))
        {
            movePlayer = move.Movement(player.transform.eulerAngles.z);

        }

        if (Input.GetKeyUp(forwardKey))
        {
            movePlayer = new Vector2(0, 0);
        }

        if (Input.GetKey(backwardKey))
        {
            movePlayer = -move.Movement(player.transform.eulerAngles.z);
        }

        if (Input.GetKeyUp(backwardKey))
        {
            movePlayer = new Vector2(0, 0);
        }

        player.position += movePlayer * speed * Time.fixedDeltaTime;
    }

    private void Rotation()
    {
        if (Input.GetKey(leftKey))
        {
            player.transform.rotation = Quaternion.Euler(0, 0, player.transform.eulerAngles.z + 1);
        }

        if (Input.GetKey(rightKey))
        {
            player.transform.rotation = Quaternion.Euler(0, 0, player.transform.eulerAngles.z - 1);
        }
    }


    #endregion
}
