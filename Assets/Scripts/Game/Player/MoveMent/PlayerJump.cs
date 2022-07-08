using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ڒn����A�W�����v�𐧌䂷��R���|�[�l���g
/// </summary>
public class PlayerJump : MonoBehaviour
{
    [SerializeField, Tooltip("�W�����v��")] float _jumpPower = 5f;
    [SerializeField, Tooltip("��΂�Ray�̋���")] float _rayDistance = 0.5f;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    /// <summary>
    /// �ڒn����ƃW�����v����������֐�
    /// </summary>
    private void Jump()
    {
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);
        bool isGround = Physics.Raycast(ray, _rayDistance);

        Debug.DrawRay(rayPosition, Vector3.down * _rayDistance, Color.red);

        if (isGround)
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }
}
