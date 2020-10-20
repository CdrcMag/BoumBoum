using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movement : MonoBehaviour
{

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private float x;
    private float z;

    public float constantSpeed;
    public float resetTime;

    private bool canCollide = true;

    private void Start()
    {
        x = Random.Range(-20, 20);
        z = Random.Range(-20, 20);

        rb.AddForce(new Vector3(x, 0, z), ForceMode.VelocityChange);
        
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        rb.velocity = constantSpeed * (rb.velocity.normalized);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(canCollide)
            {
                StartCoroutine(resetHit());
            }
                
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blocker"))
        {
            if (canCollide)
            {
                StartCoroutine(resetHit());
            }
        }
    }

    
    IEnumerator resetHit()
    {
        canCollide = false;
        yield return new WaitForSeconds(resetTime);
        canCollide = true;
    }

}
