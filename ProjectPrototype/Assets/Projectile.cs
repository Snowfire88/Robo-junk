using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 3;
    private Rigidbody body;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
