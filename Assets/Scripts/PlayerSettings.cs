using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public static PlayerSettings Instance;

    public float musicVolume = 1.0f;
    public string cameraMode = "snap";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Asegura que no se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
