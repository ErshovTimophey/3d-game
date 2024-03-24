using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Presenation;

namespace Core
{
    public class PlayerCont : MonoBehaviour
    {
        public float speed = 5f;
        private Rigidbody rb;
        public Text scoreText;
        public int score = 0;
        public Button button;
        public Button buttonReload;
        int levelCounter = 0;
        [SerializeField] public float resultTime = 0;

        private void Awake() 
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() 
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical") ;
            rb.AddForce(speed * Time.fixedDeltaTime * new Vector3(-v, 1, h));
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.CompareTag("CollectiveCube")) 
            {
                ++score;
                Destroy(other.gameObject);
                if (score != 5)
                {
                    scoreText.text = "Score: " + score;
                }
                else 
                {
                    scoreText.text = "You win!";
                    ++levelCounter;
                    if (levelCounter != 3)
                    {
                        button.gameObject.SetActive(true);
                    }
                    else
                    {   
                        Timer timer = new();
                        resultTime = timer.GetResultTime();
                        float bestTime = 10000000000000f;
                        SerializeData serializeData = new();
                        try
                        {
                            Stream stream;
                            stream = new FileStream(
                                @"File.txt",
                                FileMode.Open, 
                                FileAccess.Read, 
                                FileShare.None
                            );
                            IFormatter formatter = new BinaryFormatter();
                            serializeData = formatter.Deserialize(stream) as SerializeData;
                            bestTime = serializeData.bestTime;
                            stream.Close();
                        }
                        catch{}
                        if (resultTime < bestTime)
                        {
                            serializeData.bestTime = resultTime;
                            Stream stream;
                            stream = new FileStream(
                                @"File.txt",
                                FileMode.Create, 
                                FileAccess.ReadWrite, 
                                FileShare.None
                            );
                            IFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(stream, serializeData);
                            stream.Close();
                            int minutes = Mathf.FloorToInt(resultTime / 60);
                            int seconds = Mathf.FloorToInt(resultTime % 60);
                            scoreText.text = string.Format("Best result: {0:00}:{1:00}", minutes, seconds);
                        }
                        buttonReload.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
