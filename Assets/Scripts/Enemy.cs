using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArgonAssault
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] GameObject _deathParticles;
        [SerializeField] Transform _vfxParent;

        private void OnParticleCollision(GameObject other)
        {
            //pool this!
            GameObject vfx = Instantiate(_deathParticles, transform.position, Quaternion.identity);
            vfx.transform.parent = _vfxParent;

            Destroy(gameObject);
        }
    }
}
