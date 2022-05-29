using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArgonAssault
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] float _delayBeforeRestart = 1f;
        [SerializeField] ParticleSystem _explosionParticles;
        
        void OnTriggerEnter(Collider other)
        {
            StartCrashSequence();
        }

        void StartCrashSequence()
        {
            GetComponent<AudioSource>().Play();
            _explosionParticles.Play();
            DisableComponents();
            StartCoroutine(CO_RestartLevel());
        }

        void DisableComponents()
        {
            transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerShoot>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }

        IEnumerator CO_RestartLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            yield return new WaitForSeconds(_delayBeforeRestart);
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
