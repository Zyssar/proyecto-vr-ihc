using UnityEngine;

public class PrefabLauncher : MonoBehaviour
{
    [Header("Prefab Settings")]
    public GameObject prefab; // El prefab a generar
    public Transform spawnPoint; // Punto de aparición del prefab
    public float spawnInterval = 2.0f; // Tiempo entre cada generación

    [Header("Launch Settings")]
    public float launchForce = 10.0f; // Fuerza de lanzamiento
    public float launchAngle = 45.0f; // Ángulo de lanzamiento en grados

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            LaunchPrefab();
            timer = 0.0f;
        }
    }

    void LaunchPrefab()
    {
        if (prefab != null && spawnPoint != null)
        {
            // Instanciar el prefab en el punto de generación
            GameObject newObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);

            // Obtener el Rigidbody del prefab
            Rigidbody rb = newObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Calcular la dirección del lanzamiento
                float angleInRadians = launchAngle * Mathf.Deg2Rad;
                Vector3 launchDirection = new Vector3(
                    Mathf.Cos(angleInRadians),
                    Mathf.Sin(angleInRadians),
                    0
                );

                // Aplicar fuerza al Rigidbody
                rb.AddForce(launchDirection * launchForce, ForceMode.VelocityChange);
            }
        }
    }
}
