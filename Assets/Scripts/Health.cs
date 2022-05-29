using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArgonAssault
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int _hitPoints = 30;

        void DecreaseHealth(int damage)
        {
            _hitPoints -= damage;

            if (_hitPoints <= 0)
            {

            }
        }
    }
}
