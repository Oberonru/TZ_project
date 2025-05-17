using Main.Scripts.Camera;
using Main.Scripts.Gameplay.Player;
using Main.Scripts.Infrastructure.Factory;
using Main.Scripts.Infrastructure.Services.InputService;
using Unity.VisualScripting;
using UnityEngine;

namespace Main.Scripts.Infrastructure.States
{
    public class GameBootstrap : MonoBehaviour
    {
        private string InputServicePath = "Player/InputService";

        public UnityEngine.Camera mainCamera;
        public GameObject InitialPoint;
        private GameFactory _gameFactory;
        private string _playerPath = "Player/Player_prefab";
        private string _uiPath = "UI/Canvas_game";
        private CameraLogic _cameraLogic;

        private void Start()
        {
            var position = InitialPoint.transform.position;
            var point = new Vector3(position.x, position.y, position.z);
            _gameFactory = new GameFactory();

            var inputService = _gameFactory.CreateGameObject(InputServicePath);
            var player = _gameFactory.CreateGameObjectInPoint(_playerPath, point);

            player.GetComponentInChildren<PlayerMove>().Init(inputService.GetComponent<InputService>());

            var ui = _gameFactory.CreateGameObject(_uiPath);
            _cameraLogic = mainCamera.GetComponent<CameraLogic>();
            
            CameraFollow(player);
        }


        private void CameraFollow(GameObject target)
        {
            mainCamera.GetComponent<CameraLogic>().Follow(target);
        }
    }
}