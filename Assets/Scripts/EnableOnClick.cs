using UnityEngine;
using UnityEngine.EventSystems;

public class EnableOnClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject objectToEnable;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
            Debug.Log($"{objectToEnable.name} habilitado por OnPointerClick.");
        }
        else
        {
            Debug.LogError("No se asignó el objeto a habilitar.");
        }
    }
}
