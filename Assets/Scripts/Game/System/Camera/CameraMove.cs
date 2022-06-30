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

    [SerializeField, Tooltip("カメラのX軸の角度の限界(＋)")] float _xMaxRotation = 70f;
    [SerializeField, Tooltip("カメラのX軸の角度の限界(ー)")] float _xMinRotation = -30f;
    [Tooltip("マウスの X軸 の値を格納する")] float _xRotation = 0f;
    [Tooltip("マウスの Y軸 の値を格納する")] float _yRotation = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

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

        // カメラのX軸の角度をマウスのYの動きに反映させる
        _camera.transform.Rotate(_yRotation * -_rotateSpeed, 0, 0);

        //X軸の角度
        float angleX = transform.eulerAngles.x;
        //X軸の値を180度超えたら360引くことで制限しやすくする
        if (angleX >= 180)
        {
            angleX = angleX - 360;
        }
        //Mathf.Clamp(値、最小値、最大値）でX軸の値を制限する
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angleX, _xMinRotation, _xMaxRotation),
            transform.eulerAngles.y
        ); ;
    }
}

