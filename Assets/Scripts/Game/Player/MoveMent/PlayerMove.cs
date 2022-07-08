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
        InputMove();
    }

    private void FixedUpdate()
    {
        Move();
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

        // �J�����̕�������AX-Z ���ʂ̃x�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // ���͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * z + Camera.main.transform.right * h;

        // �ϐ��ɑ��x����
        _moveVelocity = moveForward * _moveSpeed + new Vector3(0, _rb.velocity.y, 0);
    }

    /// <summary>
    /// ���ۂɓ������֐�(�W�����v�ȊO)
    /// </summary>
    private void Move()
    {
        // InputMove�ō��ꂽ�x�N�g���A���x��Addforce����
        _rb.AddForce(_moveVelocity, ForceMode.Force);
    }
}
