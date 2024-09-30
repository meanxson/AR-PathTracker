using CustomTools.Updater;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    public class DestinationViewUpdater : IUpdateMono
    {
        private readonly DestinationTrackerBehaviour _destinationTracker;
        private readonly Slider _progressBar;

        private Destination _targetDestination;
        private float _startDistance;

        public DestinationViewUpdater(Slider progressBar, DestinationTrackerBehaviour destinationView)
        {
            _progressBar = progressBar;
            _destinationTracker = destinationView;
        }

        public void Tick()
        {
            if (ReferenceEquals(_targetDestination, null))
            {
                return;
            }

            _progressBar.value =
                _destinationTracker.DestinationTrackerUpdater.Distance.Remap(_startDistance, 0.5f, 0, 100);
        }

        public void SetTarget(Destination destination)
        {
            _startDistance = _destinationTracker.DestinationTrackerUpdater.Distance;
            Debug.Log($"Start Distance {_startDistance}");
            _targetDestination = destination;
        }
    }
}