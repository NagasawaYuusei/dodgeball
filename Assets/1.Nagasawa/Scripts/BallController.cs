using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _decelerationScaleFactor = 0.75f;
    float _currentBallTime;
    [SerializeField] float _maxmizeOwnBallTime;
    [SerializeField] float _ballSpeed;
    bool _isOwn;

    public bool IsOwn => _isOwn;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Gauge();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "WallX")
        {
            _rb.velocity = BaunceX(_rb.velocity);
        }
        else if(collision.gameObject.tag == "WallY")
        {
            _rb.velocity = BaunceY(_rb.velocity);
        }
    }

    Vector2 BaunceX(Vector2 vec)
    {
        return Deceleration(new Vector2(vec.x, -vec.y));
    }

    Vector2 BaunceY(Vector2 vec)
    {
        return Deceleration(new Vector2(-vec.x, vec.y));
    }
    
    Vector2 Deceleration(Vector2 vec)
    {
        return new Vector2(vec.x * _decelerationScaleFactor, vec.y * _decelerationScaleFactor);
    }

    void Gauge()
    {
        if(_isOwn)
        {
            _currentBallTime -= Time.deltaTime;
            if(_currentBallTime <= 0)
            {
                BallLost();
            }
        }
    }

    /// <summary>
    /// ボールの動きを決める際呼ぶ
    /// </summary>
    /// <param name="vec"></param>
    public void BallMove(Vector2 vec)
    {
        _rb.velocity = vec * _ballSpeed;
    }

    /// <summary>
    /// ボールをキャッチまたは失ったとき呼ぶ
    /// </summary>
    public void BallLost()
    {
        if (GameManager.CurrentTurn == GameManager.Turn.Player1)
            GameManager.Instance.TurnChange(GameManager.Turn.Player2);
        else
            GameManager.Instance.TurnChange(GameManager.Turn.Player1);
    }

    /// <summary>
    /// ボールの所持状態を変えるとき呼ぶ
    /// </summary>
    /// <param name="on"></param>
    public void ChangeOwnBall(bool on)
    {
        if(on)
        {
            _currentBallTime = _maxmizeOwnBallTime;
        }
        _isOwn = on;
    }

    /// <summary>
    /// ボールの動き止めるときに呼ぶ
    /// </summary>
    public void BallStop()
    {
        _rb.velocity = Vector2.zero;
    }
}
