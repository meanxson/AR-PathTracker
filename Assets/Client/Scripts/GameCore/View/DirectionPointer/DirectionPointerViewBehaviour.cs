using CustomTools.Updater;
using UnityEngine;

namespace Client
{
    public class DirectionPointerViewBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _leftArrow;
        [SerializeField] private GameObject _rightArrow;
        [SerializeField] private float _displayAngle = 45f;

        private Camera _camera;

        private DirectionPointerViewUpdater _directionPointerViewUpdater;

        private void Awake()
        {
            _camera = Camera.main;

            _directionPointerViewUpdater =
                new DirectionPointerViewUpdater(_leftArrow, _rightArrow, _camera, _displayAngle);
            UpdaterMono.Instance.Add(_directionPointerViewUpdater);
        }

        public void SetTarget(Vector3 position)
        {
            _directionPointerViewUpdater.SetTarget(position);
        }
    }
}