using UnityEngine;
using Utility;
using UnityEngine.InputSystem;
using DG.Tweening;

namespace Player
{
    public class Interaction : MonoBehaviour
    {
        private Camera maincamera;
        public InputActionReference interactAction;
        public Cardback cardback;
        public InputActionReference Abutton;
        public InputActionReference Dbutton;
        public InputActionReference Spacebutton;


        
         
        public void Apress(InputAction.CallbackContext action)
        {
            if(Abutton.action.triggered && Cookingbrain.instance.state == Cookingbrain.cookingstate.isPlaying)
            {
                Cookingbrain.instance.valbutton.Add(1);
                
            }
        }
        
        public void Dpress(InputAction.CallbackContext action)
        {
            if(Abutton.action.triggered && Cookingbrain.instance.state == Cookingbrain.cookingstate.isPlaying)
            {
                Cookingbrain.instance.valbutton.Add(2);
            }
        }
        
        public void Spacepress(InputAction.CallbackContext action)
        {
            if(Abutton.action.triggered && Cookingbrain.instance.state == Cookingbrain.cookingstate.isPlaying)
            {
                Cookingbrain.instance.valbutton.Add(3);
            }
        }
        public void Interact(InputAction.CallbackContext action)
        {       
            Debug.Log("from interact");
        }
          public void Onclick(InputAction.CallbackContext context)
        {
            if (Mouse.current == null || !Mouse.current.leftButton.wasPressedThisFrame)
            return;
            if(Gamestatemanager.StatemanagerInstance.CurrentGlobalState == Global.Isonmenu)
            if(!context.started) return;
            RaycastHit2D rayhit = Physics2D.GetRayIntersection(maincamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
            if(!rayhit.collider)return;
            if(rayhit.collider.gameObject.CompareTag("Card"))
            {   
                if( rayhit.collider.GetComponent<Cardback>() != null && rayhit.collider.GetComponent<Cardback>().flipped == false &&Cardbrain.instance.Comparecard.Count<=2)
                {
                    rayhit.collider.GetComponent<Cardback>().flipped = true;
                    rayhit.collider.gameObject.transform.DORotate(
                        new Vector3(0,180f, 0), 0.25f).OnComplete(() =>Cardbrain.instance.Comparecard.Add(rayhit.collider.transform.parent.gameObject)
);
                   
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("npc"))
            {
                
            }
            else if (other.CompareTag("door"))
            {
                
            }
            else if (other.CompareTag("obj"))
            {
                
            }
            GameManager.Instance.npcName = other.gameObject.name;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            GameManager.Instance.npcName = string.Empty;
        }
        
        private void Start() {
            
        }
        private void Awake() {
            maincamera = Camera.main;
        }
        void Update()
        {
      
        }
        private void OnEnable() {
            interactAction.action.performed +=Interact;
        }
         private void OnDisable() {
            interactAction.action.performed -=Interact;
        }
    }
}
