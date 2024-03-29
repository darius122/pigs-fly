using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PlayerHealth>().health == 0)
        {
            isDead = true;
        }

        if (Input.GetMouseButtonDown(0) && !isDead)
            Jump();
        //Debug.Log(rb.velocity);
    }
    private void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce);
    }
}
