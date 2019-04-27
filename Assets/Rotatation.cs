using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatation : MonoBehaviour
{
    [SerializeField]
    private float _wobbleSpeed = 10;

    [SerializeField]
    private float _wobbleRange = 45;

    [SerializeField]
    private Transform[] _children;

    private bool _positiveWobble = true;
    private float _wobbleSpeedTenth;
    private float _wobble;
    private float _startRotation;

    private void Start()
    {
        _wobbleSpeedTenth = _wobbleSpeed / 10;
        _startRotation = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < _children.Length; i++)
        {
            _children[i].Rotate(new Vector3(0, 0, _positiveWobble ? Time.deltaTime * _wobbleSpeed : Time.deltaTime * -_wobbleSpeed));
        }

        if (_children[0].rotation.eulerAngles.z >= _startRotation + _wobbleRange || _children[0].rotation.eulerAngles.z <= _startRotation)
        {
            _positiveWobble = !_positiveWobble;
            _wobbleSpeed = _wobbleSpeedTenth * 10;
        }

        _wobbleSpeed = Mathf.Lerp(_wobbleSpeed, _wobbleSpeedTenth, Time.deltaTime * .1f);
    }
}