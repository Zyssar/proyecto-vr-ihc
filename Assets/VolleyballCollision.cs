using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolleyballCollision : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detectar colisión con las manos
        if (collision.gameObject.CompareTag("Hand"))
        {
            // Obtener la dirección del golpe
            Vector3 hitDirection = collision.contacts[0].normal * -1;
            float force = 10f; // Ajusta la fuerza según sea necesario
            rb.AddForce(hitDirection * force, ForceMode.Impulse);
        }
    }
}
