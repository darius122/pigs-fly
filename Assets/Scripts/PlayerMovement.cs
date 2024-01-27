using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float gravity;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
    }
    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;

        // Update the object's position based on the velocity
        transform.position += velocity * Time.deltaTime;
    }
}
