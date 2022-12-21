using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int _playerNum;
    [SerializeField, Tooltip("‰¡")] string _horizontal;
    [SerializeField, Tooltip("c")] string _vertical;
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed;

    public float MoveSpeed => _moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis($"{_horizontal} {_playerNum}"); 
        float y = Input.GetAxis($"{_vertical} {_playerNum}");
        Debug.Log($"{x},{y}");
        Vector2 directionn = Vector2.right * x + Vector2.up * y;
        directionn *= _moveSpeed * Time.deltaTime;
        _rb.velocity = directionn;
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("a");
        }
    }
    
}
