using Ink.Runtime;
using UnityEngine;
using Utility;

namespace Dialogue
{
    public class DialogueController : MonoBehaviour
    {
        public static DialogueController Instance { get; private set; }
        
        public Story Story;
        [SerializeField] private TextAsset inkFile;
        
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
            Story = new Story(inkFile.text);
        }
        
        public void SetStoryScene(int currentDialogueChapter)
        {
            switch (currentDialogueChapter)
            {
                case 1:
                    if (!GameManager.Instance.startScene)
                    {
                        Story.ChoosePathString("Prolog");
                        GameManager.Instance.startScene = true;
                    }
                    break;
                case 2:
                    if (!GameManager.Instance.startScene)
                    {
                        Story.ChoosePathString("StartChapter1");
                        GameManager.Instance.startScene = true;
                    }
                    else
                    {
                        if (GameManager.Instance.npcName == "Pelayan1")
                        {
                            Story.ChoosePathString("Pelayan1");
                        }
                        else if (GameManager.Instance.npcName == "Azmi")
                        {
                            Story.ChoosePathString("StoryChapter1");
                        }
                    }
                    
                    break;
                case 3:
                    if (!GameManager.Instance.startScene)
                    {
                        Story.ChoosePathString("StartChapter2");
                        GameManager.Instance.startScene = true;
                    }
                    else
                    {
                        
                    }
                    break;
                case 4:
                    if (!GameManager.Instance.startScene)
                    {
                        Story.ChoosePathString("StartChapter3");
                        GameManager.Instance.startScene = true;
                    }
                    else
                    {
                        
                    }
                    break;
                case 5:
                    if (!GameManager.Instance.startScene)
                    {
                        Story.ChoosePathString("StartChapter4");
                        GameManager.Instance.startScene = true;
                    }
                    else
                    {
                        
                    }
                    break;
                case 6:
                    if (!GameManager.Instance.startScene)
                    {
                        Story.ChoosePathString("StartChapter5");
                        GameManager.Instance.startScene = true;
                    }
                    else
                    {
                        
                    }
                    break;
            }
        }
    }
}
