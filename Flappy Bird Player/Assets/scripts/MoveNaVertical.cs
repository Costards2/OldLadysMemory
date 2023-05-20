using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNaVertical : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(0, verticalInput) * moveSpeed;
        rb.velocity = new Vector2(rb.velocity.x, movement.y);
    }
}
