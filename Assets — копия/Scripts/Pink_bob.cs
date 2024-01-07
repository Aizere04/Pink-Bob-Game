using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Pink_bob : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private KeyCode _Jump;
    [SerializeField] private float _JumpForce;
    [SerializeField] private SpriteRenderer _bob;
    [SerializeField] private LayerMask _JumpingGround;
    private BoxCollider2D coll;

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        float inputDir = Input.GetAxis("Horizontal");

        _bob.flipX = inputDir < 0;
        _animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + inputDir, transform.position.y, 0), Time.deltaTime * _moveSpeed);

        if (Input.GetKeyDown(_Jump) && IsGrounded())
        {
            _rb.AddForce(Vector2.up * _JumpForce);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, _JumpingGround);
    }



}
