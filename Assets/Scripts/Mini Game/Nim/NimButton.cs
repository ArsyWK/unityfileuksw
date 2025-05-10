using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Mini_Game.Nim
{
    public abstract class NimButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        public static NimButton buttoninstance;
        public bool buttonpressed = false;
        void Awake()
        {
            if(buttoninstance ==null) buttoninstance = this;else Destroy(buttoninstance);
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            Image buttonImage = eventData.pointerEnter.GetComponent<Image>();
            if (buttonImage != null )
            {buttonImage.color = new Color32(255,255,255,188);}
            else if (buttonImage != null && buttonpressed == true){buttonImage.color = new Color32(255,255,255,255);}   
        } 
        public void Click()
        {
            if(buttonpressed ==false)
            {
                buttonpressed = true;
            }
        
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            Image buttonImage = eventData.pointerEnter.GetComponent<Image>();
            if (buttonImage != null )
            {
                buttonImage.color = new Color32(255,255,255,255);
            }
            
        }
        
    }
}
