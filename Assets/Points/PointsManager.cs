using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private float _defaultTime = .2f;

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
                _points[_activePlayer] += 1;

                if (_points[_activePlayer] > 999)
                    _points[_activePlayer] = 999;

                _timer = _defaultTime;
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
            _timer = _defaultTime;
            _points[activePlayer] += 1;

            _uiTexts[activePlayer].text = _points[activePlayer].ToString();
            _activePlayer = activePlayer;

            if (_points[_activePlayer] > 999)
                _points[_activePlayer] = 999;
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
            _RoundTwo = false;
            _timer = 0;
            _activePlayer = -1;

            if (_points[0] > _points[1])
            {
                SceneManager.LoadScene("GreenWinningScene");
            }
            else if (_points[0] < _points[1])
            {
                SceneManager.LoadScene("RedWinningScene");
            }
            else
            {
                SceneManager.LoadScene("DrawScene");
            }

            _points[0] = 0;
            _points[1] = 0;
            _uiTexts = new List<Text>();
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