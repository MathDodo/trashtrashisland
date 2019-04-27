using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class PointsManager : MonoBehaviour
{
    private static PointsManager _instance;

    public static PointsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Points");
                _instance = go.AddComponent<PointsManager>();
            }

            return _instance;
        }
    }

    [SerializeField]
    private Text[] _uiTexts;

    private int[] _points;

    private int _activePlayer;

    [SerializeField]
    private float _timer = 0;

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _points[_activePlayer] += 5;
                _timer = 1;
                _uiTexts[_activePlayer].text = _points.ToString();
            }
        }
    }

    /// <summary>
    /// Green is 0, red is 1
    /// </summary>
    /// <param name="activePlayer"></param>
    public void StartPoints(int activePlayer)
    {
        _timer = 1;
        _points[activePlayer] += 5;
        _uiTexts[activePlayer].text = _points.ToString();
        _activePlayer = activePlayer;
    }

    public void StopPoints()
    {
        _timer = 0;
        _activePlayer = -1;
    }
}