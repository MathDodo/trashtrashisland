using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Trash[] _trashPrefabs;

    [SerializeField]
    private GameObject _waterPrefab;

    [SerializeField]
    private Camera _main;

    [SerializeField]
    private int _amountToSpawnOfEach;

    private List<Trash> _activeTrash = new List<Trash>();
    private List<Trash> _inactiveTrash = new List<Trash>();

    private float _waterStartX;

    private void Start()
    {
        _waterStartX = _waterPrefab.transform.position.x;
        float currentY = _waterPrefab.transform.position.y;

        for (int x = 0; x < _amountToSpawnOfEach; x++)
        {
            for (int i = 0; i < _trashPrefabs.Length; i++)
            {
                Vector3 screenPosition = _main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), _main.farClipPlane / 2));
                var trashPiece = Instantiate(_trashPrefabs[i]);
                trashPiece.transform.SetParent(transform);
                trashPiece.transform.position = screenPosition;
                trashPiece._Spawner = this;

                _activeTrash.Add(trashPiece);
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
}