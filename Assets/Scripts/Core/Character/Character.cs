namespace Lake.Core.Character
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Character : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 4.0f;
        [SerializeField]
        private float rotationSpeed = 90.0f * Mathf.Deg2Rad;

        public float MoveSpeed { get => this.moveSpeed; set => this.moveSpeed = value; }
        public float RotationSpeed { get => this.rotationSpeed; set => this.rotationSpeed = value; }

        /// <summary>
        /// The general interaction function. Should create an interaction menu if character is player.
        /// </summary>
        public void Interact()
        {
            Debug.Log("Character " + this.name + " begin interaction.");
        }

    }

}