using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(direction * speed, 0);

        rb.velocity = move;
    }
}
