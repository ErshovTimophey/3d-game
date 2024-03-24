using UnityEngine;

namespace Core
{
    public class ObjectsCreation : MonoBehaviour
    {
        public GameObject obj;
        private void Start() 
        {
            for (int i = 0; i < 5; ++i) 
            { 
                Instantiate(
                    obj,
                    new Vector3(RandomNumberX(), 1.6f, RandomNumberZ()),
                    Quaternion.Euler(0,0,0)
                );
            }
        }

        private float RandomNumberX() 
        {
            return UnityEngine.Random.Range(-12.3f, 3.2f);
        }

        private float RandomNumberZ() 
        {
            return UnityEngine.Random.Range(-17.3f, -1.1f);
        }
    }
}
