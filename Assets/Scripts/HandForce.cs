using UnityEngine;

public class HandForce : MonoBehaviour
{
    public float forceMultiplier; // Ajusta la magnitud de la fuerza aplicada
    private Vector3 lastPosition; // Última posición de la mano
    private Vector3 velocity; // Velocidad calculada de la mano

    void Start()
    {
        // Inicializamos la última posición
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Calcular la velocidad de la mano
        velocity = (transform.position - lastPosition) / Time.fixedDeltaTime;
        lastPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("VolleyBall"))
        {
            // Obtener el Rigidbody de la pelota
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (ballRigidbody != null)
            {
                // Aplicar fuerza proporcional a la velocidad de la mano
                Vector3 forceDirection = velocity.normalized;
                float forceMagnitude = velocity.magnitude * forceMultiplier;

                ballRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
            }
        }
    }
}