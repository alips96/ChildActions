﻿using UnityEngine;
using System.Collections;

namespace Child
{
    public class GameManager_Master : MonoBehaviour
    {
        public delegate void GameManagerEventhandler();
        public event GameManagerEventhandler MenuToggleEvent;
        public event GameManagerEventhandler RestartLevelEvent;
        public event GameManagerEventhandler GoToMenuSceneEvent;
        public event GameManagerEventhandler GameOverEvent;

        public bool isGameOver;
        public bool isInvetoryUIOn;
        public bool isMenuOn;

        public void CallEventMenuToggle()
        {
            if (MenuToggleEvent != null)
                MenuToggleEvent();
        }

        public void CallEventRestartLevel()
        {
            if (RestartLevelEvent != null)
                RestartLevelEvent();
        }

        public void CallEventMenuScene()
        {
            if (GoToMenuSceneEvent != null)
                GoToMenuSceneEvent();
        }

        public void CallEventGameOver()
        {
            if (GameOverEvent != null)
            {
                isGameOver = true;
                GameOverEvent();
            }
        }


    }
}


