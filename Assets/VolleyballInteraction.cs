using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VolleyballInteractions : MonoBehaviour
{
    private XRGrabInteractable grabbable; // Componente grabbable de la pelota
    private bool isGrabbed = false; // Estado de agarre
    private XRBaseInteractor currentInteractor; // La mano actual que agarra la pelota

    private void Awake()
    {
        // Obtén la referencia al script grabbable
        grabbable = GetComponent<XRGrabInteractable>();
        if (grabbable == null)
        {
            Debug.LogError("El componente XRGrabInteractable no está adjunto al objeto.");
            return;
        }

        // Registra eventos de interacción
        grabbable.selectEntered.AddListener(OnGrabbed);
        grabbable.selectExited.AddListener(OnReleased);
    }

    private void OnDestroy()
    {
        // Desregistra eventos si el componente es válido
        if (grabbable != null)
        {
            grabbable.selectEntered.RemoveListener(OnGrabbed);
            grabbable.selectExited.RemoveListener(OnReleased);
        }
    }

    // Evento: Cuando se agarra la pelota
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        currentInteractor = args.interactor;
        Debug.Log($"Pelota agarrada por: {currentInteractor?.name}");
    }

    // Evento: Cuando se suelta la pelota
    private void OnReleased(SelectExitEventArgs args)
    {
        isGrabbed = false;
        currentInteractor = null;
        Debug.Log("Pelota soltada.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si está agarrada y colisiona con un objeto relevante (ejemplo: otra mano)
        if (isGrabbed && collision.gameObject.CompareTag("Hand"))
        {
            Debug.Log("Colisión detectada con otra mano.");

            // Intenta desactivar el agarre actual
            grabbable.interactionManager?.SelectExit(currentInteractor, grabbable);
        }
    }

    private void Update()
    {
        // Lógica específica para acciones de juego (sacar, bolear, etc.)
        if (isGrabbed && currentInteractor != null)
        {
            HandleActions();
        }
    }

    private void HandleActions()
    {
        // Detectar acciones específicas basadas en la posición y orientación
        if (transform.position.y > 1.5f) // Ejemplo: Altura para "Sacar"
        {
            Debug.Log("Acción: Sacar");
        }
        else if (transform.position.y < 0.5f) // Ejemplo: Altura para "Recepcionar"
        {
            Debug.Log("Acción: Recepcionar");
        }
        // Agrega más condiciones para "Bolear" y "Matar" según el contexto
    }
}
