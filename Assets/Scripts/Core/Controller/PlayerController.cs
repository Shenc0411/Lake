namespace Lake.Core.Controller
{
    
    using Lake.Core.Character;
    using Lake.Input;
    using Lake.Interfaces;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerController : MonoBehaviour, IControllable
    {
        private InputManager inputManager = default;
        private Camera FPSCamera = default;

        [SerializeField]
        private Character character = default;


        private float minPitchAngle = -60.0f;
        private float maxPitchAngle = 60.0f;
        private float currentPitchAngle = 0.0f;
        private float pitchSpeed = 45.0f; 

        private float currentFacingAngleRad = 90.0f * Mathf.Deg2Rad;
        private Vector3 actualProjectedForward = default;
        private Quaternion actualProjectedRotation = default;
        
        private Vector3 movement = default;

        public Character Character { get => this.character; set => this.character = value; }
        public Vector3 ActualProjectedForward { get => this.actualProjectedForward; }
        public Quaternion ActualProjectedRotation { get => this.actualProjectedRotation; }

        #region Input Callbacks
        public void Callback_OnButtonAPressed()
        {
            this.character.Interact();
        }

        public void Callback_OnButtonAReleased()
        {
            
        }

        public void Callback_OnButtonBPressed()
        {
            
        }

        public void Callback_OnButtonBReleased()
        {
            
        }

        public void Callback_OnButtonXPressed()
        {
            
        }

        public void Callback_OnButtonXReleased()
        {
            
        }

        public void Callback_OnButtonYPressed()
        {
            
        }

        public void Callback_OnButtonYReleased()
        {
            
        }

        public void Callback_OnDPadDownPressed()
        {
            
        }

        public void Callback_OnDPadDownReleased()
        {
            
        }

        public void Callback_OnDPadLeftPressed()
        {
            
        }

        public void Callback_OnDPadLeftReleased()
        {
            
        }

        public void Callback_OnDPadRightPressed()
        {
            
        }

        public void Callback_OnDPadRightReleased()
        {
            
        }

        public void Callback_OnDPadUpPressed()
        {
            
        }

        public void Callback_OnDPadUpReleased()
        {
            
        }

        public void Callback_OnLeftBumperPressed()
        {
            
        }

        public void Callback_OnLeftBumperReleased()
        {
            
        }

        public void Callback_OnLeftTriggerPressed()
        {
            
        }

        public void Callback_OnLeftTriggerReleased()
        {
            
        }

        public void Callback_OnRightBumperPressed()
        {
            
        }

        public void Callback_OnRightBumperReleased()
        {
            
        }

        public void Callback_OnRightTriggerPressed()
        {
            
        }

        public void Callback_OnRightTriggerReleased()
        {
            
        }
        #endregion

        private void Awake()
        {
            
        }

        private void Start()
        {
            if (InputManager.Instance != null)
            {
                InputManager.Instance.RegisterControllable(this);
                this.inputManager = InputManager.Instance;
            }
            else
            {
                Debug.LogError("InputManager not found. Destroying gameobject " + name);
                Destroy(this.gameObject);
            }

            this.FPSCamera = Camera.main;
            if (this.FPSCamera == null)
            {
                Debug.LogError("InputManager not found. Destroying gameobject " + name);
                Destroy(this.gameObject);
            }
        }

        private void Update()
        {
            this.MovementHandler();
        }

        private void MovementHandler()
        {
            Vector2 rawRotationInput = this.inputManager.RightStick;

            this.currentFacingAngleRad += -rawRotationInput.x * this.character.RotationSpeed * Time.deltaTime;

            if (this.currentFacingAngleRad > 2.0f * Mathf.PI)
            {
                this.currentFacingAngleRad -= 2.0f * Mathf.PI;
            }
            else if (this.currentFacingAngleRad < -2.0f * Mathf.PI)
            {
                this.currentFacingAngleRad += 2.0f * Mathf.PI;
            }
            
            this.actualProjectedForward.x = Mathf.Cos(this.currentFacingAngleRad);
            this.actualProjectedForward.z = Mathf.Sin(this.currentFacingAngleRad);
            this.actualProjectedRotation = Quaternion.LookRotation(this.actualProjectedForward, Vector3.up);

            this.currentPitchAngle += rawRotationInput.y * this.pitchSpeed * Time.deltaTime;
            this.currentPitchAngle = Mathf.Clamp(this.currentPitchAngle, this.minPitchAngle, this.maxPitchAngle);

            this.transform.rotation = this.actualProjectedRotation;
            this.FPSCamera.transform.rotation = this.actualProjectedRotation;
            this.FPSCamera.transform.Rotate(new Vector3(this.currentPitchAngle, 0, 0));

            Vector2 rawMovement = this.inputManager.NormalizedLeftStick;
            this.movement.x = rawMovement.x;
            this.movement.z = -rawMovement.y;

            this.movement = this.actualProjectedRotation * this.movement * this.character.MoveSpeed * Time.deltaTime;

            this.transform.position += this.movement;
        }



    }

}