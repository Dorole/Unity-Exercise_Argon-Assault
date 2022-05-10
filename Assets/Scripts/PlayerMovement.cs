using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ArgonAssault
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] InputAction _movement;
        [SerializeField] float _controlSpeed = 30f;
        [SerializeField] float _xRange, _yRange;

        [Space] [Header("Rotation")]
        [SerializeField] float _rotationFactor;
        [SerializeField] float _positionPitchFactor, _inputPitchFactor;
        [SerializeField] float _positionYawFactor;
        [SerializeField] float _inputRollFactor;

        float _horizontalMovement;
        float _verticalMovement;

        #region ENABLE/DISABLE
        private void OnEnable() => _movement.Enable();

        private void OnDisable() => _movement.Disable();
        #endregion

        private void Update()
        {
            ReadInput();
            MovePlayer();
            RotatePlayer();
        }

        void ReadInput()
        {
            _horizontalMovement = _movement.ReadValue<Vector2>().x;
            _verticalMovement = _movement.ReadValue<Vector2>().y;
        }

        void MovePlayer()
        {
            transform.localPosition = new Vector3(GetXPosition(), GetYPosition(), transform.localPosition.z);
        }

        float GetXPosition()
        {
            float xOffset = _horizontalMovement * _controlSpeed * Time.deltaTime;
            float rawXPos = transform.localPosition.x + xOffset;
            return Mathf.Clamp(rawXPos, -_xRange, _xRange);
        }

        float GetYPosition()
        {
            float yOffset = _verticalMovement * _controlSpeed * Time.deltaTime;
            float rawYPos = transform.localPosition.y + yOffset;
            return Mathf.Clamp(rawYPos, -_yRange, _yRange);
        }

        void RotatePlayer()
        {
            float pitchDueToPosition = transform.localPosition.y * _positionPitchFactor;
            float pitchDueToInput = _verticalMovement * _inputPitchFactor;

            float pitch = pitchDueToPosition + pitchDueToInput;
            float yaw = transform.localPosition.x * _positionYawFactor;
            float roll = _horizontalMovement * _inputRollFactor;

            Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, _rotationFactor);
        }
    }
}
