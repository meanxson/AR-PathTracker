using CustomTools.Updater;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Client
{
    public class PathCreator : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private PathItem _pathItemPrefab;
        [SerializeField] private Transform _arTarget;

        private GameSession _gameSession;
        private NavMeshAgent _meshAgent;


        private PathItem _pathItem;
        private PathCreateUpdater _pathCreateUpdater;

        [Inject]
        public void Constructor(GameSession gameSession)
        {
            _gameSession = gameSession;
        }

        private void Awake()
        {
            _meshAgent = GetComponent<NavMeshAgent>();
            _pathCreateUpdater = new PathCreateUpdater(_lineRenderer, _meshAgent);
            UpdaterMono.Instance.Add(_pathCreateUpdater);
        }

        private void OnEnable()
        {
            _gameSession.DestinationActivated += OnDestinationActivate;
            _gameSession.DestinationCanceled += OnDestinationCancel;
        }

        private void OnDisable()
        {
            _gameSession.DestinationActivated -= OnDestinationActivate;
            _gameSession.DestinationCanceled -= OnDestinationCancel;
        }

        private void OnDestinationActivate(Destination destination)
        {
            _pathCreateUpdater.SetPosition(destination.Position);
            _pathItem = Instantiate(_pathItemPrefab, destination.Position, Quaternion.identity, _arTarget);
        }

        private void OnDestinationCancel()
        {
            _pathCreateUpdater.SetPosition(Vector3.zero);
            Destroy(_pathItem.gameObject);
        }
    }
}