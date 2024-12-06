using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;  // Prefab de la bola
    public float minSpeed = 50f;    // Velocidad mínima
    public float maxSpeed = 50f;   // Velocidad máxima
    public float spawnInterval = 1f;  // Intervalo de generación en segundos
    public float ballLifetime = 5f;   // Tiempo de vida de cada bola en segundos

    private float currentSpeed;
    private Vector3 launchDirection;

    void Start()
    {
        InvokeRepeating("SpawnBall", 0f, spawnInterval);  // Llamar a la función de spawn repetidamente
    }

    void Update()
    {
        // Cambiar dirección con teclas
        if (Input.GetKey(KeyCode.UpArrow))  // Hacia arriba
            launchDirection = Vector3.up;
        else if (Input.GetKey(KeyCode.DownArrow))  // Hacia abajo
            launchDirection = Vector3.down;
        else if (Input.GetKey(KeyCode.LeftArrow))  // Hacia la izquierda
            launchDirection = Vector3.left;
        else if (Input.GetKey(KeyCode.RightArrow))  // Hacia la derecha
            launchDirection = Vector3.right;
        else
            launchDirection = Vector3.forward;  // Por defecto hacia adelante

        // Cambiar velocidad con teclas
        if (Input.GetKey(KeyCode.UpArrow))  // Aumentar velocidad
            currentSpeed = Mathf.Min(currentSpeed + 1f, maxSpeed);
        if (Input.GetKey(KeyCode.DownArrow))  // Reducir velocidad
            currentSpeed = Mathf.Max(currentSpeed - 1f, minSpeed);
    }

    void SpawnBall()
    {
        // Generar una bola en la posición actual del spawner
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);

        // Asignar velocidad y dirección aleatoria a la bola
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = launchDirection.normalized * currentSpeed;
        }

        // Destruir la bola después de un cierto tiempo
        Destroy(ball, ballLifetime);
    }
}
