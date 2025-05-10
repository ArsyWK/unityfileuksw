using UnityEngine;
using Utility;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public Animator animator;
        private Vector2 _moveInput;
        private Rigidbody2D _rb;
        
        private PlayerInput _controls;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _controls = new PlayerInput();
            
            _controls.Player.Move.performed += ctx =>
            {
                _moveInput = ctx.ReadValue<Vector2>();
            };
            
            _controls.Player.Move.canceled += ctx =>
            {
                _moveInput = Vector2.zero;
            };
            _controls.Player.Interact.performed += ctx =>
            {
                Interact();
            };
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void Update()
        {
            if (_moveInput != Vector2.zero)
            {
                animator.SetBool("isWalk",true);
            }
            else
            {
                animator.SetBool("isWalk", false);
            }
        }

        private void FixedUpdate()
        {
            if (_moveInput != Vector2.zero)
            {
                if (_moveInput.x == 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            if (GameManager.Instance.canMove)
            {
                Move();
            }
            if (!GameManager.Instance.dialogRun)
            {
                GameManager.Instance.canMove = true;
            }
        }

        private void Interact()
        {
            if (GameManager.Instance.npcName != string.Empty && GameManager.Instance.IsMinigame == false)
            {
                GameManager.Instance.npcInteract = true;
                GameManager.Instance.dialogRun = true;
                GameManager.Instance.canMove = false;
            }
        }

        void Move()
        {
            Vector2 movement = new Vector2(_moveInput.x, 0f);
            _rb.linearVelocity = movement * moveSpeed;
        
        }
    }
}
