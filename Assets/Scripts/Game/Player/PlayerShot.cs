using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̎ˌ��𐧌䂷��R���|�[�l���g
/// </summary>
public class PlayerShot : MonoBehaviour
{
    [SerializeField, Tooltip("�e�����ꏊ")] Transform[] _muzzlePos = default;
    [SerializeField, Tooltip("�v���o���b�g�̃v���n�u")] GameObject _pullBulletPrefab = default;
    [SerializeField, Tooltip("�t�b�N�o���b�g�̃v���n�u")] GameObject _hookBulletPrefab = default;
    [SerializeField, Tooltip("�e���΂��鋗��")] float _rayDistance = 50f;
    [SerializeField, Tooltip("�����������𔻕ʂ���Layer")] LayerMask _layerMask;
    RaycastHit _hit;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShotHookBullet();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            ShotPullBullet();
        }
    }

    /// <summary>
    /// �t�b�N�o���b�g�̏���(�e���������������Ƀv���C���[�������񂹂���)
    /// </summary>
    private void ShotHookBullet()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hit, _rayDistance, _layerMask))
        {
            HitHook();
        }
    }

    /// <summary>
    /// �v���o���b�g�̏���(�e���������������v���C���[�̕����Ɉ����񂹂�)
    /// </summary>
    private void ShotPullBullet()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hit, _rayDistance, _layerMask))
        {
            HitPull();
        }
    }

    /// <summary>
    /// �t�b�N�o���b�g�������������ɌĂ΂��֐�
    /// </summary>
    private void HitHook()
    {
        Instantiate(_hookBulletPrefab, _hit.point, Quaternion.identity);
        Debug.Log($"�t�b�N�o���b�g�� {_hit.collider.gameObject.name} �ɓ�������");
    }

    /// <summary>
    /// �v���o���b�g�������������ɌĂ΂��֐�
    /// </summary>
    private void HitPull()
    {
        Instantiate(_pullBulletPrefab, _hit.point, Quaternion.identity);
        Debug.Log($"�v���o���b�g�� {_hit.collider.gameObject.name} �ɓ�������");
    }
}
