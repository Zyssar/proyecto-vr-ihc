using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableOnClick : MonoBehaviour, IPointerClickHandler
{
    public Behaviour componentToDisable;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (componentToDisable != null)
        {
            componentToDisable.enabled = false;
            Debug.Log("Componente deshabilitado por OnPointerClick.");
        }
        else
        {
            Debug.LogError("No se asignó el componente a deshabilitar.");
        }
    }

}
