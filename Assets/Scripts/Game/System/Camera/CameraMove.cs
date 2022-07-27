using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �J�����̓����𐧌䂷��R���|�[�l���g�B
/// </summary>
public class CameraMove : MonoBehaviour
{
    [SerializeField, Tooltip("�J�����̈ʒu")] Transform _camera;
    [SerializeField, Tooltip("��]���x")] float _rotateSpeed = 5f;

    [SerializeField, Tooltip("�J������X���̊p�x�̌��E(�{)")] float _xMaxRotation = 70f;
    [SerializeField, Tooltip("�J������X���̊p�x�̌��E(�[)")] float _xMinRotation = -30f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
    }

    /// <summary>
    /// �󂯎�������͂���J�����̌�����ς���֐�
    /// </summary>
    private void Move()
    {
        // ���͂̎󂯕t��
        var inputY = Input.GetAxis("Mouse Y") * -1;

        if(inputY > _xMinRotation && inputY < _xMaxRotation)
        {
            _camera.transform.Rotate(inputY, 0, 0);
        }
    }
}

