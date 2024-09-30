using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    public class DestinationItemView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Button _button;

        public event Action<Destination> ButtonPressed;

        public Destination Destination { get; set; }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonPress);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonPress);
        }


        public void UpdateView(Destination destination)
        {
            Destination = destination;
            _label.text = destination.Title;
        }

        private void OnButtonPress()
        {
            ButtonPressed?.Invoke(Destination);
        }
    }
}