using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Trash[] _highChanceTrashPrefabs;

    [SerializeField]
    private Trash[] _lowChanceTrashPrefabs;

    [SerializeField]
    private GameObject _waterPrefab;

    [SerializeField]
    private Camera _main;

    [SerializeField]
    private int _amountToSpawnOfEach;

    [SerializeField]
    private BoatMovement _greenJet, _redJet;

    [SerializeField, Range(.5f, .9f)]
    private float _probability = .7f;

    private List<Trash> _activeTrash = new List<Trash>();
    private List<Trash> _inactiveTrash = new List<Trash>();

    private float _waterStartX;
    private Vector2 _greenCorner = new Vector2(1.88f, 1.03f), _redCorner = new Vector2(-1.88f, -1.03f);

    private Vector3 _startTrashCorner = new Vector3(-1.88f, 1.03f, 0);

    private void Start()
    {
        PointsManager.Instance.Spawner = this;
        _waterStartX = _waterPrefab.transform.position.x;
        float currentY = _waterPrefab.transform.position.y;

        var offset = .16f;
        var rangeOffset = .04f;

        for (int y = 0; y < 14; y++)
        {
            for (int x = 0; x < 24; x++)
            {
                if (!((x == 12 || x == 11) && (y == 7 || y == 6)))
                {
                    if (UnityEngine.Random.value <= _probability)
                    {
                        var trash = Instantiate(_highChanceTrashPrefabs[UnityEngine.Random.Range(0, _highChanceTrashPrefabs.Length)], _startTrashCorner + new Vector3(offset * x + UnityEngine.Random.Range(-rangeOffset, rangeOffset),
                            offset * -y + UnityEngine.Random.Range(-rangeOffset, rangeOffset), 0), Quaternion.identity, transform);

                        trash._Spawner = this;

                        _activeTrash.Add(trash);
                    }
                    else
                    {
                        var trash = Instantiate(_lowChanceTrashPrefabs[UnityEngine.Random.Range(0, _lowChanceTrashPrefabs.Length)], _startTrashCorner + new Vector3(offset * x + UnityEngine.Random.Range(-rangeOffset, rangeOffset),
                            offset * -y + UnityEngine.Random.Range(-rangeOffset, rangeOffset), 0), Quaternion.identity, transform);

                        trash._Spawner = this;

                        _activeTrash.Add(trash);
                    }
                }
            }
        }

        for (int y = 0; y < 7; y++)
        {
            for (int x = 0; x < 13; x++)
            {
                Instantiate(_waterPrefab, new Vector3(_waterStartX + .32f * x, currentY, 0), Quaternion.identity, transform);
            }

            currentY -= .32f;
        }
    }

#if UNITY_EDITOR || DEVELOPMENT_BUILD

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

#endif

    internal void StartRoundTwo()
    {
        for (int i = 0; i < _activeTrash.Count; i++)
        {
            _activeTrash[i].GetComponent<Collider2D>().isTrigger = false;
        }

        Instantiate(_greenJet, _greenCorner, Quaternion.identity);
        Instantiate(_redJet, _redCorner, Quaternion.identity);
    }

    internal void Remove(Trash trash)
    {
        _activeTrash.Remove(trash);
    }
}