using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Trash _tilePrefab;

    [SerializeField]
    private Camera _main;

    [SerializeField]
    private int _amountToSpawn;

    private List<Trash> _activeTrash = new List<Trash>();
    private List<Trash> _inactiveTrash = new List<Trash>();

    private void Start()
    {
        for (int x = 0; x < _amountToSpawn; x++)
        {
            Vector3 screenPosition = _main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), _main.farClipPlane / 2));
            var trashPiece = Instantiate(_tilePrefab);
            trashPiece.transform.SetParent(transform);
            trashPiece.transform.position = screenPosition;
            trashPiece._Spawner = this;

            _activeTrash.Add(trashPiece);
        }
    }
}