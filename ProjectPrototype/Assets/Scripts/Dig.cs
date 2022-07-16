using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : MonoBehaviour
{
    public GameObject ground;
    private Rigidbody rb;
    private float digSpd = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(transform.position.y > 0)
                StartCoroutine(dig());
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            if(transform.position.y < 0)
            {
                StartCoroutine(Undig());
            }
        }

    }

    IEnumerator dig()
    {
        rb.useGravity = false;
        ground.GetComponent<BoxCollider>().enabled = false;
        rb.velocity = new Vector3(0, -1 * digSpd, rb.velocity.z);
        yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector3(0, 0, rb.velocity.z);
    }

    IEnumerator Undig()
    {
        rb.velocity = new Vector3(0, 1 * digSpd, rb.velocity.z);
        yield return new WaitForSeconds(0.5f);
        rb.useGravity = true;
        ground.GetComponent<BoxCollider>().enabled = true;
        rb.velocity = new Vector3(0, 0, rb.velocity.z);
    }
}
