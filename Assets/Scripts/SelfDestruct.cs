using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArgonAssault
{
    public class SelfDestruct : MonoBehaviour
    {
        [SerializeField] float _timeTillDestruction = 2f;

        private void Start()
        {
            Destroy(gameObject, _timeTillDestruction);
        }
    }
}
