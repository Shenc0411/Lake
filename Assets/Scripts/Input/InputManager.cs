namespace Lake.Input
{
    using Lake.Utilities;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;

    public class InputManager : Singleton<InputManager>
    {

        public enum InputMode { Controller, Keyboard };

        #region Axis Values
        private Vector2 m_leftStick;
        private Vector2 m_rightStick;
        private Vector2 m_DPad;
        private float m_leftTrigger = 0.0f;
        private float m_rightTrigger = 0.0f;
        #endregion

        #region Input Events
        private Action onButtonXPressed = default;
        private Action onButtonXReleased = default;
        private bool m_buttonXHold = false;

        private Action onButtonYPressed = default;
        private Action onButtonYReleased = default;
        private bool m_buttonYHold = false;

        private Action onButtonAPressed = default;
        private Action onButtonAReleased = default;
        private bool m_buttonAHold = false;

        private Action onButtonBPressed = default;
        private Action onButtonBReleased = default;
        private bool m_buttonBHold = false;

        private Action onLeftBumperPressed = default;
        private Action onLeftBumperReleased = default;
        private bool m_leftBumperHold = false;

        private Action onRightBumperPressed = default;
        private Action onRightBumperReleased = default;
        private bool m_rightBumperHold = false;

        private Action onDPadUpPressed = default;
        private Action onDPadUpReleased = default;
        private bool m_DPadUpHold = false;

        private Action onDPadDownPressed = default;
        private Action onDPadDownReleased = default;
        private bool m_DPadDownHold = false;

        private Action onDPadLeftPressed = default;
        private Action onDPadLeftReleased = default;
        private bool m_DPadLeftHold = false;

        private Action onDPadRightPressed = default;
        private Action onDPadRightReleased = default;
        private bool m_DPadRightHold = false;

        private Action onLeftTriggerPressed = default;
        private Action onLeftTriggerReleased = default;
        private bool m_leftTriggerHold = false;

        private Action onRightTriggerPressed = default;
        private Action onRightTriggerReleased = default;
        private bool m_rightTriggerHold = false;

        #endregion

        //#region EyeTracking
        //private bool _eyetrackingEnabled = false;
        //private GazePoint _currentGazePoint;
        //#endregion

        //public bool EyetrackingEnabled { get => _eyetrackingEnabled; }
        public Vector2 LeftStick { get => m_leftStick; }
        public Vector2 RightStick { get => m_rightStick; }
        public float LeftTrigger { get => m_leftTrigger; }
        public float RightTrigger { get => m_rightTrigger; }
        public Vector2 DPad { get => m_DPad; }
        public bool ButtonXHold { get => m_buttonXHold; }
        public bool ButtonYHold { get => m_buttonYHold; }
        public bool ButtonAHold { get => m_buttonAHold; }
        public bool LeftBumperHold { get => m_leftBumperHold; }
        public bool RightBumperHold { get => m_rightBumperHold; }
        public bool DPadUpHold { get => m_DPadUpHold; }
        public bool DPadDownHold { get => m_DPadDownHold; }
        public bool DPadLeftHold { get => m_DPadLeftHold; }
        public bool DPadRightHold { get => m_DPadRightHold; }
        public bool LeftTriggerHold { get => m_leftTriggerHold; }
        public bool RightTriggerHold { get => m_rightTriggerHold; }
        public Action OnButtonXPressed { get => onButtonXPressed; set => onButtonXPressed = value; }
        public Action OnButtonXReleased { get => onButtonXReleased; set => onButtonXReleased = value; }
        public Action OnButtonYPressed { get => onButtonYPressed; set => onButtonYPressed = value; }
        public Action OnButtonYReleased { get => onButtonYReleased; set => onButtonYReleased = value; }
        public Action OnButtonAPressed { get => onButtonAPressed; set => onButtonAPressed = value; }
        public Action OnButtonAReleased { get => onButtonAReleased; set => onButtonAReleased = value; }
        public Action OnButtonBPressed { get => onButtonBPressed; set => onButtonBPressed = value; }
        public Action OnButtonBReleased { get => onButtonBReleased; set => onButtonBReleased = value; }
        public Action OnLeftBumperPressed { get => onLeftBumperPressed; set => onLeftBumperPressed = value; }
        public Action OnLeftBumperReleased { get => onLeftBumperReleased; set => onLeftBumperReleased = value; }
        public Action OnRightBumperPressed { get => onRightBumperPressed; set => onRightBumperPressed = value; }
        public Action OnRightBumperReleased { get => onRightBumperReleased; set => onRightBumperReleased = value; }
        public Action OnDPadUpPressed { get => onDPadUpPressed; set => onDPadUpPressed = value; }
        public Action OnDPadUpReleased { get => onDPadUpReleased; set => onDPadUpReleased = value; }
        public Action OnDPadDownPressed { get => onDPadDownPressed; set => onDPadDownPressed = value; }
        public Action OnDPadDownReleased { get => onDPadDownReleased; set => onDPadDownReleased = value; }
        public Action OnDPadLeftPressed { get => onDPadLeftPressed; set => onDPadLeftPressed = value; }
        public Action OnDPadLeftReleased { get => onDPadLeftReleased; set => onDPadLeftReleased = value; }
        public Action OnDPadRightPressed { get => onDPadRightPressed; set => onDPadRightPressed = value; }
        public Action OnDPadRightReleased { get => onDPadRightReleased; set => onDPadRightReleased = value; }
        public Action OnLeftTriggerPressed { get => onLeftTriggerPressed; set => onLeftTriggerPressed = value; }
        public Action OnLeftTriggerReleased { get => onLeftTriggerReleased; set => onLeftTriggerReleased = value; }
        public Action OnRightTriggerPressed { get => onRightTriggerPressed; set => onRightTriggerPressed = value; }
        public Action OnRightTriggerReleased { get => onRightTriggerReleased; set => onRightTriggerReleased = value; }

        //public GazePoint CurrentGazePoint { get => _currentGazePoint; }


        protected override void Awake()
        {
            base.Awake();

            #region Register Hold Lambda Functions

            OnButtonAPressed += () => { m_buttonAHold = true; };
            OnButtonAReleased += () => { m_buttonAHold = false; };

            OnButtonBPressed += () => { m_buttonBHold = true; };
            OnButtonBReleased += () => { m_buttonBHold = false; };

            OnButtonXPressed += () => { m_buttonXHold = true; };
            OnButtonXReleased += () => { m_buttonXHold = false; };

            OnButtonYPressed += () => { m_buttonYHold = true; };
            OnButtonYReleased += () => { m_buttonYHold = false; };

            OnLeftBumperPressed += () => { m_leftBumperHold = true; };
            OnLeftBumperReleased += () => { m_leftBumperHold = false; };

            OnRightBumperPressed += () => { m_rightBumperHold = true; };
            OnRightBumperReleased += () => { m_rightBumperHold = false; };

            OnDPadUpPressed += () => { m_DPadUpHold = true; };
            OnDPadUpReleased += () => { m_DPadUpHold = false; };

            OnDPadDownPressed += () => { m_DPadDownHold = true; };
            OnDPadDownReleased += () => { m_DPadDownHold = false; };

            OnDPadLeftPressed += () => { m_DPadLeftHold = true; };
            OnDPadLeftReleased += () => { m_DPadLeftHold = false; };

            OnDPadRightPressed += () => { m_DPadRightHold = true; };
            OnDPadRightReleased += () => { m_DPadRightHold = false; };

            #endregion

        }

        private void Update()
        {
            #region Controller Axes Value Update
            m_leftStick.x = Input.GetAxis("LeftStickX");
            m_leftStick.y = Input.GetAxis("LeftStickY");
            m_rightStick.x = Input.GetAxis("RightStickX");
            m_rightStick.y = Input.GetAxis("RightStickY");
            m_leftTrigger = Input.GetAxis("LeftTrigger");
            m_rightTrigger = Input.GetAxis("RightTrigger");
            m_DPad.x = Input.GetAxis("DPadX");
            m_DPad.y = Input.GetAxis("DPadY");
            #endregion

            //#region EyeTracking

            //if (!TobiiAPI.IsConnected)
            //{
            //    Debug.LogError("Eyetracking Device Not Found!");
            //    _eyetrackingEnabled = false;
            //}
            //else
            //{
            //    _currentGazePoint = TobiiAPI.GetGazePoint();
            //}

            //#endregion

            #region Event Broadcasting
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                OnButtonAPressed?.Invoke();
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button0))
            {
                OnButtonAReleased?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                OnButtonBPressed?.Invoke();
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button1))
            {
                OnButtonBReleased?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                OnButtonXPressed?.Invoke();
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button2))
            {
                OnButtonXReleased?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                OnButtonYPressed?.Invoke();
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button3))
            {
                OnButtonYReleased?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button4))
            {
                OnLeftBumperPressed?.Invoke();
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button4))
            {
                OnLeftBumperReleased?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                OnRightBumperPressed?.Invoke();
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button5))
            {
                OnRightBumperReleased?.Invoke();
            }

            if (m_leftTriggerHold && m_leftTrigger == 0.0f)
            {
                OnLeftTriggerReleased?.Invoke();
                m_leftTriggerHold = false;
            }
            else if (!m_leftTriggerHold && m_leftTrigger > 0.0f)
            {
                OnLeftTriggerPressed?.Invoke();
                m_leftTriggerHold = true;
            }

            if (m_rightTriggerHold && m_rightTrigger == 0.0f)
            {
                OnRightTriggerReleased?.Invoke();
                m_rightTriggerHold = false;
            }
            else if (!m_rightTriggerHold && m_rightTrigger > 0.0f)
            {
                OnRightTriggerPressed?.Invoke();
                m_rightTriggerHold = true;
            }

            #endregion

        }
    }
}