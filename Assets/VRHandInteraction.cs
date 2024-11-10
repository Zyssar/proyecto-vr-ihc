using UnityEngine;

public class VRHandInteraction : MonoBehaviour
{
    public Transform handTransform;   // Posición de la mano
    public float grabRadius = 0.1f;   // Radio de detección para asistencia al agarrar
    public float assistStrength = 2f; // Fuerza de asistencia para mover la bola hacia la mano (sin pegarla)
    public LayerMask ballLayer;       // Capa de la esfera

    private Rigidbody ballRigidbody;
    private bool isHoldingBall = false;

    void Update()
    {
        // Verifica si la bola está cerca para activar la asistencia sin adherirla
        if (!isHoldingBall)
        {
            Collider[] colliders = Physics.OverlapSphere(handTransform.position, grabRadius, ballLayer);
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    // Añade una pequeña fuerza hacia la mano si está cerca (pero no "agarra" la bola)
                    Vector3 directionToHand = (handTransform.position - rb.position).normalized;
                    rb.AddForce(directionToHand * assistStrength, ForceMode.Acceleration);
                }
            }
        }

        // Agarrar la pelota cuando se pulsa un botón
        if (!isHoldingBall && Input.GetButtonDown("Fire1"))
        {
            Collider[] colliders = Physics.OverlapSphere(handTransform.position, grabRadius, ballLayer);
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    ballRigidbody = rb;
                    ballRigidbody.isKinematic = true;  // Hace la pelota kinemática al agarrarla
                    ballRigidbody.transform.position = handTransform.position;  // Coloca la pelota en la mano
                    ballRigidbody.transform.parent = handTransform;  // Vincula la pelota a la mano
                    isHoldingBall = true;
                    break;
                }
            }
        }

        // Soltar la pelota cuando se suelta el botón
        if (isHoldingBall && Input.GetButtonUp("Fire1"))
        {
            ReleaseBall();
        }
    }

    private void ReleaseBall()
    {
        if (isHoldingBall)
        {
            isHoldingBall = false;
            ballRigidbody.isKinematic = false;  // Deja de ser kinemática para permitir física normal
            ballRigidbody.transform.parent = null;  // Desvincula la pelota de la mano

            // Añade la velocidad de la mano al soltar la pelota
            ballRigidbody.velocity = handTransform.GetComponent<Rigidbody>().velocity;
            ballRigidbody.angularVelocity = handTransform.GetComponent<Rigidbody>().angularVelocity;
            ballRigidbody = null;
        }
    }
}
