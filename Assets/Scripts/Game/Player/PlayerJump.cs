using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 接地判定、ジャンプを制御するコンポーネント
/// </summary>
public class PlayerJump : MonoBehaviour
{
    [SerializeField, Tooltip("ジャンプ力")] float _jumpPower = 5f;
    [SerializeField, Tooltip("飛ばすRayの距離")] float _rayDistance = 0.5f;

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
    /// 接地判定とジャンプを処理する関数
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
