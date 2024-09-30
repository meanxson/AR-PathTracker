using System;
using UnityEngine;

namespace Client
{
    public class DestinationListView : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private DestinationItemView _destinationItemPrefab;

        public event Action<Destination> DestinationItemPressed;

        private DestinationItemView[] _destinationItems;

        private void OnDestroy()
        {
            for (int i = 0; i < _destinationItems.Length; i++)
            {
                _destinationItems[i].ButtonPressed -= OnDestinationItemPress;
            }

            _destinationItems = null;
        }

        public void FillContent(DestinationData destinationData)
        {
            var destinations = destinationData.Destinations;

            if (destinations.Length == 0)
            {
                Debug.LogError("[Destination] Empty destinations");
                return;
            }

            _destinationItems = new DestinationItemView[destinations.Length];

            for (int i = 0; i < destinations.Length; i++)
            {
                var item = Instantiate(_destinationItemPrefab, _content);
                item.UpdateView(destinations[i]);

                item.ButtonPressed += OnDestinationItemPress;

                _destinationItems[i] = item;
            }
        }

        private void OnDestinationItemPress(Destination destination)
        {
            DestinationItemPressed?.Invoke(destination);
        }
    }
}