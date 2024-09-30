using System;
using CustomTools.Updater;
using UnityEngine;

namespace Client
{
    public class DestinationTrackerUpdater : IUpdateMono
    {
        private readonly Camera _camera;
        private Destination _targetDestination;
        private readonly GameSession _gameSession;

        public float Distance;

        public event Action<Destination> Arrived;

        public DestinationTrackerUpdater(GameSession gameSession)
        {
            _camera = Camera.main;
            _gameSession = gameSession;
            _gameSession.DestinationActivated += OnDestinationActivate;
            _gameSession.DestinationCanceled += OnDestinationCancel;
        }

        ~DestinationTrackerUpdater()
        {
            _gameSession.DestinationActivated -= OnDestinationActivate;
            _gameSession.DestinationCanceled -= OnDestinationCancel;
        }

        public void Tick()
        {
            if (ReferenceEquals(_targetDestination, null))
            {
                return;
            }

            Distance = Vector3.Distance(_camera.transform.position, _targetDestination.Position);

            if (Distance < 1f)
            {
                Arrived?.Invoke(_targetDestination);
            }
        }

        private void OnDestinationActivate(Destination destination)
        {
            _targetDestination = destination;
            Distance = Vector3.Distance(_camera.transform.position, _targetDestination.Position);
        }

        private void OnDestinationCancel()
        {
            _targetDestination = null;
        }
    }
}