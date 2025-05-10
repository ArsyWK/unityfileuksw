using UnityEngine;
using Utility;

namespace TempScripts
{
    public class ButtonTemp : MonoBehaviour
    {
        public void Pelayan1()
        {
            GameManager.Instance.npcName = "Pelayan1";
            GameManager.Instance.npcInteract = true;
        }

        public void Story()
        {
            GameManager.Instance.npcName = "Azmi";
            GameManager.Instance.npcInteract = true;
        }
    }
}
