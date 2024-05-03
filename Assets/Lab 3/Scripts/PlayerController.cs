using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab3
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float zBound;
        private Rigidbody playerRb;

        private void Start()
        {
            playerRb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            MovePlayer();
            ConstraintPlayer();
        }

        // Prevent Player move outside top or bottom of the screen
        private void ConstraintPlayer()
        {
            if (transform.position.z < -zBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
            }
            if (transform.position.z > zBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
            }
        }

        // Following the User input to Movement
        private void MovePlayer()
        {
            var xAxis = Input.GetAxis("Horizontal");
            var yAxis = Input.GetAxis("Vertical");

            playerRb.AddForce(Vector3.right * xAxis * speed);
            playerRb.AddForce(Vector3.forward * yAxis * speed);
        }
    }
}
