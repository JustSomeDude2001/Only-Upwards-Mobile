using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnFall : MonoBehaviour
{
    public CharacterController characterController;
    public Transform respawnPoint;
    public float attitudeThreshold = -20;

    private void Respawn()
    {
        characterController.enabled = false;
        transform.position = respawnPoint.position;
        characterController.enabled = true;
        Debug.Log("Respawning");
        
        // Add other actions on respawn;
    }
    
    private void Update()
    {
        if (transform.position.y < attitudeThreshold)
        {
            Respawn();
        } 
    }
}
