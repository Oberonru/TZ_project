using Main.Scripts.Infrastructure.Factory;
using UnityEngine;

namespace Main.Scripts.Infrastructure.States
{
    public class GameBootstrap : MonoBehaviour
    {
        private GameFactory _gameFactory;
        private string _playerPath = "Player/Player_prefab";
        private string _uiPath = "UI/Canvas_game";

        private void Start()
        {
            _gameFactory = new GameFactory();
            var player = _gameFactory.CreateGameObject(_playerPath);
            var ui = _gameFactory.CreateGameObject(_uiPath);
        }
    }
}