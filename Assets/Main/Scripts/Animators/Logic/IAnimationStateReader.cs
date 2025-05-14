namespace Main.Scripts.Animators.Logic
{
    public interface IAnimationStateReader
    {
        void EnteredState(int stateHash);
        void ExitedState(int stateHash);
        
        AnimationType AnimationType { get; }
    }
}