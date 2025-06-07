using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform hole;
    [SerializeField] private Vector3 baseOffset; 
    [SerializeField] private float scaleMultiplierY; 
    [SerializeField] private float scaleMultiplierZ;
    [SerializeField] private float rotationSmoothness; 

    private Vector3 velocity;
    private float currentAngle;

    private void LateUpdate()
    {
        if (hole == null) return;

        float holeScale = hole.localScale.x;

        float newY = baseOffset.y + holeScale * scaleMultiplierY;
        float newZ = baseOffset.z - holeScale * scaleMultiplierZ;

        Vector3 desiredPosition = new Vector3(hole.position.x, newY, hole.position.z + newZ);

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.2f);

        float targetAngle = hole.rotation.eulerAngles.y;
        currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * rotationSmoothness);
        transform.rotation = Quaternion.Euler(15f, currentAngle, 0f);

        transform.LookAt(hole.position);
    }
    
}
