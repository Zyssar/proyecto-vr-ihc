using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPanel : MonoBehaviour
{
    public Transform playerTransform;
    public float distanceFromPlayer = 2f;

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 newPosition = playerTransform.position + playerTransform.forward * distanceFromPlayer;
            transform.position = newPosition;
            transform.LookAt(playerTransform);
            transform.Rotate(0, 180, 0); // Girar el panel para que mire al jugador
        }
    }
}
