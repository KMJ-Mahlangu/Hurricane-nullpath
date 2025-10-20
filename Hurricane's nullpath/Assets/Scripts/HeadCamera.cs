using UnityEngine;

public class HeadCamera : MonoBehaviour
{
    public Transform cameraAnchor;
    public Transform mainCamera;
    public float followSpeed = 10f;

    void LateUpdate()
    {
        // Smoothly follow head position
        mainCamera.position = Vector3.Lerp(mainCamera.position, cameraAnchor.position, Time.deltaTime * followSpeed);
        mainCamera.rotation = Quaternion.Lerp(mainCamera.rotation, cameraAnchor.rotation, Time.deltaTime * followSpeed);
    }
}
