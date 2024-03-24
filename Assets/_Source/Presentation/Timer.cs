using UnityEngine;
using TMPro;

namespace Presenation
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timerText;
        public static float elapsedTime = 0f;
        public static bool renew = true;
        void Update()
        {   
            if (renew)
            {
                elapsedTime += Time.deltaTime;
                int minutes = Mathf.FloorToInt(elapsedTime / 60);
                int seconds = Mathf.FloorToInt(elapsedTime % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }

        public float GetResultTime() 
        {
            renew = false;
            return elapsedTime;
        }
    }
}
