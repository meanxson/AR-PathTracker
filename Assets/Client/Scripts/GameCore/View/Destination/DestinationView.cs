using System;
using CustomTools.Updater;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    public class DestinationView : MonoBehaviour
    {
        [SerializeField] private DestinationTrackerBehaviour _destinationTracker;
        [SerializeField] private TMP_Text _destinationLabel;
        [SerializeField] private Slider _progressBar;
        [SerializeField] private Button _closeButton;

        public event Action DestinationCanceled;

        private DestinationViewUpdater _destinationViewUpdater;

        private void Awake()
        {
            _destinationViewUpdater = new DestinationViewUpdater(_progressBar, _destinationTracker);
            UpdaterMono.Instance.Add(_destinationViewUpdater);
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPress);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonPress);
        }

        private void OnCloseButtonPress()
        {
            DestinationCanceled?.Invoke();
        }

        public void SetDestination(Destination destination)
        {
            _destinationLabel.text = destination.Title;
            _destinationViewUpdater.SetTarget(destination);
        }
    }
}