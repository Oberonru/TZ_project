using Main.Scripts.Camera;
using Main.Scripts.Infrastructure.Factory;
using UnityEngine;

namespace Main.Scripts.Infrastructure.States
{
    public class GameBootstrap : MonoBehaviour
    {
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
            var player = _gameFactory.CreateGameObjectInPoint(_playerPath, point);
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