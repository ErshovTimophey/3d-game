using UnityEngine;
using Core;

namespace Presenation
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] GameObject obstacles;
        [SerializeField] GameObject player;
        [SerializeField] PlayerCont playerCont;
        [SerializeField] GameObject collectionItem;

        public void NewLevel()
        {
            player.transform.position = new Vector3(-5.310f, 1.96f, -8.650f);
            playerCont.button.gameObject.SetActive(false);
            playerCont.score = 0;
            playerCont.scoreText.text = "Score: " + playerCont.score;
            obstacles.SetActive(true);
            
            for (int i = 0; i < 5; ++i) 
            {    
                float x;
                float z;
                while(true)
                {
                    bool isCorrect = true;
                    x = RandomNumberX();
                    z = RandomNumberZ();  

                    if (x >= -0.14f && x <= 1.74f && z >= -6.67f && z <= -3.83f)
                    {
                        isCorrect = false;
                    }

                    if (x <= -0.85f && x >= -2.25f && z <= -11.72f && z >= -14.55f)
                    {
                        isCorrect = false;
                    }

                    if (x >= -4.44f && x <= -2.33f && z >= -8.28f)
                    {
                        isCorrect = false;
                    }

                    if (x >= -9.2f && x <= -7.67f && z >= -15.49f && z <= -12.8f)
                    {
                        isCorrect = false;
                    }

                    if (x >= -12.43f && x <= -10.75f && z >= -6.05f && z <= -3.39f)
                    {
                        isCorrect = false;
                    }

                    if (isCorrect)
                    {
                        break;
                    }
                }
                Instantiate(
                    collectionItem,
                    new Vector3(x, 1.6f, z),
                    Quaternion.Euler(0, 0, 0)
                );  
            }
        }

        private float RandomNumberX() 
        {
            return Random.Range(-12.3f,3.2f);
        }

        private float RandomNumberZ() 
        {
            return Random.Range(-17.3f,-1.1f);
        }
    }
}
