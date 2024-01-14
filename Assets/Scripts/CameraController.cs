using UnityEngine;


public class CameraController : MonoBehaviour {
    public Transform target;
    public Vector3 positionOffset = new(0, 2, -8);
    public float sensitivity = 2f;

    private float _angleX;
    private float _angleY;
    public Vector2 yRotationRange;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        _angleX += Input.GetAxis("Mouse X") * sensitivity;
        _angleY += Input.GetAxis("Mouse Y") * sensitivity;

        _angleY = Mathf.Clamp(_angleY, yRotationRange.x, yRotationRange.y);

        Quaternion rotation = Quaternion.Euler(-_angleY, _angleX, 0);
        Vector3 position = rotation * positionOffset + target.transform.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}