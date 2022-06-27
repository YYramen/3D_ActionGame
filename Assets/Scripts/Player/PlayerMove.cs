using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの動きを管理するコンポーネント
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("移動速度")] float _moveSpeed = 10f;
    [Tooltip("移動方向")] Vector3 _moveDirection;
    [Tooltip("移動方向にかける velocity ")] Vector3 _moveVelocity;

    [SerializeField, Tooltip("ジャンプ力")] float _jumpPower = 10f;
    [Tooltip("ジャンプキーが押されたかどうかのフラグ")] bool _jumpActive = false;

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
    /// 入力を受け付ける関数
    /// </summary>
    private void InputMove()
    {
        // 入力を受け付ける
        float h = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        // 方向と速度を決める(前後左右移動用)
        _moveDirection = new Vector3(h, 0, z).normalized;
        _moveVelocity = _moveDirection * _moveSpeed;

        // ジャンプの入力を受け付けて、押されたらフラグを true に、それ以外の時は false にする
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
    /// 実際に動かす関数(ジャンプ以外)
    /// </summary>
    private void Move()
    {
        _rb.AddForce(_moveVelocity, ForceMode.Force);
    }

    /// <summary>
    /// Space キーを押したときにプレイヤーをジャンプさせる関数
    /// </summary>
    private void Jump()
    {
        if (_jumpActive)
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }
}
