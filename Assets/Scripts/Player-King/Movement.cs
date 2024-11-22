using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _speed;

    [Range(0, 0.3f)][SerializeField] private float _moveSmooth;
    private Vector3 _speedInZ = Vector3.zero;


    private Rigidbody2D _rb2D;
    private Vector2 _movement;
    private bool _isFacingRight = true;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
        
        
    }


    private void FixedUpdate()
    {
        Move(_horizontalInput * Time.deltaTime);
    }


    private void CheckInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal") * _speed;

    }

    private void Move(float mover)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, _rb2D.velocity.y);
        _rb2D.velocity = Vector3.SmoothDamp(_rb2D.velocity, velocidadObjetivo, ref _speedInZ, _moveSmooth);
        //_movement = new Vector2(_horizontalInput, 0f);
    }
}
