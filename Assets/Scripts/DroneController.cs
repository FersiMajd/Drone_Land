using CnControls;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float DroneMaxAltitude, FlySpeed, RotationSpeed, LeanSpeed, LeanLimit, DroneFloorLevel;
    public Transform DroneChasis, CollisionSpark;

    private float _verticalAxis, _horizontalAxis, _forwardLean, _sideLean;
    private RaycastHit _groundHit;

    void Update()
    {
        ManageInpout();
        UpdateDroneVisuals();
    }
    void OnCollisionEnter(Collision colliderObject)
    {
        Instantiate(CollisionSpark, colliderObject.contacts[0].thisCollider.transform);
    }

    private void ManageInpout()
    {
        _verticalAxis = CnInputManager.GetAxis("Vertical") * Time.deltaTime * FlySpeed;
        _forwardLean = -Input.acceleration.z * Time.deltaTime * LeanSpeed;
        _sideLean = Input.acceleration.x * Time.deltaTime * LeanSpeed;
        _horizontalAxis = CnInputManager.GetAxis("Horizontal") * Time.deltaTime * RotationSpeed;
        Physics.Raycast(transform.position, Vector3.down, out _groundHit, DroneMaxAltitude);
        if (_groundHit.collider != null && _groundHit.collider.tag == "Environment" &&
            Vector3.Distance(transform.position, _groundHit.point) < DroneFloorLevel && _verticalAxis < 0)
        {
            _verticalAxis = 0;
        }
        if (_groundHit.collider != null && _groundHit.collider.tag == "Environment" &&
            Vector3.Distance(transform.position, _groundHit.point) > DroneMaxAltitude - 2 && _verticalAxis > 0)
        {
            _verticalAxis = 0;
        }
    }
    private void UpdateDroneVisuals()
    {
        transform.Rotate(Vector3.up, _horizontalAxis);
        var angle = Quaternion.Euler(LeanLimit * _forwardLean, transform.rotation.eulerAngles.y, LeanLimit * -_sideLean);
        DroneChasis.rotation = angle;
        transform.Translate(new Vector3(_sideLean, _verticalAxis, _forwardLean));
    }
}