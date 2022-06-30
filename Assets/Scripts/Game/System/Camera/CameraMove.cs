using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �J�����̓����𐧌䂷��R���|�[�l���g�B
/// </summary>
public class CameraMove : MonoBehaviour
{
    [SerializeField, Tooltip("�v���C���[�̈ʒu")] Transform _character;
    [SerializeField, Tooltip("�J�����̈ʒu")] Transform _camera;
    [SerializeField, Tooltip("��]���x")] float _rotateSpeed = 5f;

    [SerializeField, Tooltip("�J������X���̊p�x�̌��E(�{)")] float _xMaxRotation = 70f;
    [SerializeField, Tooltip("�J������X���̊p�x�̌��E(�[)")] float _xMinRotation = -30f;
    [Tooltip("�}�E�X�� X�� �̒l���i�[����")] float _xRotation = 0f;
    [Tooltip("�}�E�X�� Y�� �̒l���i�[����")] float _yRotation = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // ���͂̎󂯕t��
        _xRotation = Input.GetAxis("Mouse X");
        _yRotation = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// �󂯎�������͂���J�����ƃL�����N�^�[�̌�����ς���֐�
    /// </summary>
    private void Move()
    {
        // �L�����N�^�[��Y�����}�E�X��X�̓����ɔ��f������
        _character.transform.Rotate(0, _xRotation * _rotateSpeed, 0);

        // �J������X���̊p�x���}�E�X��Y�̓����ɔ��f������
        _camera.transform.Rotate(_yRotation * -_rotateSpeed, 0, 0);

        //X���̊p�x
        float angleX = transform.eulerAngles.x;
        //X���̒l��180�x��������360�������ƂŐ������₷������
        if (angleX >= 180)
        {
            angleX = angleX - 360;
        }
        //Mathf.Clamp(�l�A�ŏ��l�A�ő�l�j��X���̒l�𐧌�����
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angleX, _xMinRotation, _xMaxRotation),
            transform.eulerAngles.y
        ); ;
    }
}

