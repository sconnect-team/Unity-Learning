using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        public Animator playerAnim;
        public ParticleSystem smokeFx;
        public ParticleSystem dirtFx;
        public AudioClip crashClip;
        public AudioClip jumpClip;
        public float jumpForce;
        public float gravity;
        public ForceMode forceMode;
        public bool isGameOver;
        public bool isOnGround;
        private AudioSource myAudio;

        // Start is called before the first frame update
        void Start()
        {
            Physics.gravity *= gravity;
            myAudio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
            {
                rb.AddForce(Vector3.up * jumpForce, forceMode);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
                dirtFx.Stop();
                myAudio.PlayOneShot(jumpClip, 1);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"COllision with {collision.collider}");
            if (isGameOver) return;
            if (collision.collider.CompareTag("Obstacle"))
            {
                isGameOver = true;
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                smokeFx.Play();
                dirtFx.Stop();
                myAudio.PlayOneShot(crashClip, 1);
            }
            else if (collision.collider.CompareTag("Ground"))
            {
                isOnGround = true;
                dirtFx.Play();
            }
        }
    }
}
