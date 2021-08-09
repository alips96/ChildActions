using UnityEngine;
using UnityEngine.SceneManagement;


namespace Child
{
    public class GameManager_GoToMenuScene : MonoBehaviour
    {
        private GameManager_Master GameManagerMaster;

        void OnEnable()
        {
            SetInitialRefrences();
            GameManagerMaster.GoToMenuSceneEvent += GoToMenuScene;
        }

        void OnDisable()
        {
            GameManagerMaster.GoToMenuSceneEvent -= GoToMenuScene;
        }

        void SetInitialRefrences()
        {
            GameManagerMaster = GetComponent<GameManager_Master>();
        }

        void GoToMenuScene()
        {
            SceneManager.LoadScene(0);
        }
    }

}
