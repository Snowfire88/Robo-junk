using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3;
    private CapsuleCollider col;
    public LayerMask groundMask;
    private Rigidbody body;
    public GameObject Ground;
    private float Jump = 6;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    private void Update() 
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        Debug.Log(isGrounded());

        if(Input.GetKeyDown(KeyCode.Space))
        {  
            if(isGrounded())
            {
                jump();
            }
        }
    }

    private void jump()
    {
        body.velocity = new Vector3(0, Jump, body.velocity.z);
    }

    public bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
            col.radius, groundMask);
    }
}
