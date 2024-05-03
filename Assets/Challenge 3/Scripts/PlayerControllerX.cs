﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge3
{
    public class PlayerControllerX : MonoBehaviour
    {
        public bool gameOver;

        public float floatForce;
        public float bouncForce;
        private float gravityModifier = 1.5f;
        private Rigidbody playerRb;
        public float upBound;

        public ParticleSystem explosionParticle;
        public ParticleSystem fireworksParticle;

        private AudioSource playerAudio;
        public AudioClip moneySound;
        public AudioClip explodeSound;


        // Start is called before the first frame update
        void Start()
        {
            Physics.gravity *= gravityModifier;
            playerAudio = GetComponent<AudioSource>();

            // Apply a small upward force at the start of the game
            playerRb = GetComponent<Rigidbody>();
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        }

        // Update is called once per frame
        void Update()
        {
            // While space is pressed and player is low enough, float up
            if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < upBound)
            {
                playerRb.AddForce(Vector3.up * floatForce);
            }

            if(transform.position.y > upBound)
            {
                playerRb.velocity = Vector3.zero;
                playerRb.AddForce(Vector3.down);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            // if player collides with bomb, explode and set gameOver to true
            if (other.gameObject.CompareTag("Bomb"))
            {
                explosionParticle.Play();
                playerAudio.PlayOneShot(explodeSound, 1.0f);
                gameOver = true;
                Debug.Log("Game Over!");
                Destroy(other.gameObject);
            }

            // if player collides with money, fireworks
            else if (other.gameObject.CompareTag("Money"))
            {
                fireworksParticle.Play();
                playerAudio.PlayOneShot(moneySound, 1.0f);
                Destroy(other.gameObject);

            }
            // if player collides with ground
            else if (other.gameObject.CompareTag("Ground"))
            {
                Debug.Log("Player Collider with Ground");
                playerRb.AddForce(Vector3.up * bouncForce);
            }

        }

    }
}