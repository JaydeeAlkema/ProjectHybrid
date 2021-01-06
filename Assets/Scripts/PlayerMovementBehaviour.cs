using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.5f;
    [SerializeField]
    private float maxSpeed = 2;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        MovePlayer(horizontal);
    }

    public void MovePlayer(float direction)
    {
        Vector2 move = new Vector2(direction, 0);
        //transform.position += move * Time.deltaTime * moveSpeed;
        if (rb2d.velocity.x < maxSpeed && rb2d.velocity.x > -maxSpeed) {
            rb2d.AddForce(move);
        }
    }
}
