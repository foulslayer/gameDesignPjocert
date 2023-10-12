using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using player;
using JetBrains.Annotations;

namespace player
{
    public class SpotWaecher : MonoBehaviour
    {
        private enum InputState
        {
            None,   // Initial state
            Key1,
            Key2,
            Key3
        }

        private InputState currentState = InputState.None;
        private PlayerMovement playerMovement;
        private Animator _animator;
        private bool frezze = false;
        private GameObject playerObject; // Declare the playerObject at the class level

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // Assign the "Player" GameObject to playerObject
                playerObject = other.gameObject;

                playerMovement = playerObject.GetComponent<PlayerMovement>();

                if (playerMovement != null)
                {
                    playerMovement._moveSpeed = 0f;
                    _animator.speed = 0;
                    Debug.Log("Hit detected");
                    frezze = true;
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            // InvokeRepeating("Rotate", 2.1f, 3.0f);
        }

        public void Rotate()
        {
            Transform spotColliderTransform = transform.Find("Spotcollider");
            if (spotColliderTransform != null)
            {
                spotColliderTransform.Rotate(Vector3.forward * -90.0f);
            }
        }

        void Update()
        {
            if (frezze)
            {
                switch (currentState)
                {
                    case InputState.None:
                        if (Input.GetKeyDown(KeyCode.A))
                        {
                            currentState = InputState.Key1;
                            Debug.Log("A key pressed");
                        }
                        break;

                    case InputState.Key1:
                        if (Input.GetKeyDown(KeyCode.B))
                        {
                            currentState = InputState.Key2;
                            Debug.Log("B key pressed");
                        }
                        break;

                    case InputState.Key2:
                        if (Input.GetKeyDown(KeyCode.C))
                        {
                            currentState = InputState.Key3;
                            Debug.Log("C key pressed");

                            if (playerObject != null)
                            {
                                PlayerMovement playerMovement = playerObject.GetComponent<PlayerMovement>();
                                if (playerMovement != null)
                                {
                                    playerMovement._moveSpeed = 10f;
                                    frezze = false;
                                    // Handle completion of the sequences
                                     // Call the ResetState method to reset the state to None
                                     _animator.speed = 1;
                                    ResetState();
                                }
                            }
                        }
                        break;
                }
            }
        }

        private void ResetState()
{
    currentState = InputState.None;
}
    }
}