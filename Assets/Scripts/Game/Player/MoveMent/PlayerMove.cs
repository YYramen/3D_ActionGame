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
        InputMove();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// キャラクターの向きを調整する関数。
    /// </summary>
    private void CharacterRotate()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        this.transform.LookAt(cameraForward);
    }

    /// <summary>
    /// 入力を受け付ける関数
    /// </summary>
    private void InputMove()
    {
        // 入力を受け付ける
        float h = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // カメラの方向から、X-Z 平面のベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * z + Camera.main.transform.right * h;

        // 変数に速度を代入
        _moveVelocity = moveForward * _moveSpeed + new Vector3(0, _rb.velocity.y, 0);
    }

    /// <summary>
    /// 実際に動かす関数(ジャンプ以外)
    /// </summary>
    private void Move()
    {
        // InputMoveで作られたベクトル、速度をAddforceする
        _rb.AddForce(_moveVelocity, ForceMode.Force);
    }
}
