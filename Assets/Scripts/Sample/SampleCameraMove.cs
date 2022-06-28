using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの動きを制御するコンポーネント。
/// </summary>
public class SampleCameraMove : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーの位置")] Transform _character;
    [SerializeField, Tooltip("カメラの位置")] Transform _camera;
    [SerializeField, Tooltip("回転速度")] float _rotateSpeed = 5f;
    [Tooltip("マウスの X軸 の値を格納する")] float _xRotation = 0f;
    [Tooltip("マウスの Y軸 の値を格納する")] float _yRotation = 0f;

    void Update()
    {
        // 入力の受け付け
        _xRotation = Input.GetAxis("Mouse X");
        _yRotation = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        CameraMove();
    }

    /// <summary>
    /// 受け取った入力からカメラとキャラクターの向きを変える関数
    /// </summary>
    private void CameraMove()
    {
        // キャラクターのY軸をマウスのXの動きに反映させる
        _character.transform.Rotate(0, _xRotation * _rotateSpeed, 0);


    }
}

