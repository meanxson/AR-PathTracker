using System;
using UnityEngine;

namespace Client
{
    [CreateAssetMenu(fileName = "Destination", menuName = "Destination/Create Destination", order = 0)]
    public class DestinationData : ScriptableObject
    {
        public Destination[] Destinations;
    }

    [Serializable]
    public class Destination
    {
        public string Title;
        public Vector3 Position;
    }
}