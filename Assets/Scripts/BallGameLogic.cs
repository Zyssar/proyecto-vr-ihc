using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGameLogic : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
    //        Vector3 bounceDirection = transform.position - collision.transform.position;
    //       rb.AddForce(bounceDirection.normalized * 300f);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("El balón tocó el suelo. Pérdida de punto.");
        }
        else if (collision.gameObject.CompareTag("Net"))
        {
            Debug.Log("toco net");
        }
    }
}
