using System;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Utility
{
    public class SceneController : MonoBehaviour
    {
        private TransitionController _transition;

        private void Awake()
        {
            _transition = GetComponent<TransitionController>();
        }

        private void Start()
        {
            
            if (CurrentScene()!=0)
            {
                StartCoroutine(_transition.PlayTextChapter());
            }
        }

        public void NextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public int CurrentScene()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }
}
