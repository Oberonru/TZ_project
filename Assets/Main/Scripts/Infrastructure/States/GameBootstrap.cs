using Main.Scripts.Camera;
using Main.Scripts.Gameplay.Player;
using Main.Scripts.Infrastructure.Factory;
using Main.Scripts.Infrastructure.Services.InputService;
using Unity.Cinemachine;
using UnityEngine;

namespace Main.Scripts.Infrastructure.States
{
    public class GameBootstrap : MonoBehaviour
    {
        public CinemachineVirtualCamera virtualCamera;
        public UnityEngine.Camera mainCamera;
        public GameObject InitialPoint;

        private GameFactory _gameFactory;
        private string _playerPath = "Player/Player";
        private string _uiPath = "UI/Canvas_game";
        private string InputServicePath = "Player/InputService";

        private void Start()
        {
            var position = InitialPoint.transform.position;
            var point = new Vector3(position.x, position.y, position.z);
            _gameFactory = new GameFactory();

            var inputService = _gameFactory.CreateGameObject(InputServicePath);
            var player = _gameFactory.CreateGameObjectInPoint(_playerPath, point);

            player.GetComponentInChildren<PlayerMove>().Init(inputService.GetComponent<InputService>());

            _gameFactory.CreateGameObject(_uiPath);
            
            CameraFollow(player);
        }

        private void CameraFollow(GameObject target)
        {
            mainCamera.GetComponent<CameraLogic>().Follow(target);
        }
    }
}