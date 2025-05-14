using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main.Scripts.UI
{
    public class WinUi : MonoBehaviour
    {
        public Button restart;
        public Button exit;

        private void Start()
        {
            restart.onClick.AddListener(RestartGame);
            exit.onClick.AddListener(ExitGame);
        }


        private void RestartGame()
        {
            SceneManager.LoadSceneAsync("Test_scene");
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}