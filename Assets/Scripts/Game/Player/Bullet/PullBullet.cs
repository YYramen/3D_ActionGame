using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���o���b�g�̃R���|�[�l���g
/// </summary>
public class PullBullet : MonoBehaviour
{
    [SerializeField, Tooltip("�e�̐�������")] float _lifeTime = 1f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
