using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable: MonoBehaviour
{
    private bool isPlayerInRange;
    Interaction interaction;
    private void Awake() {
        this.AddComponent<BoxCollider2D>();
        this.GetComponent<BoxCollider2D>().size = new Vector2(8f,1.5f);
        this.GetComponent<BoxCollider2D>().isTrigger = true;
        
    }
    void Update()
    {
        if(isPlayerInRange== true && interaction.interactAction.action.triggered)
        {
            Gamestatemanager.StatemanagerInstance.CurrentGlobalState = Global.Isminigame;
            Nim.Niminstance.canvas1.gameObject.SetActive(true);
            
            
        }
    }
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Gamestatemanager.StatemanagerInstance.CurrentGlobalState = Global.Isgameplay;
            isPlayerInRange = false;
            Nim.Niminstance.canvas1.gameObject.SetActive(false);
          
        }
    }
    

}
