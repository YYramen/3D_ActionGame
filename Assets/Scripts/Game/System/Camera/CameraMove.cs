using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの動きを制御するコンポーネント。
/// </summary>
public class CameraMove : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーの位置")] Transform _character;
    [SerializeField, Tooltip("カメラの位置")] Transform _camera;
    [SerializeField, Tooltip("回転速度")] float _rotateSpeed = 5f;

    [SerializeField, Tooltip("カメラのY軸の限界(＋)")] float _yMaxRotation = 70f;
    [SerializeField, Tooltip("カメラのY軸の限界(ー)")] float _yMinRotation = -40f;
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
        Move();
    }

    /// <summary>
    /// 受け取った入力からカメラとキャラクターの向きを変える関数
    /// </summary>
    private void Move()
    {
        // キャラクターのY軸をマウスのXの動きに反映させる
        _character.transform.Rotate(0, _xRotation * _rotateSpeed, 0);

        // カメラのY軸をマウスのYの動きに反映させる(カメラが正常な位置にいる場合)
        float nowAngle = _camera.transform.localRotation.x;
        if (nowAngle > _yMinRotation && _yMaxRotation > nowAngle)
        {
            _camera.transform.Rotate(_yRotation * -_rotateSpeed, 0, 0);
        }
        
        //_camera.transform.Rotate(_yRotation * -_rotateSpeed, 0, 0);
    }
}

