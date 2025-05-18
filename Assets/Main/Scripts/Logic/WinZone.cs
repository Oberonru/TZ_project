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
            print("false active");
        }

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.TryGetComponent<PlayerMove>(out var move))
            {
                print("Trigger enter");
                winUi.SetActive(true);
            }
        }
    }
}