using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed, zoomSpeed, minVerticalAngle, maxVerticalAngle, minZoom, maxZoom;
    public Camera cameraObject;

    Transform cameraTransform, zoomTransform;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        zoomTransform = cameraObject.GetComponent<Transform>();

    }

    void Update()
    {
        // Vertical rotation
        if (Input.GetKey(KeyCode.W)) RotateCamera(rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.S)) RotateCamera(-rotationSpeed * Time.deltaTime, 0);

        // Horizontal rotation
        if (Input.GetKey(KeyCode.A)) RotateCamera(0, rotationSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D)) RotateCamera(0, -rotationSpeed * Time.deltaTime);

        // Zoom
        if (Input.GetKey(KeyCode.Q)) ZoomCamera(zoomSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.E)) ZoomCamera(-zoomSpeed * Time.deltaTime);
    }

    void RotateCamera(float verticalRotation, float horizontalRotation)
    {
        // Rotate the camera
        Vector3 rotation = transform.rotation.eulerAngles + new Vector3(verticalRotation, horizontalRotation, 0f);

        // Clamp the vertical angle
        rotation.x = ClampAngle(rotation.x, minVerticalAngle, maxVerticalAngle);

        cameraTransform.eulerAngles = rotation;
    }

    float ClampAngle(float angle, float minAngle, float maxAngle)
    {
        // Clamp between a negative and positive angle to use for eulers
        if (angle < 0) angle = 360 + angle;
        if (angle > 180) return Mathf.Max(angle, 360 + minAngle);
        return Mathf.Min(angle, maxAngle);
    }

    void ZoomCamera(float zoom)
    {
        // Zoom the camera
        Vector3 zoomPosition = zoomTransform.localPosition + new Vector3(0, 0, zoom);

        // Clamp between min and max zoom
        zoomPosition.z = Mathf.Clamp(zoomPosition.z, minZoom, maxZoom);

        zoomTransform.localPosition = zoomPosition;
    }
}
