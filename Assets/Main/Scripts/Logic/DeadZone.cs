using Main.Scripts.Gameplay.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.Scripts.Logic
{
    public class DeadZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            
            if (other.TryGetComponent<PlayerMove>(out var move))
            {
                SceneManager.LoadSceneAsync("Test_scene");
            }
        }
    }
}