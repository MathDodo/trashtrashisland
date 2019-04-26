using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField]
    private Text _uiText;

    private int _points = 0;
    private float _timer = 0;

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _points += 5;
                _timer = 1;
                _uiText.text = _points.ToString();
            }
        }
    }

    public void StartPoints()
    {
        _timer = 1;
        _points += 5;
        _uiText.text = _points.ToString();
    }

    public void StopPoints()
    {
        _timer = 0;
    }
}