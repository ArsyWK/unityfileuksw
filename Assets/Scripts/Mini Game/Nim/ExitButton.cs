using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Main_Menu
{
    public class ExitButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
    
    public static ExitButton exitButtoninstance;
    public bool buttonpressed = false;

        void Awake()
        {
            if(exitButtoninstance ==null) exitButtoninstance = this;else Destroy(exitButtoninstance);
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            Image buttonImage = eventData.pointerEnter.GetComponent<Image>();
            if (buttonImage != null )
            {buttonImage.color = new Color32(255,255,255,188);}
            else if (buttonImage != null && buttonpressed == true){buttonImage.color = new Color32(255,255,255,255);}   
        } 
    public void click()
    {
        if(buttonpressed ==false)
        {
        Debug.Log("this button pressed");
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
