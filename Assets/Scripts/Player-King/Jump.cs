using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rb2D;
    private bool _isGrounded;
    [SerializeField] private float rayLength;

   
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundCheck();

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jumping();
        }
    }

    private void GroundCheck()
    {

        Ray ray = new Ray(transform.position, Vector2.down);

        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

        _isGrounded = Physics2D.Raycast(ray.origin, ray.direction, rayLength, _whatIsGround);
    }

    private void Jumping()
    {
        _rb2D.AddForce(_jumpForce * Vector2.up);
    }
}
