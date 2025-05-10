using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class Card : MonoBehaviour
{ 
    
    
    public bool IsOverlapping;
    private bool hasScoredThisDrag = false;
    


    void Start()
    {
        
        
    }
    void Awake()
    {
        
    }
    void OnEnable()
    {
    }

    void Update()
    {
        

        IsOverlapping = RectTransformUtility.RectangleContainsScreenPoint(
           Nim.Niminstance.binRectTransform,
            this.GetComponent<RectTransform>().position,
            null
        );
      
        
        if (IsOverlapping && !hasScoredThisDrag)
        {
            hasScoredThisDrag = true; 
                switch(Gamestatemanager.StatemanagerInstance.Nimstate)
                {
                    case Nimstate.round1:
                    Nim.Niminstance.Hadinim+=1;
                    if(Nim.Niminstance.HadinimR1 ==3)Nim.Niminstance.HadinimR1 =3;
                    break;
                    case Nimstate.round3:
                    Nim.Niminstance.Hadinim+=1;
                    if(Nim.Niminstance.HadinimR3 ==3)Nim.Niminstance.HadinimR3 =3;
                    break;
                    case Nimstate.round5:
                    Nim.Niminstance.Hadinim+=1;
                    if(Nim.Niminstance.HadinimR5 ==3)Nim.Niminstance.HadinimR5 =3;
                    break;
                    case Nimstate.round7:
                    Nim.Niminstance.Hadinim+=1;
                    if(Nim.Niminstance.HadinimR7 ==3)Nim.Niminstance.HadinimR7 =3;
                    break;
                    case Nimstate.round9:
                    Nim.Niminstance.Hadinim+=1;
                    if(Nim.Niminstance.HadinimR9 ==3)Nim.Niminstance.HadinimR9 =3;
                    break;
                    

                    default:
                    break;
                }

            if (Nim.Niminstance.Nimcollection.Contains(Nim.Niminstance.currentlyDraggedNim))
            {
                //Destroy(Nim.Niminstance.currentlyDraggedNim.gameObject);
                Nim.Niminstance.currentlyDraggedNim.gameObject.SetActive(false);

                Nim.Niminstance.Nimcollection2.RemoveAll(item => item == null);
                Nim.Niminstance.Nimcollection3.RemoveAll(item => item == null);
            }
           
        }
}    }


                    

                
            
        