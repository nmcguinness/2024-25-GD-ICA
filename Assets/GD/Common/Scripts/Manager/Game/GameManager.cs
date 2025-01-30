using UnityEngine;

namespace GD
{
    /// <summary>
    /// Manages the game's main loop including start, play, and end phases.
    /// Also handles pausing functionality.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Fields

        private bool isPaused;

        #endregion Fields

        #region Properties

        public bool IsPaused
        {
            get => isPaused;
            set
            {
                isPaused = value;
                // Adjust the game's timescale based on pause state.
                Time.timeScale = isPaused ? 0 : 1;
            }
        }

        #endregion Properties

        //TODO - ALL: Add more game logic as needed.
    }
}