using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArgonAssault
{
    public class Enemy : MonoBehaviour
    {
        private void OnParticleCollision(GameObject other)
        {
            Debug.Log($"{name}: I'm hit by {other.name}");
            Destroy(gameObject);
        }
    }
}
