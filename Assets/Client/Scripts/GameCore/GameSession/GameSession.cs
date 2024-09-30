using System;
using UnityEngine;

namespace Client
{
    public class GameSession : MonoBehaviour
    {
        [field: SerializeField] public DestinationData DestinationData { get; private set; }

        public event Action<Destination> DestinationActivated;
        public event Action<Destination> DestinationArrived;
        public event Action DestinationCanceled;

        public void SetTargetDestination(Destination destination)
        {
            DestinationActivated?.Invoke(destination);
        }

        public void CancelDestination()
        {
            DestinationCanceled?.Invoke();
        }

        public void Arrive(Destination destination)
        {
            DestinationCanceled?.Invoke();
            DestinationArrived?.Invoke(destination);
        }
    }
}