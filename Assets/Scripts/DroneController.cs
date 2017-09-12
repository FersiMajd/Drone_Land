using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float DroneMaxAltitude, FlySpeed, RotationSpeed;

    private float _verticalAxis, _horizontalAxis;
    private Vector3 _velocity = Vector3.zero;

    void Update()
    {
        _verticalAxis = Input.GetAxis("Vertical") * Time.deltaTime * FlySpeed;
        _horizontalAxis = Input.GetAxis("Horizontal") * Time.deltaTime * RotationSpeed;

        transform.position += Vector3.up * _verticalAxis;
        transform.Rotate(Vector3.up, _horizontalAxis);

        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, transform.position + Vector3.one, ref _velocity, 10);
        Camera.main.transform.LookAt(transform.position);
    }
}