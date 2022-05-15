using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArgonAssault
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] GameObject _deathParticles;
        [SerializeField] Transform _vfxParent;
        [SerializeField] int _scorePerHit = 15;
        ScoreBoard _scoreBoard;

        void Start()
        {
            _scoreBoard = FindObjectOfType<ScoreBoard>();
        }

        void OnParticleCollision(GameObject other)
        {
            ProcessHit();
            KillEnemy();
        }


        void ProcessHit()
        {
            _scoreBoard.IncreaseScore(_scorePerHit);
        }

        void KillEnemy()
        {
            //pool this!
            GameObject vfx = Instantiate(_deathParticles, transform.position, Quaternion.identity);
            vfx.transform.parent = _vfxParent;

            Destroy(gameObject);
        }
    }
}
