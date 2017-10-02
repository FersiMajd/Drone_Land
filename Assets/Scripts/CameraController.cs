using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 CameraPlayerOffset;
    public float SmoothSpeed;

    private Vector3 _velocity = Vector3.zero;
    private Transform _player;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, _player.position + CameraPlayerOffset, ref _velocity, SmoothSpeed);
        Camera.main.transform.LookAt(_player.position);
    }
}
