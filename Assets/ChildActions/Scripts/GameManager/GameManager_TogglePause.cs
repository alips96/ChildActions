using UnityEngine;


namespace Child
{
    public class GameManager_TogglePause : MonoBehaviour
    {
        private GameManager_Master GameManagerMaster;
        private bool isPaused;

        void OnEnable()
        {
            SetInitialRefrences();
            GameManagerMaster.MenuToggleEvent += TogglePause;
        }

        void OnDisable()
        {
            GameManagerMaster.MenuToggleEvent -= TogglePause;
        }

        void SetInitialRefrences()
        {
            GameManagerMaster = GetComponent<GameManager_Master>();
        }

        void TogglePause() // if the game was paused switch it to normal but if the game was normal pause it!
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }
}

