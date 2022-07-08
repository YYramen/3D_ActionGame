using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プルバレットのコンポーネント
/// </summary>
public class HookBullet : MonoBehaviour
{
    [SerializeField, Tooltip("マズルのゲームオブジェクト")] GameObject _muzzleObj = default;
    [SerializeField, Tooltip("LineRenderer")] LineRenderer _lr = default;
    [SerializeField, Tooltip("フックのTransform")] Transform _transform = default;

    RaycastHit _hit;

    private void Start()
    {
        
    }
}
