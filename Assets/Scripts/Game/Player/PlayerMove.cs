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
    /// �L�����N�^�[�̌����𒲐�����֐��B
    /// </summary>
    private void CharacterRotate()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        this.transform.LookAt(cameraForward);
    }

    /// <summary>
    /// ���͂��󂯕t����֐�
    /// </summary>
    private void InputMove()
    {
        // ���͂��󂯕t����
        float h = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // �J�����̕�������AX-Z���ʂ̃x�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // ���͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * z + Camera.main.transform.right * h;

        // �ϐ��ɑ��x�����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
        _moveVelocity = moveForward * _moveSpeed + new Vector3(0, _rb.velocity.y, 0);

        // �L�����N�^�[�̌�����i�s�����ɒ�������
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }

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
        // InputMove �֐��ō��ꂽ���x�̕ϐ�(�l)���g�� AddForce ����
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
