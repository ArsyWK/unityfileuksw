using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Utility;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public TextMeshProUGUI dialogueText;
        public float textSpeed;
        private Coroutine _typingCoroutine;
        private string _currentLine;
        private bool _isTyping;
        private SceneController _scene;
        private List<string> _currentTags;
        private bool _isTalk;
        
        private TextMeshProUGUI _spawnBubble;
        private TextMeshProUGUI _talkText;
        public GameObject[] chara;
        public GameObject dialogueBubble;
        
        
        private void Start()
        {
            _spawnBubble = dialogueBubble.GetComponent<TextMeshProUGUI>();
            _talkText = dialogueBubble.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            _isTalk = false;
            _scene = GetComponentInParent<SceneController>();
            if (_scene.CurrentScene() == 1)
            {
                DialogueController.Instance.SetStoryScene(_scene.CurrentScene());
                StartCoroutine(Prolog());
            }
            else
            {
                DialogueController.Instance.SetStoryScene(_scene.CurrentScene());
                StartCoroutine(StartStory());
            }
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isTyping)
                {
                    StopCoroutine(_typingCoroutine);
                    _spawnBubble.text = _currentLine;
                    _talkText.text = _currentLine;
                    _isTyping = false;
                }
                else if (DialogueController.Instance.Story.canContinue)
                {
                    ContinueStory();
                }
                else if (!DialogueController.Instance.Story.canContinue && !GameManager.Instance.npcInteract)
                {
                    if (_scene.CurrentScene() == 1)
                    {
                        AudioController.Instance.StopMusic();
                        _scene.NextScene();
                    }
                    _spawnBubble.text = "";
                    _talkText.text = "";
                }
            }

            if (GameManager.Instance.npcInteract && !_isTalk)
            {
                DialogueController.Instance.SetStoryScene(_scene.CurrentScene());
                ContinueStory();
                _isTalk = true;
            }
        }

        void ContinueStory()
        {
            if (DialogueController.Instance.Story.canContinue)
            {
                _currentLine = DialogueController.Instance.Story.Continue().Trim();
                _currentTags = DialogueController.Instance.Story.currentTags;
                
                _spawnBubble.text = _currentLine;
                UpdateSizeBubble();
                _typingCoroutine = StartCoroutine(TypeText(_currentLine));
                CheckTags();
            }
        }

        private void UpdateSizeBubble()
        {
            var layoutElement = _spawnBubble.GetComponent<LayoutElement>();
            _spawnBubble.ForceMeshUpdate();
            Vector2 textSize = _spawnBubble.GetPreferredValues(_spawnBubble.text, 500f, 0f);
            float clampedWidth = Mathf.Min(textSize.x+0.5f, 500f);
            
            layoutElement.preferredWidth = clampedWidth;
        }

        private void CheckTags()
        {
            foreach (string t in _currentTags)
            {
                if (t == "endinteract")
                {
                    GameManager.Instance.npcInteract = false;
                    GameManager.Instance.dialogRun = false;
                    _isTalk = false;
                }
                foreach (GameObject c in chara)
                {
                    if (c.name == t)
                    {
                        if (Camera.main != null)
                        {
                            Vector3 worldPos = c.transform.position + new Vector3(0,1.25f,0);
                            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
                            _spawnBubble.transform.position = screenPos;
                        }
                    }
                }
            }
        }
        
        private IEnumerator TypeText(string text)
        {
            _isTyping = true;
            _talkText.text = "";
            foreach (char c in text)
            {
                _talkText.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            _isTyping = false;
        }

        private IEnumerator Prolog()
        {
            yield return new WaitForSeconds(3);
            _isTyping = false;
            if (_scene.CurrentScene() == 1)
            {
                AudioController.Instance.PlaySadMusic();
            }
            ContinueStory();
        }

        private IEnumerator StartStory()
        {
            GameManager.Instance.dialogRun = true;
            yield return new WaitForSeconds(5);
            _isTyping = false;
            ContinueStory();
        }
    }
}
