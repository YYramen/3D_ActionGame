using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プルバレットのコンポーネント
/// </summary>
public class PullBullet : MonoBehaviour
{
    [SerializeField, Tooltip("弾の生存時間")] float _lifeTime = 1f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
