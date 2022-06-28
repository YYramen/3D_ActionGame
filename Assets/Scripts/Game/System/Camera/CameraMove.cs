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

    [SerializeField, Tooltip("�J������Y���̌��E(�{)")] float _yMaxRotation = 70f;
    [SerializeField, Tooltip("�J������Y���̌��E(�[)")] float _yMinRotation = -40f;
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
        Move();
    }

    /// <summary>
    /// �󂯎�������͂���J�����ƃL�����N�^�[�̌�����ς���֐�
    /// </summary>
    private void Move()
    {
        // �L�����N�^�[��Y�����}�E�X��X�̓����ɔ��f������
        _character.transform.Rotate(0, _xRotation * _rotateSpeed, 0);

        // �J������Y�����}�E�X��Y�̓����ɔ��f������(�J����������Ȉʒu�ɂ���ꍇ)
        float nowAngle = _camera.transform.localRotation.x;
        if (nowAngle > _yMinRotation && _yMaxRotation > nowAngle)
        {
            _camera.transform.Rotate(_yRotation * -_rotateSpeed, 0, 0);
        }
        
        //_camera.transform.Rotate(_yRotation * -_rotateSpeed, 0, 0);
    }
}

