using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.LeinadDH.ChessDefense
{
    public class ReloadScene : MonoBehaviour
    { 
        public void LoadScene()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}