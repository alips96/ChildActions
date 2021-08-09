using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Child
{
    public class Player_Input : MonoBehaviour
    {
        string inputString;
        NavMeshAgent myNavMeshAgent;
        public GameObject mainCamera;
        public GameObject faceCamera;
        GameObject trigger;

        private void Start()
        {
            if (GetComponent<NavMeshAgent>() != null)
                myNavMeshAgent = GetComponent<NavMeshAgent>();
            else
                Debug.LogWarning("NavMesh is not attached to the player!");
        }

        public GameObject Trigger
        {
            set
            {
                trigger = value;
            }
        }

        public string InputString
        {
            set
            {
                inputString = value;
            }
        }

        private void Update()
        {
            WaitForInput();
        }

        private void WaitForInput()
        {
            if (Input.GetKeyDown(inputString)) // The Actual Input Section
            {
                Destroy(trigger);
                ResumeNavMeshAgent();
                DisableThisScript();
            }
        }

        private void DisableThisScript()
        {
            enabled = false;
        }

        private void ResumeNavMeshAgent()
        {
            myNavMeshAgent.isStopped = false;
            faceCamera.SetActive(false);
        }
    }
}

