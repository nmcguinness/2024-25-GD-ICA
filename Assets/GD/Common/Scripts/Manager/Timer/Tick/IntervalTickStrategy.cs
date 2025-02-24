namespace GD.Utility
{
    public class IntervalTickStrategy : ITickStrategy
    {
        /// <summary>
        /// Multiples of the TimeTickSystem interval (updateTickInterval or fixedUpdateTickInterval) will trigger the tick.
        /// </summary>
        private int interval;

        public IntervalTickStrategy(int interval)
        {
            this.interval = interval > 0 ? interval : 1;
        }

        public bool TickEvery(int tickCount) => tickCount % interval == 0;
    }
}