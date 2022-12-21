using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float _currentTime = 0;
    [SerializeField] float _finishTime = 30;

    public float CurrentTime => _currentTime;

    void Update()
    {
        CountTime();
        IsFinish();
    }

    void CountTime()
    {
        _currentTime += Time.deltaTime;
    }

    void IsFinish()
    {
        if(_finishTime <= _currentTime)
        {
            GameManager.Instance.ChangeGamePhase(GameManager.GamePhase.GameFinish);
        }
    }
}
