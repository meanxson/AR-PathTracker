using UnityEngine;
using Zenject;

namespace Client
{
    public class GameplayView : MonoBehaviour
    {
        [SerializeField] private DestinationListView _destinationListView;
        [SerializeField] private DirectionPointerViewBehaviour _directionPointerView;
        [SerializeField] private DestinationView _destinationView;
        [SerializeField] private DestinationDoneView _destinationDoneView;

        private GameSession _gameSession;

        [Inject]
        public void Constructor(GameSession gameSession)
        {
            _gameSession = gameSession;
        }

        private void Start()
        {
            _destinationListView.gameObject.SetActive(true);
            _destinationDoneView.gameObject.SetActive(false);
            _destinationView.gameObject.SetActive(false);
        }

        private void Awake()
        {
            _destinationListView.FillContent(_gameSession.DestinationData);
        }

        private void OnEnable()
        {
            _destinationListView.DestinationItemPressed += OnDestinationPress;
            _destinationView.DestinationCanceled += OnDestinationCancel;
            _destinationDoneView.Done += OnDestinationViewDone;

            _gameSession.DestinationArrived += OnDestinationArrive;
        }


        private void OnDisable()
        {
            _destinationListView.DestinationItemPressed -= OnDestinationPress;
            _destinationView.DestinationCanceled -= OnDestinationCancel;
            _destinationDoneView.Done -= OnDestinationViewDone;

            _gameSession.DestinationArrived -= OnDestinationArrive;
        }


        private void OnDestinationArrive(Destination destination)
        {
            _destinationDoneView.gameObject.SetActive(true);
            _destinationView.gameObject.SetActive(false);
            _directionPointerView.SetTarget(Vector3.zero);
            _destinationDoneView.Open(destination);
        }

        private void OnDestinationCancel()
        {
            _gameSession.CancelDestination();

            _destinationListView.gameObject.SetActive(true);
            _destinationView.gameObject.SetActive(false);

            _directionPointerView.SetTarget(Vector3.zero);
        }

        private void OnDestinationPress(Destination destination)
        {
            _gameSession.SetTargetDestination(destination);

            _destinationListView.gameObject.SetActive(false);
            _destinationView.gameObject.SetActive(true);
            
            _directionPointerView.SetTarget(destination.Position);
            _destinationView.SetDestination(destination);
        }

        private void OnDestinationViewDone()
        {
            _destinationListView.gameObject.SetActive(true);
            _destinationDoneView.gameObject.SetActive(false);
        }
    }
}