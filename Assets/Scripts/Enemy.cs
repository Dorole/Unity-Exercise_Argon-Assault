using UnityEngine;

namespace ArgonAssault
{
    [RequireComponent(typeof(EnemyVFXPlayer))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] int _scorePerHit = 15;
        [SerializeField] int _hitPoints = 4;

        ScoreBoard _scoreBoard;
        EnemyVFXPlayer _effectPlayer;



        void Start()
        {
            _scoreBoard = FindObjectOfType<ScoreBoard>();
            _effectPlayer = GetComponent<EnemyVFXPlayer>();
            AddRigidbody();
        }

        void AddRigidbody()
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
        }

        void OnParticleCollision(GameObject other)
        {
            ProcessHit();
        }

        void ProcessHit()
        {
            _hitPoints--;

            if (_hitPoints < 1)
            {
                _scoreBoard.IncreaseScore(_scorePerHit);
                _effectPlayer.PlayKillEffect();
                Destroy(gameObject);
            }
            else
                _effectPlayer.PlayHitEffect();
        }
    }
}
