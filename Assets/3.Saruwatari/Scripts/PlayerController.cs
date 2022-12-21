using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int _playerNum;
    [SerializeField, Tooltip("横")] string _horizontal;
    [SerializeField, Tooltip("縦")] string _vertical;
    [SerializeField, Tooltip("キャッチ")] string _catch;
    [SerializeField, Tooltip("投げる")] string _shot;
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed;
    GameManager gameManager;
    [SerializeField] GameManager.Turn _myTurn;


    public float MoveSpeed => _moveSpeed;

    public GameManager.Turn _currentTurn { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();
        BallGet();
    }

    void Move()
    {
        float x = Input.GetAxis($"{_horizontal} {_playerNum}"); 
        float y = Input.GetAxis($"{_vertical} {_playerNum}");
        Debug.Log($"{x},{y}");
        Vector2 directionn = Vector2.right * x + Vector2.up * y;
        directionn *= _moveSpeed * Time.deltaTime;
        _rb.velocity = directionn;
        //if(Input.GetButtonDown("Fire1"))
        //{
        //    Debug.Log("a");
        //}
    }

    void Shot()
    {
        if (_myTurn == _currentTurn/*&& ボールを持っている時*/)
        {
            if (Input.GetButton($"{_shot} {_playerNum}"))
            {

            }
        }
    }

    public void BallCatch()
    {
        if (_myTurn != _currentTurn)
        {
            if (Input.GetButton($"{_catch} {_playerNum}"))
            {

            }
        }
    }

    void BallGet()
    {
        if (_myTurn == _currentTurn)
        {

        }
    }

    public void Damage()
    {
        gameManager.AddScore(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Damage();
        }
    }

}
