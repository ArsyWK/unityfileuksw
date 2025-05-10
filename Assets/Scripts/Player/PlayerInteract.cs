// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Cinemachine;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.InputSystem;

// [RequireComponent(typeof(Player))]
// [DisallowMultipleComponent]
// public class PlayerControl : MonoBehaviour
// {

//     private Player player;
//     #region Input
//     public InputActionReference _PlayerControl;
//     public InputActionReference interact;
//     public InputActionReference changeCamera;
//     public Vector2 move = Vector2.zero;
//     public Rigidbody2D rb;
//     public static PlayerControl playerControl;
//     public bool interactdeb = false;
  



//     #endregion
//     #region ChangecameraTest
//     public bool Onplayer = true;

//     public CinemachineVirtualCamera playerVC;
//     public CinemachineVirtualCamera SceneVC;
//     #endregion

//     IEnumerator waitfor()
//     {
//         if(interactdeb == false)
//         interactdeb = true;
//         yield return new WaitForSeconds(0.2f);
        
//         yield break;
//     }
//     private void Awake() 
//     {
//         if(this.rb == null) this.AddComponent<Rigidbody2D>();
//         player=GetComponent<Player>();
//         if(playerControl == null)playerControl =this; else Destroy(playerControl);
//         transform.position= new Vector3(transform.position.x,transform.position.y,0f);
//     }
//     void Start()
//     {   
//         Gamestatemanager.StatemanagerInstance.CurrentPlayerState= Playerstate.Idle;
        
        
//     }
//     private void OnEnable() 
//     {
//         interact.action.performed +=Interact;
//         _PlayerControl.action.Enable();
//         interact.action.Enable();
//         changeCamera.action.Enable();
//     }
//     void OnDisable()
//     {
//         interact.action.performed -=Interact;
//         _PlayerControl.action.Disable();
//         interact.action.Disable();
//         changeCamera.action.Disable();
//     }

//     public void Interact(InputAction.CallbackContext action)
//     {       
   
//     }
//     public void PlayerMovement()
//     {
//         if(Gamestatemanager.StatemanagerInstance.CurrentGlobalState == Global.Isgameplay)
//         {
//         move = _PlayerControl.action.ReadValue<Vector2>();
//         rb.velocity = new Vector2(move.x*5f,move.y*5f);
//         }
//     }
//     void Update()
//     {
//         PlayerMovement();
//     }
//     private void FixedUpdate() 
//     {
//     }

// }