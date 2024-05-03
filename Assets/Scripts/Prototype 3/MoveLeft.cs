using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3
{
    public class MoveLeft : MonoBehaviour
    {
        public float speed;
        public float boundLeft;
        private PlayerController player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!player.isGameOver)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            if(transform.position.x < boundLeft && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}
