using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Cardbrain : MonoBehaviour
{
   
    public List<GameObject>Carddeck;
    public float offset;
    public List<GameObject>Shuffled;
    public List<GameObject>Comparecard = new List<GameObject>(3);
    public List<Color> Allowcolor = new List<Color>{Color.red,Color.blue,Color.green};
    public GameObject parenctplaceholder;
    public static Cardbrain instance;
    public int PlayerScore;
    private CardRgb cardSuper;
    public EventSystem eventSystem;
    public GraphicRaycaster uiRaycaster;
    private GameObject currentlyCard;
    private Camera camera;

    void Shuffledeck(List<GameObject> CardDeck)    
    {
        for(int i = CardDeck.Count - 1;i>0;i--)
        {
            int randomIndex = UnityEngine.Random.Range(0,i+1);
            GameObject temp = CardDeck[i];
            CardDeck[i] = CardDeck[randomIndex];
            CardDeck[randomIndex] = temp;
        }
    }  
    public void comparecard(List<GameObject> list)
    {  
        bool check =list[1].GetComponent<SpriteRenderer>().color ==list[2].GetComponent<SpriteRenderer>().color;
        String check2 = list[1].gameObject.transform.GetChild(0).gameObject.name;        
        Debug.Log(check2+"+++++++++++");

        if(list.Count ==3 && list.Count > 0 )
        {
            if(check == true)
            {
                PlayerScore+=1;
                list[2].transform.gameObject.SetActive(false);
                list[1].transform.gameObject.SetActive(false);
                list.RemoveAt(2);
                list.RemoveAt(1);
              

            } 
            else if (check == false)
            {
                GameObject card2 = list[2];
                GameObject card1 = list[1];
                list[2].transform.GetChild(0).GetComponent<Cardback>().flipped = false;
                list[1].transform.GetChild(0).GetComponent<Cardback>().flipped = false;
                // list.RemoveAt(2);
                // list.RemoveAt(1);
                list[2].gameObject.transform.GetChild(0).gameObject.transform.DORotate(new Vector3(0, 0, 0), 0.25f).OnComplete(() => list.RemoveAt(2));
                list[1].transform.GetChild(0).transform.DORotate(new Vector3(0, 0, 0), 0.25f).OnComplete(() => list.RemoveAt(1));
                return;
            }
        }
    }   	
    void Deletecard(List<GameObject> shuffledeck,List<GameObject> carddeck)
    {
        foreach (GameObject item in shuffledeck)
        {
            if(!item.activeSelf)
            {
                shuffledeck.Remove(item);
                carddeck.Remove(item);
                Destroy(item);
            }
        }
    }
     void RandomizeColor(List<GameObject> ShuffledDeck)
        {
           for (int i = 0; i < ShuffledDeck.Count - 1; i += 2)
            {
                SpriteRenderer card1 = ShuffledDeck[i].GetComponent<SpriteRenderer>();
                SpriteRenderer card2 = ShuffledDeck[i + 1].GetComponent<SpriteRenderer>();

                if (Allowcolor.Contains(card1.color) && Allowcolor.Contains(card2.color))
                {
                   return;
                }
                else if (!Allowcolor.Contains(card1.color) && !Allowcolor.Contains(card2.color))
                {
                    int random = UnityEngine.Random.Range(0, Allowcolor.Count);
                    card1.color = Allowcolor[random];
                    card2.color = Allowcolor[random];
                }
            }
        }
    private void Awake() {
        if(instance ==null) instance = this; else Destroy(instance);
    }
    private void Start() {
        camera = Camera.main;
        Shuffled = new List<GameObject>(Carddeck);
        Shuffledeck(Shuffled);
        RandomizeColor(Shuffled);
        // foreach (GameObject item in Shuffled)
        //     {
        //         cardSuper = item.GetComponent<CardRgb>();
        //         if(cardSuper!=null)
        //         {
                
        //         }
        //      }
    }
    void Update()
    {
        
        comparecard(Comparecard);
        parenctplaceholder.transform.position = new Vector3(camera.transform.position.x+1.67f,camera.transform.position.y+0.84f,0f);
     

       
      if(Gamestatemanager.StatemanagerInstance.CurrentGlobalState == Global.Isminigame )
      {
        if(PlayerScore == 6)
        {
            Deletecard(Shuffled,Carddeck);
        }
      }
    }
}
