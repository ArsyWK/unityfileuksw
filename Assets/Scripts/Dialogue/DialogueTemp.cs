using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dialogue
{
    public class DialogueTemp : MonoBehaviour
    {
        [TextArea] public List<string> sentence;
        private int _lineIndex;
        
        private TMP_Text _text;
        private CanvasGroup _canvasGroup;
        private bool _started;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            _canvasGroup = GetComponentInParent<CanvasGroup>();
            _canvasGroup.alpha = 0;
            _lineIndex = 0;
        }

        private void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (!_started)
                {
                    _text.SetText(sentence[_lineIndex]);
                    _canvasGroup.alpha = 1;
                    _started = true;
                }
                else if(_lineIndex< sentence.Count )
                {
                    _text.SetText(sentence[_lineIndex++]);
                }
                else _canvasGroup.alpha = 0;
            }
        }
    }
}
