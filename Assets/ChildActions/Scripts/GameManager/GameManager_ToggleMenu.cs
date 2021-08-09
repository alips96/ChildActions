using UnityEngine;


namespace Child
{
    public class GameManager_ToggleMenu : MonoBehaviour
    {
        private GameManager_Master GameManagerMaster;
        public GameObject Menu;
        public GameObject GameOverMenu;

        // Use this for initialization
        void Start()
        {
            ToggleMenu();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForMenuToggleRequest();
        }

        void OnEnable()
        {
            SetInitialRefrences();
            GameManagerMaster.GameOverEvent += ToggleMenu;
        }

        void OnDisable()
        {
            GameManagerMaster.GameOverEvent -= ToggleMenu;
        }

        void SetInitialRefrences()
        {
            GameManagerMaster = GetComponent<GameManager_Master>();
        }

        void CheckForMenuToggleRequest()
        {
            if (Input.GetKeyUp(KeyCode.Escape) && !GameManagerMaster.isGameOver && !GameManagerMaster.isInvetoryUIOn)
                ToggleMenu();
        }

        void ToggleMenu()
        {
            if (Menu != null)
            {
                Menu.SetActive(!Menu.activeSelf); // it toggles the current state
                GameManagerMaster.isMenuOn = !GameManagerMaster.isMenuOn;
                GameManagerMaster.CallEventMenuToggle();

                if(GameOverMenu != null)
                {
                    if (GameManagerMaster.isGameOver)
                        GameOverMenu.SetActive(true);
                }
            }
            else
            {
                Debug.LogWarning("You need to assign a UI GameObject to the toggle menu script in the inspector.");
            }
        }
    }
}

