using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Trash _tilePrefab;

    private List<Trash> _activeTrash = new List<Trash>();
    private List<Trash> _inactiveTrash = new List<Trash>();

    private void Awake()
    {
        Vector2 pos = _tilePrefab.transform.position;
        var startX = pos.x;

        for (int y = 0; y < 160; y++)
        {
            for (int x = 0; x < 320; x++)
            {
                var trashPiece = Instantiate(_tilePrefab);
                trashPiece.transform.SetParent(transform);
                trashPiece.transform.position = pos;
                trashPiece._Spawner = this;

                _activeTrash.Add(trashPiece);
                pos.x += .070f;
            }

            pos.x = startX;
            pos.y += .07f;
        }
    }
}