using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���o���b�g�̃R���|�[�l���g
/// </summary>
public class HookBullet : MonoBehaviour
{
    [SerializeField, Tooltip("�}�Y���̃Q�[���I�u�W�F�N�g")] GameObject _muzzleObj = default;
    [SerializeField, Tooltip("LineRenderer")] LineRenderer _lr = default;
    [SerializeField, Tooltip("�t�b�N��Transform")] Transform _transform = default;

    RaycastHit _hit;

    private void Start()
    {
        
    }
}
