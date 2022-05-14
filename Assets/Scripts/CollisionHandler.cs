using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArgonAssault
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] float _delayBeforeRestart = 1f;

        void OnTriggerEnter(Collider other)
        {
            StartCrashSequence();
        }

        void StartCrashSequence()
        {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponent<PlayerShoot>().enabled = false;

            StartCoroutine(CO_RestartLevel());
        }

        IEnumerator CO_RestartLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            yield return new WaitForSeconds(_delayBeforeRestart);
            SceneManager.LoadScene(currentSceneIndex);
        }

    }
}
