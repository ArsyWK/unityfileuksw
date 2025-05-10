using System.Collections;
using UnityEngine;

namespace Utility
{
    public class TransitionController : MonoBehaviour
    {
        public Animator panelAnimator;
        public Animator textAnimator;

        private void Start()
        {
            panelAnimator = panelAnimator ?? GetComponent<Animator>();
            textAnimator = textAnimator ?? GetComponent<Animator>();
        }
        public void PlayCredit()
        {
            panelAnimator.SetTrigger("creditplay");
        }
        public void ResetCredit()
        {
            panelAnimator.SetTrigger("creditend");
        }
        public void PanelFadeIn()
        {
            panelAnimator.SetTrigger("fadein");
        }
        public void PanelFadeOut()
        {
            panelAnimator.SetTrigger("fadeout");
        }
        public void PrologStart()
        {
            panelAnimator.SetTrigger("prolog");
        }

        public IEnumerator PanelFade()
        {
            panelAnimator.SetTrigger("fadein");
            yield return new WaitForSeconds(2);
            panelAnimator.SetTrigger("fadeout");
        }
        public IEnumerator PlayTextChapter()
        {
            yield return new WaitForSeconds(2);
            textAnimator.SetTrigger("textout");
            yield return new WaitForSeconds(2);
            PanelFadeOut();
        }
    }
}