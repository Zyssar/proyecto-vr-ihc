using UnityEngine;

public class VRPlayerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform cameraRig;  // La cámara VR o el rig

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Toma la dirección en la que está mirando la cámara
        Vector3 forward = cameraRig.forward;
        Vector3 right = cameraRig.right;

        // Asegúrate de que la dirección esté en el plano horizontal
        forward.y = 0;
        right.y = 0;

        // Normaliza las direcciones para evitar que el movimiento sea más rápido en diagonal
        forward.Normalize();
        right.Normalize();

        // Calcula la dirección de movimiento
        Vector3 moveDirection = forward * vertical + right * horizontal;

        // Aplica el movimiento al objeto del jugador
        cameraRig.position += moveDirection * speed * Time.deltaTime;
    }
}
