namespace GD.Tick
{
    /// <summary>
    /// Any class that implements this interface can be used to handle ticks.
    /// This is useful for classes that need to update at a rate (e.g. 1x, 2x, 4x, 8x) less than every frame.
    /// </summary>
    public interface IHandleTicks
    {
        void HandleTick();
    }
}