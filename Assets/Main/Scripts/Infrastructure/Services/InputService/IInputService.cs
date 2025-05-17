using Main.Scripts.Services;
using UnityEngine;

namespace Main.Scripts.Infrastructure.Services.InputService
{
    public interface IInputService : IService
    {
        Vector2 Axis();
        bool Jump();
    }
}