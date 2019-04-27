using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointUI : MonoBehaviour
{
    [SerializeField]
    private Text _green, _red;

    private void Start()
    {
        PointsManager.Instance.AddUIText(_green);
        PointsManager.Instance.AddUIText(_red);
    }
}