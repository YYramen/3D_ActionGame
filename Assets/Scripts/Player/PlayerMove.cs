using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�̓������Ǘ�����R���|�[�l���g
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("�ړ����x")] float _moveSpeed = 10f;
    [Tooltip("�ړ�����")] Vector3 _moveDirection;
    [Tooltip("�ړ������ɂ����� velocity ")] Vector3 _moveVelocity;

    [SerializeField, Tooltip("�W�����v��")] float _jumpPower = 10f;
    [Tooltip("�W�����v�L�[�������ꂽ���ǂ����̃t���O")] bool _jumpActive = false;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputMove();
    }

    private void FixedUpdate()
    {
        Move();

        Jump();
    }

    /// <summary>
    /// ���͂��󂯕t����֐�
    /// </summary>
    private void InputMove()
    {
        // ���͂��󂯕t����
        float h = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        // �����Ƒ��x�����߂�(�O�㍶�E�ړ��p)
        _moveDirection = new Vector3(h, 0, z).normalized;
        _moveVelocity = _moveDirection * _moveSpeed;

        // �W�����v�̓��͂��󂯕t���āA�����ꂽ��t���O�� true �ɁA����ȊO�̎��� false �ɂ���
        if (Input.GetButtonDown("Jump"))
        {
            _jumpActive = true;
        }
        else
        {
            _jumpActive = false;
        }
    }

    /// <summary>
    /// ���ۂɓ������֐�(�W�����v�ȊO)
    /// </summary>
    private void Move()
    {
        _rb.AddForce(_moveVelocity, ForceMode.Force);
    }

    /// <summary>
    /// Space �L�[���������Ƃ��Ƀv���C���[���W�����v������֐�
    /// </summary>
    private void Jump()
    {
        if (_jumpActive)
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }
}
