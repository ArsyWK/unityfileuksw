using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;

namespace Main_Menu
{
    public class MainButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        public GameObject[] obj;
        public GameObject text;
        public GameObject credit;
        public void PlayGame()
        {
            AudioController.Instance.PlayButton();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void PlayCredit()
        {
            StartCoroutine(Credit());
        }

        public void ExitGame()
        {
            Application.Quit();
        }
        
        private IEnumerator Credit()
        {
            text.GetComponent<TextMeshProUGUI>().color = Color.clear;
            foreach (GameObject parent in obj)
            {
                parent.GetComponent<Image>().enabled = false;
                parent.GetComponent<Button>().interactable = false;
                foreach (Transform child in parent.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            credit.GetComponent<Animator>().SetTrigger("creditplay");
            yield return new WaitForSeconds(10);
            foreach (GameObject parent in obj)
            {
                parent.GetComponent<Image>().enabled = true;
                parent.GetComponent<Button>().interactable = true;
                foreach (Transform child in parent.transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
            text.GetComponent<TextMeshProUGUI>().color = Color.white;
            credit.GetComponent<Animator>().SetTrigger("creditend");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            AudioController.Instance.HoverButton();
            Image buttonImage = eventData.pointerEnter.GetComponentInParent<Button>().GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = new Color32(255,255,255,100);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Image buttonImage = eventData.pointerEnter.GetComponentInParent<Button>().GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = new Color32(255,255,255,0);
            }
        }
    }

}
