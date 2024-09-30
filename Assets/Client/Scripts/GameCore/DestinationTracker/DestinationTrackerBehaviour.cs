using System;
using CustomTools.Updater;
using UnityEngine;
using Zenject;

namespace Client
{
    public class DestinationTrackerBehaviour : MonoBehaviour
    {
        private GameSession _gameSession;
        public DestinationTrackerUpdater DestinationTrackerUpdater { get; private set; }


        [Inject]
        public void Constructor(GameSession gameSession)
        {
            _gameSession = gameSession;
        }

        private void Awake()
        {
            DestinationTrackerUpdater = new DestinationTrackerUpdater(_gameSession);
            UpdaterMono.Instance.Add(DestinationTrackerUpdater);
        }

        private void OnEnable()
        {
            DestinationTrackerUpdater.Arrived += OnArrive;
        }

        private void OnDisable()
        {
            DestinationTrackerUpdater.Arrived -= OnArrive;
        }

        private void OnArrive(Destination destination)
        {
            _gameSession.Arrive(destination);
        }
    }
}