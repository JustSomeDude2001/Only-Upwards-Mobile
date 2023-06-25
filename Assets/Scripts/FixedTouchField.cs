using Lean.Touch;
using UnityEngine;

public class FixedTouchField : MonoBehaviour
{
    [HideInInspector] public LeanFinger currentFinger;
    [HideInInspector] public Vector2 TouchDist = Vector2.zero;
    [HideInInspector] public Vector2 PointerOld;
    [HideInInspector] public bool Pressed = false;
    [HideInInspector] public bool PressedLastFrame = false;

    private void OnEnable()
    {
        // Hook up Lean Touch events
        LeanTouch.OnFingerDown += OnFingerDown;
        LeanTouch.OnFingerUp += OnFingerUp;
    }

    private void OnDisable()
    {
        // Unhook Lean Touch events
        LeanTouch.OnFingerDown -= OnFingerDown;
        LeanTouch.OnFingerUp -= OnFingerUp;
    }

    private void Update()
    {
        if (Pressed)
        {
            if (currentFinger != null && currentFinger.IsActive)
            {
                TouchDist = currentFinger.ScreenPosition - PointerOld;
                PointerOld = currentFinger.ScreenPosition;
            }
            else
            {
                Debug.Log("No finger on screen");
                currentFinger = null;
                TouchDist = Vector2.zero;
                Pressed = false;
            }
            if (!PressedLastFrame)
            {
                PressedLastFrame = true;
                TouchDist = Vector2.zero;
            }
        }
    }

    private void OnFingerDown(LeanFinger finger)
    {
        if (currentFinger == null && !finger.IsOverGui)
        {
            Debug.Log("Finger Pushed");
            currentFinger = finger;
            PointerOld = finger.ScreenPosition;
            Pressed = true;
            PressedLastFrame = false;
        }
    }

    private void OnFingerUp(LeanFinger finger)
    {
        if (currentFinger == null || !currentFinger.IsActive)
        {
            Debug.Log("Finger Lifted");
            currentFinger = null;
            Pressed = false;
            PressedLastFrame = false;
        }
    }
}