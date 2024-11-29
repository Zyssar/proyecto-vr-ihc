using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del bloque
    public float rotateSpeed = 100f; // Velocidad de rotación del bloque
    public Camera mainCamera; // Cámara que controlaremos

    private Vector3 moveDirection;
    private float rotationX;
    private float rotationY;

    void Update()
    {
        // Mover el bloque con teclas
        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))  // Hacia adelante
            moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S))  // Hacia atrás
            moveDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A))  // Hacia la izquierda
            moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D))  // Hacia la derecha
            moveDirection += Vector3.right;
        if (Input.GetKey(KeyCode.Space))  // Hacia arriba
            moveDirection += Vector3.up;
        if (Input.GetKey(KeyCode.LeftControl))  // Hacia abajo
            moveDirection += Vector3.down;

        // Aplicar el movimiento
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Rotación del bloque con teclas
        if (Input.GetKey(KeyCode.Q))  // Rotar hacia la izquierda
            rotationY -= rotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E))  // Rotar hacia la derecha
            rotationY += rotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.R))  // Rotar hacia arriba
            rotationX -= rotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.F))  // Rotar hacia abajo
            rotationX += rotateSpeed * Time.deltaTime;

        // Aplicar la rotación
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);

        // Controlar la cámara (opcional)
        HandleCameraMovement();
    }

    void HandleCameraMovement()
    {
        if (mainCamera != null)
        {
            float moveX = Input.GetAxis("Horizontal") * 5f * Time.deltaTime;  // Movimiento lateral
            float moveY = Input.GetAxis("Vertical") * 5f * Time.deltaTime;    // Movimiento hacia adelante y atrás
            float moveZ = 0f;

            if (Input.GetKey(KeyCode.Q)) moveZ = 1f;  // Movimiento hacia arriba
            if (Input.GetKey(KeyCode.Z)) moveZ = -1f; // Movimiento hacia abajo

            // Movimiento de la cámara
            mainCamera.transform.Translate(moveX, moveY, moveZ);
        }
    }
}
