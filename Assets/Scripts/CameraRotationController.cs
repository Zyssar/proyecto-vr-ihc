using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class CameraRotationController : MonoBehaviour
{
    public float snapAngle = 35f;       // Ángulo de rotación para el modo snap
    public float smoothSpeed = 100f;    // Velocidad de rotación para el modo smooth
    public Button snapButton;           // Botón para activar el modo snap
    public Button smoothButton;         // Botón para activar el modo smooth

    private bool isSnapMode = true;     // Comienza en modo snap
    private float targetRotationY;      // Rotación objetivo en modo snap
    private Transform vrCamera;
    private InputDevice rightController;
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.gray;

    void Start()
    {
        // Asignamos la cámara VR; asegúrate de que sea el objeto correcto en tu escena
        vrCamera = Camera.main.transform;
        targetRotationY = vrCamera.eulerAngles.y;

        // Inicializamos el dispositivo del controlador izquierdo
        rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // Configura los listeners de los botones
        snapButton.onClick.AddListener(SetSnapMode);
        smoothButton.onClick.AddListener(SetSmoothMode);

        UpdateButtonStates();  // Actualizar el estado visual de los botones
    }

    void Update()
    {
        if (rightController.isValid)
        {
            // Obtener la entrada de la palanca izquierda
            Vector2 thumbstickInput = Vector2.zero;
            rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out thumbstickInput);

            if (isSnapMode)
            {
                HandleSnapRotation(thumbstickInput);
            }
            else
            {
                HandleSmoothRotation(thumbstickInput);
            }
        }
    }

    void HandleSnapRotation(Vector2 thumbstickInput)
    {
        // Si la palanca está empujada hacia los lados (izquierda o derecha)
        if (thumbstickInput.x > 0.5f)  // Girar a la derecha
        {
            targetRotationY += snapAngle;
        }
        else if (thumbstickInput.x < -0.5f)  // Girar a la izquierda
        {
            targetRotationY -= snapAngle;
        }

        // Aplicar la rotación inmediata en modo snap
        vrCamera.eulerAngles = new Vector3(vrCamera.eulerAngles.x, targetRotationY, vrCamera.eulerAngles.z);
    }

    void HandleSmoothRotation(Vector2 thumbstickInput)
    {
        // Rotación suave utilizando la entrada horizontal de la palanca
        float rotationAmount = thumbstickInput.x * smoothSpeed * Time.deltaTime;

        // Aplicar rotación continua en modo smooth
        vrCamera.Rotate(0, rotationAmount, 0);
    }

    // Función para activar el modo Snap
    public void SetSnapMode()
    {
        isSnapMode = true;
        UpdateButtonStates();
    }

    // Función para activar el modo Smooth
    public void SetSmoothMode()
    {
        isSnapMode = false;
        UpdateButtonStates();
    }

    // Actualizar el estado visual de los botones (opcional)
    void UpdateButtonStates()
    {
        snapButton.interactable = !isSnapMode;
        smoothButton.interactable = isSnapMode;
        if (isSnapMode)
        {
            snapButton.GetComponent<Image>().color = activeColor;
            smoothButton.GetComponent<Image>().color = inactiveColor;
        }
        else
        {
            snapButton.GetComponent<Image>().color = inactiveColor;
            smoothButton.GetComponent<Image>().color = activeColor;
        }
    }

    void OnDestroy()
    {
        // Elimina los listeners para evitar posibles errores de referencia nula
        snapButton.onClick.RemoveListener(SetSnapMode);
        smoothButton.onClick.RemoveListener(SetSmoothMode);
    }
}
