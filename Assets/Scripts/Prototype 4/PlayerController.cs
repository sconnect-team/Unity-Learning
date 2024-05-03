using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        private Rigidbody playerRb;
        private GameObject focalPoint;

        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("Focal Point");
        }

        // Update is called once per frame
        void Update()
        {
       //     var xAxis = Input.GetAxis("Horizontal");
            var yAxis = Input.GetAxis("Vertical");

         //   playerRb.AddForce(Vector3.right * xAxis * speed);
          //  playerRb.AddForce(Vector3.forward * yAxis * speed);
            playerRb.AddForce(focalPoint.transform.forward * yAxis * speed);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                // End Game
            }
            else if (collision.collider.CompareTag("Powerup"))
            {
                collision.gameObject.SetActive(false);  
            }
        }
    }
}
