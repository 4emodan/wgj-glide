using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 1f;

    private const int UP = 0;
    private const int DOWN = 1;

    private Rigidbody2D rigidbody2D;
    private int dir = -1;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float verticalMove = Input.GetAxisRaw("Vertical");

        if (verticalMove >= 0.1f)
        {
            dir = UP;
        }
        else if (verticalMove <= -0.1f)
        {
            dir = DOWN;
        }
        else
        {
            dir = -1;
        }
    }

    void FixedUpdate()
    {
        switch (dir)
        {
            case UP: 
                rigidbody2D.velocity = Vector2.up * velocity;
                // rigidbody2D.AddForce(Vector2.up * velocity);
                break;

            case DOWN: 
                rigidbody2D.velocity = Vector2.down * velocity;
                break;

            default:
                rigidbody2D.velocity = Vector2.zero;
                break;
        }
    }
}
