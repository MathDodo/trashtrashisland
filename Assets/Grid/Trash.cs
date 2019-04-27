using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField]
    private float _wobbleSpeed = 10;

    [SerializeField]
    private float _wobbleRange = 45;

    [SerializeField]
    private Transform[] _children;

    [SerializeField]
    private float _movementSpeed = .025f;

    private float _wobbleSpeedTenth;
    private float _wobble;
    private float _startRotation;
    private bool _positiveWobble = true;
    private Vector3 _startPos;
    public Spawner _Spawner;

    private void Start()
    {
        _movementSpeed = Random.Range(0, 1) == 0 ? _movementSpeed : _movementSpeed * -1;

        _startPos = transform.position;
        _wobbleSpeedTenth = _wobbleSpeed / 10;
        var rotationZ = Random.Range(0, 360);

        _startRotation = rotationZ;

        for (int i = 0; i < _children.Length; i++)
        {
            _children[i].rotation = Quaternion.Euler(new Vector3(0, 0, rotationZ));
        }
    }

    private void Update()
    {
        transform.position = _startPos + new Vector3(Mathf.Sin(Time.time + transform.position.x + transform.position.y) * _movementSpeed, 0.0f, 0.0f);

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