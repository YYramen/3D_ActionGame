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

    Rigidbody Rigidbody;
    private void Start()
    {
        Rigidbody = this.GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        // TODO : ベクトルを作る際カメラ基準になっているせいでプレイヤーが変な方向に飛ぶので
        //        それを直す
        var dir = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_muzzlePos[0].position, dir.direction, out var hit))
        {
            var origin = transform.position;
            var targetPos = hit.point;

            var forceDirection = origin + targetPos;

            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log(forceDirection);
                Rigidbody.AddForce(forceDirection * 10);
            }
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
        Instantiate(_hookBulletPrefab, _muzzlePos[0].transform.position, Quaternion.identity);
    }

    /// <summary>
    /// プルバレットの処理(弾が当たった物をプレイヤーの方向に引き寄せる)
    /// </summary>
    private void ShotPullBullet()
    {
        Instantiate(_pullBulletPrefab, _muzzlePos[1].transform.position, Quaternion.identity);
    }
}
