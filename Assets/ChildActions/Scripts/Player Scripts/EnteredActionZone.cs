using UnityEngine;
using UnityEngine.AI;

namespace Child
{
    public class EnteredActionZone : MonoBehaviour
    {
        public string inputString;
        public GameObject mainCamera;
        public GameObject faceCamera;
        Player_Input playerInput;

        private void Start()
        {
            playerInput = GameObject.Find("Santa").GetComponent<Player_Input>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                DisableNavMeshAgent(other);
                WaitForPlayerInput();
            }
        }

        private void WaitForPlayerInput()
        {
            playerInput.enabled = true;
            playerInput.Trigger = gameObject;
            playerInput.InputString = inputString;
        }

        private void DisableNavMeshAgent(Collider santa)
        {
            santa.GetComponent<NavMeshAgent>().isStopped = true;

            faceCamera.SetActive(true);
        }
    }
}

