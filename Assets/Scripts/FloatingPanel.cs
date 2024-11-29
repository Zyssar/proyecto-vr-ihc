using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPanel : MonoBehaviour
{
    public Transform cameraRigTransform; // Rig o c�mara del Oculus Quest 2
    public float distanceFromPlayer = 2f; // Distancia desde el jugador
    public float heightOffset = 1.5f; // Altura adicional del panel

    void Update()
    {
        if (cameraRigTransform != null)
        {
            // Posici�n del panel respecto a la posici�n del rig/c�mara
            Vector3 newPosition = cameraRigTransform.position + 
                                  cameraRigTransform.forward * distanceFromPlayer + 
                                  Vector3.up * heightOffset;

            // Actualiza la posici�n del panel
            transform.position = newPosition;

            // Hace que el panel mire hacia el rig/c�mara
            Vector3 lookDirection = cameraRigTransform.position - transform.position;
            lookDirection.y = 0; // Mantener solo la rotaci�n horizontal
            transform.rotation = Quaternion.LookRotation(-lookDirection);
        }
    }
}
