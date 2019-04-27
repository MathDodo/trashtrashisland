﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class PointsManager : MonoBehaviour
{
    private static PointsManager _instance;

    public Spawner Spawner { get; internal set; }

    public static PointsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Points");
                _instance = go.AddComponent<PointsManager>();
                DontDestroyOnLoad(go);
            }

            return _instance;
        }
    }

    [SerializeField]
    private List<Text> _uiTexts = new List<Text>();

    public bool _RoundTwo = false;
    private int[] _points = { 0, 0 };

    private int _activePlayer = -1;

    [SerializeField]
    private float _timer = 0;

    public void AddUIText(Text text)
    {
        _uiTexts.Add(text);
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _points[_activePlayer] += 5;
                _timer = 1;
                _uiTexts[_activePlayer].text = _points[_activePlayer].ToString();
            }
        }
    }

    /// <summary>
    /// Green is 0, red is 1
    /// </summary>
    /// <param name="activePlayer"></param>
    public void PointCounting(int activePlayer)
    {
        if (_activePlayer == -1)
        {
            _timer = 1;
            _points[activePlayer] += 5;
            _uiTexts[activePlayer].text = _points[activePlayer].ToString();
            _activePlayer = activePlayer;
        }
        else if (!_RoundTwo)
        {
            _RoundTwo = true;
            _timer = 0;
            _activePlayer = -1;

            Spawner.StartRoundTwo();
        }
        else
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    public void ResetPoints()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = 0;
        }

        _timer = 0;
        _activePlayer = -1;
    }
}