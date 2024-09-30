using CustomTools.Updater;
using UnityEngine;
using UnityEngine.AI;

namespace Client
{
    public class PathCreateUpdater : IUpdateMono
    {
        private readonly LineRenderer _lineRenderer;
        private readonly NavMeshAgent _meshAgent;
        private readonly NavMeshPath _navMeshPath;

        private Vector3 _targetPosition;
        private Camera _camera;

        public PathCreateUpdater(LineRenderer lineRenderer, NavMeshAgent meshAgent)
        {
            _lineRenderer = lineRenderer;
            _meshAgent = meshAgent;
            _navMeshPath = new NavMeshPath();
            _camera = Camera.main;
        }

        public void Tick()
        {
            if (_targetPosition == Vector3.zero)
            {
                _lineRenderer.positionCount = 0;
                _lineRenderer.enabled = false;
                return;
            }

            if (ReferenceEquals(_navMeshPath, null) == false)
            {
                _navMeshPath.ClearCorners();
            }

            NavMesh.CalculatePath(_camera.transform.position, _targetPosition, NavMesh.AllAreas, _navMeshPath);

            if (ReferenceEquals(_navMeshPath, null))
            {
                return;
            }

            _lineRenderer.positionCount = _navMeshPath.corners.Length;
            _lineRenderer.SetPositions(_navMeshPath.corners);
            _lineRenderer.enabled = true;
        }

        public void SetPosition(Vector3 position)
        {
            _targetPosition = position;
        }
    }
}