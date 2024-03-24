using UnityEngine;

namespace Core
{
    public class NewBehaviourScript : MonoBehaviour
    {
            public float speed = 5f;
            public float hSpeed = 10f;
            public float thrust = 500f;
            private Rigidbody rb;

            private void Awake() 
            {
                rb = GetComponent<Rigidbody>();
            }

            private void FixedUpdate() 
            {
                float h = Input.GetAxis("Horizontal") * hSpeed * Time.fixedDeltaTime;
                float v = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
                rb.velocity = transform.TransformDirection(new Vector3(v, rb.velocity.y, -h));
            }

            private void OnCollisionEnter(Collision other)
            {
                if (other.gameObject.name == "Block") 
                {
                    rb.AddForce(new Vector3(0, 0, -1) * thrust);
                }
            }

            private void OnTriggerEnter(Collider other) 
            {
                if (other.gameObject.name == "Trigger") 
                {
                    Debug.Log("Trigger enter");
                }
            }

            private void OnTriggerStay(Collider other) 
            {
                if (other.gameObject.name == "Trigger") 
                {
                    Debug.Log("Trigger stay");
                }
            }

            private void OnTriggerExit(Collider other)
             {
                if (other.gameObject.name == "Trigger") 
                {
                    Destroy(gameObject);
                }
            }
        }
}
