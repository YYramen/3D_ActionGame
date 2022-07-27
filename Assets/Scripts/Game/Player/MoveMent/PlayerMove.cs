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

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputDirection();

        CharacterRotate();

        Move();
    }

    /// <summary>
    /// �L�����N�^�[�̌����𒲐�����֐��B
    /// </summary>
    private void CharacterRotate()
    {
        var inputX = Input.GetAxis("Mouse X");

        if (inputX != 0)
        {
            transform.Rotate(0f, inputX, 0f);
        }
    }

    /// <summary>
    /// ���͂��󂯕t����֐�
    /// </summary>
    private Vector3 InputDirection()
    {
        // ���͂��󂯕t����
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        var dir = Vector3.right * h + Vector3.forward * v;
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        return dir;
    }

    /// <summary>
    /// ���ۂɓ������֐�(�W�����v�ȊO)
    /// </summary>
    private void Move()
    {
        var dir = InputDirection();

        if (IsGround())
        {
            if (dir != Vector3.zero)
            {
                var vel = dir * _moveSpeed;
                _rb.velocity = vel;
            }
        }
    }

    private bool IsGround()
    {
        var start = this.transform.position;
        var end = start + Vector3.down * 10f;
        return Physics.Raycast(start, end);
    }
}
