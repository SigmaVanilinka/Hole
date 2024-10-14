using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            MoveMent();
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -1.0f, 0.0f, Space.Self);
        }
    }

    public void MoveMent()
    {
        float movementInput = Input.GetAxis("Vertical");
        rb.velocity = transform.forward*movementInput*speed;
    }
}
