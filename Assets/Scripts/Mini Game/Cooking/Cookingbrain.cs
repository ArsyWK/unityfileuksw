using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cookingbrain : MonoBehaviour
{
    public enum cookingstate
    {
        isTutorial,isDone,isPlaying
    }
    public enum round{round1,round2,round3,round4,round5}
    public cookingstate state;
    public List<int>valbutton;
    [SerializeField]private round roundstate;
    int A=1;
    int D=2;
    int Space=3;
    bool Timedout;
    public static Cookingbrain instance;
    private GameObject tutorialmenu;
    public GameObject progressbar;
    public List<GameObject> ButtonSprite;
    public List<GameObject> Spawner;
    public GameObject buttonparent;
    public List<int> requestedset;


    
        // if(state == cookingstate.isTutorial)
        // {
        //     tutorialmenu.SetActive(true);
        //     // if(Exitbuttonpressed == true)
        //     // {
        //     //     tutorialmenu.SetActive(false);
        //     //     state = cookingstate.isPlaying;
        //     // }
        // }else if (state == cookingstate.isPlaying)
        // {
        //     progressbar.SetActive(true);
            

        // }

    IEnumerator Waiting()
    {
      Timedout = false;
      yield return new  WaitForSeconds (4);
      Timedout = true;
    }
    void deleter(List<int> placeholder,List<int> placeholder2)
    {
        for (int i = 0; i < 6; i++)
        {
            placeholder.RemoveAt(i);
            placeholder2.RemoveAt(i);
        }
    }

    void comparerequest(List<int> placeholder)
    {   
        if(state == cookingstate.isPlaying)
        {
            if(requestedset.Count == 0 || Timedout == true)
            {
                roundstate +=1;
                Timedout =false;
            }
            if(valbutton.Count != 5) 
            {
                StartCoroutine(Waiting());
                for (int i = 0; i < 6; i++)
                {
                int  index = i;
                    if(placeholder[i] ==valbutton[i])
                    {
                        ButtonSprite[i].gameObject.SetActive(false);
                        placeholder.RemoveAt(i);
                    }
                    else 
                    {
                        
                        ButtonSprite[index].gameObject.transform.DORotate(new Vector3 (0f,180,0f),0.25f).OnComplete(()=>ButtonSprite[index].GetComponent<ButtonCooking>().isWrong = true);
                    }
                    ButtonSprite[index].GetComponent<ButtonCooking>().isWrong = true;
                }
            }
        }
    }
     void Shufflerequest(List<int> placholder)    
    {
        for(int i = 0 ;i<6;i++)
        {
            placholder.Add(UnityEngine.Random.Range(1,6));
        }
    }  

    void Spriteplacement(List<GameObject> placeholder)
    {
        GameObject A;
        GameObject D;
        GameObject Space;

        for (int i = 0; i < 6; i++)
        {
            if(requestedset[i] == 1)
            {
                A = Instantiate(placeholder[0],Spawner[i].transform.position,Quaternion.identity,buttonparent.transform);
            }
            else if(requestedset[i] == 2)
            {
                D = Instantiate(placeholder[1],Spawner[i].transform.position,Quaternion.identity,buttonparent.transform);
            }
            else if(requestedset[i] == 3)
            {
                Space = Instantiate(placeholder[2],Spawner[i].transform.position,Quaternion.identity,buttonparent.transform);
            }
        }
    }
   
    void fiveset()
    {
         switch (roundstate)
        {
            case round.round1:
            case round.round2:
            case round.round3:
            case round.round4:
            Shufflerequest(requestedset);
            Spriteplacement(ButtonSprite);
            comparerequest(requestedset);
            deleter(valbutton,requestedset);
            roundstate +=1;
            break;
            default:
            break;
        }
    }
    private void Start() 
    {       roundstate = round.round1;
            state = cookingstate.isPlaying;

            comparerequest(requestedset);
        if(Gamestatemanager.StatemanagerInstance.CurrentGlobalState == Global.Isminigame && state == cookingstate.isPlaying)
        {
            Shufflerequest(requestedset);
            // comparerequest();

            

            

        }
    }
    private void Awake() {
        if(instance ==null)instance = this; else Destroy(instance);
    }
}
