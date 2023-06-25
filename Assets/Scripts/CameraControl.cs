using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public FixedTouchField TouchField;
    public Camera camera;
    
    [SerializeField] bool invertHorizontal = false;
    [SerializeField] bool invertVertical = false;
    
    [SerializeField] float CameraAngleSpeed = 0.2f;
    [SerializeField] float CameraPitchSpeed = 0.2f;

    [SerializeField] private Transform targetTransform;
    
    private float CameraAngle = 0f;
    private float CameraPitch = 0f;
    
    
    void Update()
    {
        float horizontalSign = invertHorizontal ? -1f : 1f;
        float verticalSign = invertVertical ? -1f : 1f;

        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed * horizontalSign;
        CameraPitch -= TouchField.TouchDist.y * CameraPitchSpeed * verticalSign;
        CameraPitch = Mathf.Clamp(CameraPitch, -90f, 90f);

        Vector3 cameraPosition = targetTransform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * Quaternion.AngleAxis(CameraPitch, Vector3.right) * new Vector3(0, 3, 4);
        Quaternion cameraRotation = Quaternion.LookRotation(targetTransform.position + Vector3.up * 2f - cameraPosition, Vector3.up);
        camera.transform.position = cameraPosition;
        camera.transform.rotation = cameraRotation;
    }

}