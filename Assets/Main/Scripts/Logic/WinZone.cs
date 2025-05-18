using Main.Scripts.Gameplay.Player;
using UnityEngine;

namespace Main.Scripts.Logic
{
    public class WinZone : MonoBehaviour
    {
        public GameObject winUi;

        private void Start()
        {
            winUi.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.TryGetComponent<PlayerMove>(out var move))
            {
                winUi.SetActive(true);
            }
        }
    }
}