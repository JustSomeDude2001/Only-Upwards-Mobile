using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Lean.Touch;

public class FingerOnUIChecker : MonoBehaviour
{
    public static bool isTouchingUI;
    public static CinemachineInputProvider cinemachineInputProvider;

    private void Start()
    {
        cinemachineInputProvider = GameObject.FindObjectOfType<CinemachineInputProvider>();
    }

    private void OnEnable()
    {
        LeanTouch.OnFingerDown += HandleFingerDown;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerDown -= HandleFingerDown;
    }

    private void HandleFingerDown(LeanFinger finger)
    {
        if (finger.IsOverGui)
        {
            isTouchingUI = true;
            cinemachineInputProvider.enabled = false;
            Debug.Log("Finger on GUI");
        }
    }

    private void Update()
    {
        if (isTouchingUI && !LeanTouch.Fingers.Exists(x => x.IsOverGui))
        {
            isTouchingUI = false;
            cinemachineInputProvider.enabled = true;
            Debug.Log("No Finger on GUI");
        }
    }
}
