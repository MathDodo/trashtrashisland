using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField]
    private Text _uiText;

    private float _timer = 0;

    public int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
            if(_timer <= 0)
            {
                points += 5;
                _timer = 1;
                _uiText.text = points.ToString();
            }
        }
    }

    public void StartPoints()
    {
        _timer = 1;
        points += 5;
        _uiText.text = points.ToString();
    }

    void StopPoints()
    {
        _timer = 0;
    }

}
