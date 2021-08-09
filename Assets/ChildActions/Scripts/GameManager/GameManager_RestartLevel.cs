using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Child
{
    public class GameManager_RestartLevel : MonoBehaviour
    {
        private GameManager_Master GameManagerMaster;

        void OnEnable()
        {
            SetInitialRefrences();
            GameManagerMaster.RestartLevelEvent += RestartLevel;
        }

        void OnDisable()
        {
            GameManagerMaster.RestartLevelEvent -= RestartLevel;
        }

        void SetInitialRefrences()
        {
            GameManagerMaster = GetComponent<GameManager_Master>();
        }

        void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);// Just restarting!
        }
    }
}

