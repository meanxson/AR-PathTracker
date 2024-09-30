using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    public class DestinationDoneView : MonoBehaviour
    {
        [SerializeField] private Button _doneButton;
        [SerializeField] private TMP_Text _destinationLabel;

        public event Action Done;
        
        private void OnEnable()
        {
            _doneButton.onClick.AddListener(OnDoneButtonClick);
        }

        private void OnDisable()
        {
            _doneButton.onClick.RemoveListener(OnDoneButtonClick);
        }

        public void Open(Destination destination)
        {
            _destinationLabel.text = destination.Title;
        }

        private void OnDoneButtonClick()
        {
            Done?.Invoke();
        }
    }
}