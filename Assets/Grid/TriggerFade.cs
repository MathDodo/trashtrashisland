using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFade : MonoBehaviour
{
    [SerializeField]
    private float _fadeTime = 1.5f;

    public bool _Fade = false;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_Fade)
        {
            var color = _spriteRenderer.color;
            color.a -= Time.deltaTime / _fadeTime;
            _spriteRenderer.color = color;

            if (color.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PointsManager.Instance._RoundTwo && collision.gameObject.CompareTag("Untagged") || collision.gameObject.CompareTag("Goal"))
        {
            _Fade = true;
        }
    }
}