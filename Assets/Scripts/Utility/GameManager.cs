using UnityEngine;

namespace Utility
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public string npcName;
        public bool npcInteract;
        public bool dialogRun;
        public bool startScene;
        public bool endStory;
        public bool IsMinigame;


        public bool canMove;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            dialogRun = false;
            startScene = false;
            npcInteract = false;
            IsMinigame = false;
            
        }
    }
}
