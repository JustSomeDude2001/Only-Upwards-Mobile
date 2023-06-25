using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Lean.Touch;

public class FingerOnUIChecker : MonoBehaviour
{
    public static CinemachineInputProvider cinemachineInputProvider;

    private void Start()
    {
        cinemachineInputProvider = GameObject.FindObjectOfType<CinemachineInputProvider>();
    }

    private void Update()
    {
        var fingers = LeanTouch.Fingers.FindAll(x => x.Set);
        if (cinemachineInputProvider.enabled == false && fingers.Exists(x => !x.StartedOverGui))
        {
            cinemachineInputProvider.enabled = true; 
        } else if (cinemachineInputProvider.enabled && fingers.Exists(x => x.StartedOverGui))
        { 
            cinemachineInputProvider.enabled = false;
        }
    }
}
