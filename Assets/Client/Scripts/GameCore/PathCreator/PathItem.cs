using System;
using DG.Tweening;
using UnityEngine;

namespace Client
{
    public class PathItem : MonoBehaviour
    {
        [SerializeField] private Transform _mesh;

        private Tween _tween;

        private void Awake()
        {
            _tween = _mesh.DOLocalMoveY(_mesh.localPosition.y + 0.1f, 1f).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDestroy()
        {
            _tween.Kill();
        }
    }
}