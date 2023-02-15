using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    [Header("Main Components")]
    [SerializeField] private Animator _animator;
    [SerializeField] private CapsuleCollider _mainCollider;
    [SerializeField] private Rigidbody _rigidBody;

    private bool _inCrouchState;
    private bool _inJump;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && !_inCrouchState)
        {
            OnCrouchStateChanged(true);
        }

        if(Input.GetKeyUp(KeyCode.C) && _inCrouchState)
        {
            OnCrouchStateChanged(false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && !_inJump)
        {
            PerfomJump();
        }
    }

    private void FixedUpdate()
    {
        if(_inJump && _rigidBody.velocity.y < 0 && IsGrounded())
        {
            _inJump = false;
            _animator.SetBool("Jump", false);
        }
    }


    void OnCrouchStateChanged(bool bEnable)
    {
        _inCrouchState = bEnable;
        _animator.SetBool("Crouch", _inCrouchState);
        _mainCollider.height = _inCrouchState ? 0.6f : 1.2f;
        _mainCollider.center = new Vector3(0, _mainCollider.height/ 2, 0);
    }

    void PerfomJump()
    {
        _inJump = true;
        _animator.SetBool("Jump", true);
        _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hit")
        {
            Debug.Log("GameOver");
        }

        GamePlayScene.singleton.StopGame();
    }
}
