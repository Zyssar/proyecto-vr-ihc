using UnityEngine;
using UnityEngine.EventSystems;

public class DisableOnClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject objectToDisable;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
            Debug.Log($"{objectToDisable.name} deshabilitado por OnPointerClick.");
        }
        else
        {
            Debug.LogError("No se asignó el objeto a deshabilitar.");
        }
    }
}
