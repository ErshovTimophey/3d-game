using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

namespace Presenation
{
    public class TextHandler : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;

        public void Start() 
        {
            float bestTime = 0f;
            try
            {
                if (File.Exists(@"File.txt"))
                {
                    Stream stream;
                    stream = new FileStream(
                        @"File.txt",
                        FileMode.Open, 
                        FileAccess.ReadWrite, 
                        FileShare.None
                    );
                    IFormatter formatter = new BinaryFormatter();
                    SerializeData serializeData = new();
                    serializeData = formatter.Deserialize(stream) as SerializeData;
                    bestTime = serializeData.bestTime;
                    int minutes = Mathf.FloorToInt(bestTime / 60);
                    int seconds = Mathf.FloorToInt(bestTime % 60);
                    scoreText.text = string.Format("Best result: {0:00}:{1:00}", minutes, seconds);
                    stream.Close();
                }
            }
            catch{}
        }
    }
}
