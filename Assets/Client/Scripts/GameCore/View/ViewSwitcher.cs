using UnityEngine;

namespace Client
{
    public class ViewSwitcher : MonoBehaviour
    {
        [SerializeField] private DefaultAreaTargetEventHandler _areaTargetEvent;
        [SerializeField] private Canvas _captureLostCanvas;
        [SerializeField] private Canvas _gameplayCanvas;

        private void OnEnable()
        {
            _areaTargetEvent.OnTargetFound.AddListener(OnAreaTargetFound);
            _areaTargetEvent.OnTargetLost.AddListener(OnAreaTargetLose);
        }

        private void OnDisable()
        {
            _areaTargetEvent.OnTargetFound.RemoveListener(OnAreaTargetFound);
            _areaTargetEvent.OnTargetLost.RemoveListener(OnAreaTargetLose);
        }

        private void OnAreaTargetFound()
        {
            _captureLostCanvas.gameObject.SetActive(false);
            _gameplayCanvas.gameObject.SetActive(true);
        }

        private void OnAreaTargetLose()
        {
            _captureLostCanvas.gameObject.SetActive(false);
            _gameplayCanvas.gameObject.SetActive(true);
        }
    }
}