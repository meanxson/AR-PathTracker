using CustomTools.Updater;
using UnityEngine;

namespace Client
{
    public class DirectionPointerViewUpdater : IUpdateMono
    {
        private readonly GameObject _leftArrow;
        private readonly GameObject _rightArrow;
        private readonly Camera _mainCamera;
        private readonly float _displayAngle;

        private Vector3 _targetPosition;

        public DirectionPointerViewUpdater(GameObject leftArrow, GameObject rightArrow,
            Camera mainCamera, float displayAngle)
        {
            _leftArrow = leftArrow;
            _rightArrow = rightArrow;
            _mainCamera = mainCamera;
            _displayAngle = displayAngle;
        }

        public void Tick()
        {
            if (_targetPosition == Vector3.zero)
            {
                TurnArrow(false, false);
                return;
            }

            var directionToTarget = _targetPosition - _mainCamera.transform.position;
            var cameraForward = _mainCamera.transform.forward;

            var angle = Vector3.SignedAngle(cameraForward, directionToTarget, Vector3.up);

            if (Mathf.Abs(angle) > _displayAngle)
            {
                if (angle > 0)
                    TurnArrow(false, true);
                else
                    TurnArrow(true, false);

                return;
            }

            TurnArrow(false, false);
        }

        public void SetTarget(Vector3 position)
        {
            _targetPosition = position;
        }

        private void TurnArrow(bool leftFlag, bool rightFlag)
        {
            _rightArrow.SetActive(rightFlag);
            _leftArrow.SetActive(leftFlag);
        }
    }
}