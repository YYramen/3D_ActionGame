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
    /// キャラクターの向きを調整する関数。
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
    /// 入力を受け付ける関数
    /// </summary>
    private Vector3 InputDirection()
    {
        // 入力を受け付ける
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        var dir = Vector3.right * h + Vector3.forward * v;
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        return dir;
    }

    /// <summary>
    /// 実際に動かす関数(ジャンプ以外)
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
