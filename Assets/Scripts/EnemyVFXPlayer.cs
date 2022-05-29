using UnityEngine;

namespace ArgonAssault
{
    public class EnemyVFXPlayer : MonoBehaviour
    {
        //pool for effects
        [SerializeField] GameObject _hitParticles;
        [SerializeField] GameObject _deathParticles;
        GameObject _vfxParent;

        private void Start()
        {
            _vfxParent = GameObject.FindGameObjectWithTag("VFX Parent");
        }

        public void PlayHitEffect()
        {
            if (!_hitParticles)
                Debug.LogWarning($"Hit effect on {gameObject.name} missing!");

            GameObject vfx = Instantiate(_hitParticles, transform.position, Quaternion.identity);
            vfx.transform.parent = _vfxParent.transform;
        }

        public void PlayKillEffect()
        {
            if (!_deathParticles)
                Debug.LogWarning($"Death effect on {gameObject.name} missing!");

            GameObject vfx = Instantiate(_deathParticles, transform.position, Quaternion.identity);
            vfx.transform.parent = _vfxParent.transform;
        }

    }
}
