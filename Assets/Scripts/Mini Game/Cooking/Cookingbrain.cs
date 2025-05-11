using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using UnityEngine.UI;

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
    int  index = 0;

    int A=1;
    int D=2;
    int Space=3;
    public Sprite Apress;
    public Sprite Dpress;
    public Sprite Spress;

    bool Timedout;
    public static Cookingbrain instance;
    [SerializeField]private List<GameObject> instanced;
    bool runround ;
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
    void deleter(List<int> placeholder2)
    {
        for (int i = 0; i < 5; i++)
        {
            placeholder2.Clear();
        }
    }
    void comparerequest(List<int> placeholder)
    {   
        Debug.Log("index"+index+"+++");
        if(index >= 5) index = 0;
        if(state == cookingstate.isPlaying)
        {
        if(placeholder.Count>3) 
        {
            Debug.Log(index+"++++++++");
            int input = valbutton[0];
            if(placeholder[index] == input)
            {
                Transform target = instanced[index].transform;               
                target.DOScale(1.4f, 0.10f).SetEase(Ease.OutBack)
                    .OnComplete(() =>
                    {
                            //instanced[index].transform.GetComponent<ButtonCooking>().isWrong = true;
                        if(placeholder[index] == 1)instanced[index].GetComponent<Image>().sprite = Apress;
                        else if(placeholder[index] == 2) instanced[index].GetComponent<Image>().sprite = Dpress;
                        else if(placeholder[index] == 3) instanced[index].GetComponent<Image>().sprite = Spress;
                         DOTween.Sequence()
                        .AppendInterval(0.1f) 
                        .AppendCallback(() =>
                        {
                            instanced[index].transform.localScale = target.transform.localScale;
                            instanced[index].gameObject.SetActive(false);
                            index ++;
                        });
                    });
                    valbutton.RemoveAt(0);
            }
            else 
            {
                Vector3 oldpos = instanced[index].gameObject.transform.localPosition;
                instanced[index].gameObject.transform.DOShakePosition(0.15f, strength: new Vector3(80f, 0f, 0f), vibrato: 40, randomness: 0) .OnComplete(() => 
                {
                    // instanced[index].GetComponent<ButtonCooking>().isWrong = true;
                    instanced[index].gameObject.transform.localPosition = oldpos;
                });
                valbutton.RemoveAt(0);

            }
                    //ButtonSprite[index].GetComponent<ButtonCooking>().isWrong = false;
          }
        }
    }
     void Shufflerequest(List<int> placholder)    
    {   
        if(placholder.Count<5)
        {   for(int i = 0 ;i<5;i++)
            {
                placholder.Add(UnityEngine.Random.Range(1,4));
            }
        }
    }  

    void Spriteplacement(List<GameObject> placeholder)
    {
        GameObject A;
        GameObject D;
        GameObject Space;
        
      if(instanced.Count<5)
      {
        for (int i = 0; i < 5; i++)
        {
            if(requestedset[i] == 1)
            {
                A = Instantiate(placeholder[0],Spawner[i].transform.position,Quaternion.identity,buttonparent.transform);
                A.GetComponent<RectTransform>().localScale = new Vector3(1.5f,1.5f,1.5f);
                instanced.Add(A);
                Spawner[i].SetActive(false);

            }
            else if(requestedset[i] == 2)
            {
                D = Instantiate(placeholder[1],Spawner[i].transform.position,Quaternion.identity,buttonparent.transform);
                D.GetComponent<RectTransform>().localScale = new Vector3(1.5f,1.5f,1.5f);
                instanced.Add(D);
                Spawner[i].SetActive(false);

            }
            else if(requestedset[i] == 3)
            {
                Space = Instantiate(placeholder[2],Spawner[i].transform.position,Quaternion.identity,buttonparent.transform);
                Space.GetComponent<RectTransform>().localScale = new Vector3(1.5f,1.5f,1.5f);
                instanced.Add(Space);
                Spawner[i].SetActive(false);
            }
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
            if(runround == false)
            {
                Shufflerequest(requestedset);
                Spriteplacement(ButtonSprite);
                runround =true;
            }
            if(instanced.All(item => !item.activeSelf))
            {
                instanced.Clear();
                deleter(requestedset);
                roundstate +=1;
                runround = false;
            }
            break;
            default:
            break;
        }
    }

    private void Start() 
    {       roundstate = round.round1;
            state = cookingstate.isPlaying;
            runround =false;
            

        if(Gamestatemanager.StatemanagerInstance.CurrentGlobalState == Global.Isminigame && state == cookingstate.isPlaying)
        {

        }
    }
    void Update()
    {       
            Debug.Log("round"+"+++++"+roundstate);
            fiveset();
            comparerequest(requestedset);

    }
    private void Awake() {
        if(instance ==null)instance = this; else Destroy(instance);
    }
}
