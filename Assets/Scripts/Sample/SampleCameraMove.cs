using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �J�����̓����𐧌䂷��R���|�[�l���g�B
/// </summary>
public class SampleCameraMove : MonoBehaviour
{
    [SerializeField, Tooltip("�v���C���[�̈ʒu")] Transform _character;
    [SerializeField, Tooltip("�J�����̈ʒu")] Transform _camera;
    [SerializeField, Tooltip("��]���x")] float _rotateSpeed = 5f;
    [Tooltip("�}�E�X�� X�� �̒l���i�[����")] float _xRotation = 0f;
    [Tooltip("�}�E�X�� Y�� �̒l���i�[����")] float _yRotation = 0f;

    void Update()
    {
        // ���͂̎󂯕t��
        _xRotation = Input.GetAxis("Mouse X");
        _yRotation = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        CameraMove();
    }

    /// <summary>
    /// �󂯎�������͂���J�����ƃL�����N�^�[�̌�����ς���֐�
    /// </summary>
    private void CameraMove()
    {
        // �L�����N�^�[��Y�����}�E�X��X�̓����ɔ��f������
        _character.transform.Rotate(0, _xRotation * _rotateSpeed, 0);


    }
}

