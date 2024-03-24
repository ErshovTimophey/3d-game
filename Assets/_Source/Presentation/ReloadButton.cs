using UnityEngine;
using UnityEngine.SceneManagement;

namespace Presenation
{
    public class ReloadButton : MonoBehaviour
    {
        public void Press()
        {
            Timer.renew = true;
            Timer.elapsedTime = 0f;
            SceneManager.LoadScene(1);
        }
    }
}
