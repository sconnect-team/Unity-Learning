using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Protoype2
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float xRange;
        public GameObject projecttilePrefab;
        private float horizontalAxis;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            horizontalAxis = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalAxis);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projecttilePrefab, transform.position, projecttilePrefab.transform.rotation);
            }
        }
    }
}