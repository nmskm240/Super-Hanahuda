namespace SuperHanahuda.Game.TurnSystem
{
    public interface IStep<T>
    {
        void Execute(T t);
    }
}