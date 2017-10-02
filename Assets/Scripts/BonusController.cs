using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Timeline;

public class BonusController : MonoBehaviour
{
    public float Duration, Strength,  Randamness;
    public int Viberation;
    public Transform[] BonusObjects = new Transform[0];

    private bool _engaged;
    // Use this for initialization
    void Start ()
    {

        transform.DOShakePosition(Duration, Strength, Viberation, Randamness).SetEase(Ease.Linear).OnComplete(FloatAround);
    }

    private void OnTriggerEnter(Collider colliderObject)
    {
        if (colliderObject.tag == "Player" && !_engaged)
        {
            _engaged = !_engaged;
            Destroy(gameObject);
        }
        if (colliderObject.tag == "Enemey" && !_engaged)
        {
            _engaged = !_engaged;
            Destroy(gameObject);
        }
    }

    private void FloatAround()
    {
        transform.DOShakePosition(Duration, Strength, Viberation, Randamness).SetEase(Ease.Linear).OnComplete(FloatAround);
    }
}
