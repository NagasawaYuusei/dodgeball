using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] TimeManager _tm;
    [SerializeField] Text _timeText;
    [SerializeField] Text _scoreTextOne;
    [SerializeField] Text _scoreTextTwo;

    void Update()
    {
        _timeText.text = _tm.CurrentTime.ToString("F2");
        _scoreTextOne.text = String.Format("{0:D3}", GameManager.Score[0]);
        _scoreTextTwo.text = String.Format("{0:D3}", GameManager.Score[1]);
    }
}
