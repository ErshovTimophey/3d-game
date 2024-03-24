using UnityEngine;
using UnityEngine.SceneManagement;

namespace Presenation
{
    public class NewGameButton : MonoBehaviour
    {
        public void Press()
        {
            SceneManager.LoadScene(0);
        }
    }
}
