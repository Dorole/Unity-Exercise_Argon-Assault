using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ArgonAssault
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] InputAction _shooting;
        [SerializeField] GameObject[] _lasers;

        #region ENABLE/DISABLE
        private void OnEnable() => _shooting.Enable();

        private void OnDisable() => _shooting.Disable();

        #endregion

        private void Start()
        {
            ActivateLasers(false);
        }

        private void Update()
        {
            Shoot();
        }

        void Shoot()
        {
            if (_shooting.IsPressed())
                ActivateLasers(true);
            else
                ActivateLasers(false);
        }

        void ActivateLasers(bool isActive)
        {
            foreach (var laser in _lasers)
                laser.SetActive(isActive);
        }
    }
}
