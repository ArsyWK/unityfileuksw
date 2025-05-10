using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using Main_Menu;
using Mini_Game.Nim;

public class Nim : MonoBehaviour
{
    
    public GameObject currentlyDraggedNim;

    [SerializeField]public List<GameObject> Nimcollection;    
    [SerializeField]public List<GameObject> Nimcollection2;  
    [SerializeField]public List<GameObject> Nimcollection3;  
     [HideInInspector]public int HadinimR1;
     [HideInInspector]public int HadinimR3;
     [HideInInspector]public int HadinimR5;
     [HideInInspector]public int HadinimR7;
     [HideInInspector]public int HadinimR9;
     [HideInInspector]public int HadinimR11;
     [SerializeField]public int Hadinim =0;
     [SerializeField]private int Azminim  = 0;
     bool isSecondRunning = false;
    bool round2debonce = false;
    bool hadiTurn = true;
    public Canvas canvas1;
     public RectTransform binRectTransform;
    public GameObject Bin;
    public static Nim Niminstance;
    [HideInInspector]public GameObject Table;
    private UnityEngine.Camera mainCamera;
    public float grabDistance = 10f;   
    public GraphicRaycaster uiRaycaster;    
    [HideInInspector] public EventSystem eventSystem; 
    

    IEnumerator Second()
    {
   
    if (isSecondRunning)
        yield break;

    isSecondRunning = true;
    yield return new WaitForSeconds(3);

    if (hadiTurn == false && round2debonce == false)
    {
        

        if (Hadinim == 1)
        {
            Debug.Log("case1");
            Hadinim = 0;
            Azminim += 3;
            Destroy( Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)]);
            Destroy( Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)]);
            Destroy( Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)]);
            // Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)].SetActive(false);
            // Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)].SetActive(false);
            // Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)].SetActive(false);



            if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round4 && hadiTurn == false)
            {
               
                hadiTurn = true;
                round2debonce = true;
                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round5;
            }
            else if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round2 && hadiTurn == false)
            {
                
                hadiTurn = true;
                round2debonce = true;

                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round3;
            }
            else if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round6 && hadiTurn == false)
            {
                hadiTurn = true;
                round2debonce = true;
                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round7;
            }
            else if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round8 && hadiTurn == false)
            {
                hadiTurn = true;
                round2debonce = true;
                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round9;
            }

            
        }
        else if (Hadinim == 2)
        {
            Debug.Log("case2");

            Azminim += 2;
            Hadinim = 0;
             Destroy( Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)]);
             Destroy( Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)]);
            // Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)].SetActive(false);
            // Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)].SetActive(false);

            

            
            if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round2 && hadiTurn == false)
            {
                hadiTurn = true;
                round2debonce = true;
                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round3;
            }
            else if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round4 && hadiTurn == false)
            {
                hadiTurn = true;
                round2debonce = true;
                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round5;
            }
            else if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round6 && hadiTurn == false)
            {
                hadiTurn = true;
                round2debonce = true;
                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round7;
            }
            else if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round8 && hadiTurn == false)
            {
                hadiTurn = true;
                round2debonce = true;
                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round9;
            }
        }
        else if (Hadinim == 3)
        {
            Debug.Log("case3");

            Azminim += 1;
            Hadinim = 0;

            Destroy( Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)]);
            // Nimcollection3[UnityEngine.Random.Range(0, Nimcollection3.Count)].SetActive(false);

           
    
            if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round4 && hadiTurn == false)
            {
                hadiTurn = true;
                round2debonce = true;
                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round5;
            }
            else if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round2 && hadiTurn == false)
            {
                hadiTurn = true;
                round2debonce = true;
                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round3;
            }
            else if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round6 && hadiTurn == false)
            {
                hadiTurn = true;
                round2debonce = true;
                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round7;
            }
            else if (Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round8 && hadiTurn == false)
            {
                hadiTurn = true;
                round2debonce = true;
                Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round9;
            }
        }
    }

    isSecondRunning = false;
    yield break;
}      
    private void OnEnable() 
    {
        
    }
    void Awake()
    {
        if(Niminstance==null)
        {
            Niminstance= this;
        }else Destroy(Niminstance);
        this.AddComponent<BoxCollider2D>();
        this.GetComponent<BoxCollider2D>().isTrigger = true;
        canvas1.gameObject.SetActive(false);
        

    }
    void Start()
    {
        mainCamera = UnityEngine.Camera.main;
       
       
    }
    void Update()
    {
       Nimcollection3 = Nimcollection2.Where(obj => obj != null).ToList();
       if(ExitButton.exitButtoninstance.buttonpressed == true)
       { canvas1.gameObject.SetActive(false);
        ExitButton.exitButtoninstance.buttonpressed = false;
        Gamestatemanager.StatemanagerInstance.CurrentGlobalState =Global.Isgameplay;}
        
       
        Player2GetNim();
    }
void Player2GetNim()
{
    if (Nimcollection3.Count == 1 || Nimcollection3.Count == 3 && !hadiTurn)
        {
        canvas1.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        Gamestatemanager.StatemanagerInstance.CurrentGlobalState = Global.Isgameplay;
        }
   
    if( Hadinim ==3||Hadinim ==0)  MainButtonNim.buttoninstance.gameObject.GetComponent<Button>().enabled = false;
    else MainButtonNim.buttoninstance.gameObject.GetComponent<Button>().enabled = true;
      
    switch (Gamestatemanager.StatemanagerInstance.Nimstate)
    {
        case Nimstate.round1:
         if (hadiTurn&& Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round1)
            {
                Debug.Log("Player (Hadi) Turn - Round: " + Gamestatemanager.StatemanagerInstance.Nimstate);
                NimChecker();
                if (MainButtonNim.buttoninstance.buttonpressed == true|| Hadinim %3 ==0 && Hadinim>0)
                {   
                    MainButtonNim.buttoninstance.buttonpressed = false;
                    Gamestatemanager.StatemanagerInstance.Nimstate += 1;
                    hadiTurn = false;
                    round2debonce = false;
                }
            }
            break;
        case Nimstate.round3:
         if (hadiTurn&& Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round3)
            {
                Debug.Log("Player (Hadi) Turn - Round: " + Gamestatemanager.StatemanagerInstance.Nimstate);
                NimChecker();
                if (MainButtonNim.buttoninstance.buttonpressed == true || Hadinim %3 ==0 && Hadinim>0)
                {
                     MainButtonNim.buttoninstance.buttonpressed = false;
                    Gamestatemanager.StatemanagerInstance.Nimstate += 1;
                    hadiTurn = false;
                    round2debonce = false;
                }
            }
            break;
        case Nimstate.round5:
             if (hadiTurn&& Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round5)
            {
                Debug.Log("Player (Hadi) Turn - Round: " + Gamestatemanager.StatemanagerInstance.Nimstate);
                NimChecker();
                if (MainButtonNim.buttoninstance.buttonpressed == true || Hadinim %3 ==0 && Hadinim>0)
                {
                     MainButtonNim.buttoninstance.buttonpressed = false;
                    Gamestatemanager.StatemanagerInstance.Nimstate += 1;
                    hadiTurn = false;
                    round2debonce = false;

                }
            }
            break;
        case Nimstate.round7:
             if (hadiTurn&& Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round7)
            {
                Debug.Log("Player (Hadi) Turn - Round: " + Gamestatemanager.StatemanagerInstance.Nimstate);
                NimChecker();
                if (MainButtonNim.buttoninstance.buttonpressed == true || Hadinim %3 ==0 && Hadinim>0)
                {
                     MainButtonNim.buttoninstance.buttonpressed = false;
                    Gamestatemanager.StatemanagerInstance.Nimstate = Nimstate.round8;
                    hadiTurn = false;
                    round2debonce = false;
                }
            }
            break;
        case Nimstate.round9:
             if (hadiTurn&& Gamestatemanager.StatemanagerInstance.Nimstate == Nimstate.round9)
            {
                Debug.Log("Player (Hadi) Turn - Round: " + Gamestatemanager.StatemanagerInstance.Nimstate);
                NimChecker();
                if (MainButtonNim.buttoninstance.buttonpressed == true || Hadinim %3 ==0 && Hadinim>0)
                {
                     MainButtonNim.buttoninstance.buttonpressed = false;

                    Gamestatemanager.StatemanagerInstance.Nimstate += 1;
        
                    hadiTurn = false;
                    round2debonce = false;
                }
            }
            break;
           

        case Nimstate.round2:
        case Nimstate.round4:
        case Nimstate.round6:
        case Nimstate.round8:

            if (!hadiTurn)
            {
                MainButtonNim.buttoninstance.gameObject.GetComponent<Button>().enabled = false;
                Debug.Log("NPC Turn - Round: " + Gamestatemanager.StatemanagerInstance.Nimstate);
                StartCoroutine(Second());

            }
            break;
    }
}
    void NimChecker()
    {
        // if(Gamestatemanager.StatemanagerInstance.CurrentGlobalState == Global.Isminigame)
        // {
            
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                TryGrabObject();
            }

            if (Mouse.current.leftButton.isPressed && Nimcollection != null)
            {
                DragObject();
            }

            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                ReleaseObject();
            }
       //}
    }
    GameObject grabbedObject;
    void TryGrabObject()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = mouseScreenPos
        };
          if (uiRaycaster == null)
            {
                Debug.LogError("Error on graphicRaycasterCanvas");
                return;
            }


         List<RaycastResult> results = new List<RaycastResult>();
    uiRaycaster.Raycast(pointerData, results);

    foreach (RaycastResult result in results)
    {
        GameObject hitUI = result.gameObject;

        if (hitUI.CompareTag("nim") && Nimcollection.Contains(hitUI))
        {
            currentlyDraggedNim = hitUI;
            Rigidbody2D rb = hitUI.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true;
                Debug.Log("Grabbed: " + hitUI.name);
            }

            break; 
        }
    }
    }

    void DragObject()
{
    if (currentlyDraggedNim == null) return;

    Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
    Vector3 targetPosition = mainCamera.ScreenToWorldPoint(
        new Vector3(mouseScreenPos.x, mouseScreenPos.y, grabDistance)
    );

    RectTransform rectTransform = currentlyDraggedNim.GetComponent<RectTransform>();
    Canvas canvas = currentlyDraggedNim.GetComponentInParent<Canvas>();

    if (canvas != null && rectTransform != null)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            mouseScreenPos,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
            out localPoint
        );

        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, localPoint, Time.deltaTime * 10f);
    }
}


  void ReleaseObject()
{
    if (currentlyDraggedNim != null)
    {
        Rigidbody2D rb = currentlyDraggedNim.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }        
        currentlyDraggedNim = null;
    }
}


}



