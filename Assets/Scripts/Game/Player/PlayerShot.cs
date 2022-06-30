using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの射撃を制御するコンポーネント
/// </summary>
public class PlayerShot : MonoBehaviour
{
    [SerializeField, Tooltip("弾を撃つ場所")] Transform[] _muzzlePos = default;
    [SerializeField, Tooltip("プルバレットのプレハブ")] GameObject _pullBulletPrefab = default;
    [SerializeField, Tooltip("フックバレットのプレハブ")] GameObject _hookBulletPrefab = default;
    [SerializeField, Tooltip("弾を飛ばせる距離")] float _rayDistance = 50f;
    [SerializeField, Tooltip("当たった物を判別するLayer")] LayerMask _layerMask;
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
    /// フックバレットの処理(弾が当たった方向にプレイヤーが引き寄せられる)
    /// </summary>
    private void ShotHookBullet()
    {
        if (Physics.Raycast(_muzzlePos[0].position, Vector2.zero, out _hit, _rayDistance, _layerMask,
             QueryTriggerInteraction.Ignore))
        {
            HitHook();
        }
    }

    /// <summary>
    /// プルバレットの処理(弾が当たった物をプレイヤーの方向に引き寄せる)
    /// </summary>
    private void ShotPullBullet()
    {
        if (Physics.Raycast(_muzzlePos[1].position, Vector2.zero, out _hit, _rayDistance, _layerMask,
             QueryTriggerInteraction.Ignore))
        {
            HitPull();
        }
    }

    /// <summary>
    /// フックバレットが当たった時に呼ばれる関数
    /// </summary>
    private void HitHook()
    {
        Instantiate(_hookBulletPrefab);
        Debug.Log($"フックバレットが {_hit.collider.gameObject.name} に当たった");
    }

    /// <summary>
    /// プルバレットが当たった時に呼ばれる関数
    /// </summary>
    private void HitPull()
    {
        Instantiate(_pullBulletPrefab);
        Debug.Log($"プルバレットが {_hit.collider.gameObject.name} に当たった");
    }
}
