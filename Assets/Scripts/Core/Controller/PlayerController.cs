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
        [SerializeField]
        private Character m_character = default;

        private InputManager m_inputManager = default;

        public Character Character { get => m_character; set => m_character = value; }

        #region Input Callbacks
        public void Callback_OnButtonAPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnButtonAReleased()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnButtonBPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnButtonBReleased()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnButtonXPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnButtonXReleased()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnButtonYPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnButtonYReleased()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnDPadDownPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnDPadDownReleased()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnDPadLeftPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnDPadLeftReleased()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnDPadRightPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnDPadRightReleased()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnDPadUpPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnDPadUpReleased()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnLeftBumperPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnLeftBumperReleased()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnLeftTriggerPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnLeftTriggerReleased()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnRightBumperPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnRightBumperReleased()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnRightTriggerPressed()
        {
            throw new System.NotImplementedException();
        }

        public void Callback_OnRightTriggerReleased()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        private void Awake()
        {
            
        }

        private void Start()
        {
            if(InputManager.Instance != null)
            {
                InputManager.Instance.RegisterControllable(this);
                m_inputManager = InputManager.Instance;
            }
            else
            {
                Debug.LogError("InputManager not found. Destroying gameobject " + name);
            }
        }

    }

}