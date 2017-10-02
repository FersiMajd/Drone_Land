using DG.Tweening;
using UnityEngine;

public class DroneAI : MonoBehaviour
{
    public float DroneSpeed, DroneRotationSpeed, Health;

    private Transform[] _pathHolder;
    private int _positionIndex;
    private bool _startRacing, _onWayPoint;
    private Tween _moveTween;

    void Start()
    {
        InitDrone();
    }

    void Update()
    {
        if (!_startRacing) return;
        if (_positionIndex < _pathHolder.Length)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _pathHolder[_positionIndex].rotation, DroneRotationSpeed * Time.deltaTime);
        }
        if (_positionIndex < _pathHolder.Length && !_onWayPoint)
        {
            _moveTween = transform.DOMove(_pathHolder[_positionIndex].position, DroneSpeed).SetEase(Ease.Linear).OnComplete(FinishedWayPoint);
            _positionIndex++;
            _onWayPoint = !_onWayPoint;
        }



    }

    private void InitDrone()
    {
        _pathHolder = new Transform[LevelManager.MainLevelManager.LevelRacePath.childCount];
        for (int i = 0; i < _pathHolder.Length; i++)
        {
            _pathHolder[i] = LevelManager.MainLevelManager.LevelRacePath.GetChild(i);
        }
        _startRacing = true;

    }

    private void FinishedWayPoint()
    {
        _onWayPoint = !_onWayPoint;
    }
}
