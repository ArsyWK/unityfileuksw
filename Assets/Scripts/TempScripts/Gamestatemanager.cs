using Unity.VisualScripting;
using UnityEngine;
public class Gamestatemanager : MonoBehaviour
{
    public static Gamestatemanager StatemanagerInstance {get; set;}
    public Playerstate CurrentPlayerState { get; set; }
    public Global CurrentGlobalState { get; set; }
    public InteractableState CurrentInteractableState { get; set; }
    public Nimstate Nimstate{get;set;}
     void Awake()
    {
        if (StatemanagerInstance == null)
        {
            StatemanagerInstance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
        CurrentPlayerState = Playerstate.none;
        CurrentGlobalState = Global.Isgameplay;
        Nimstate = Nimstate.round1;
        

 
    }
}
