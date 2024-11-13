using UnityEngine;

public class VRPlayerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform cameraRig;  // La c�mara VR o el rig

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Toma la direcci�n en la que est� mirando la c�mara
        Vector3 forward = cameraRig.forward;
        Vector3 right = cameraRig.right;

        // Aseg�rate de que la direcci�n est� en el plano horizontal
        forward.y = 0;
        right.y = 0;

        // Normaliza las direcciones para evitar que el movimiento sea m�s r�pido en diagonal
        forward.Normalize();
        right.Normalize();

        // Calcula la direcci�n de movimiento
        Vector3 moveDirection = forward * vertical + right * horizontal;

        // Aplica el movimiento al objeto del jugador
        cameraRig.position += moveDirection * speed * Time.deltaTime;
    }
}
