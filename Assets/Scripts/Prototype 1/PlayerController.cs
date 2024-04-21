using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Protoype1
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float velocity;
        [SerializeField] Camera myCamera;
        [SerializeField] float turnSpeed;

        private Vector3 cameraOffset;
        private float horzontalSpeed;
        private float verticalSpeed;

        // Start is called before the first frame update
        void Start()
        {
            cameraOffset = myCamera.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            horzontalSpeed = Input.GetAxis("Horizontal");
            verticalSpeed = Input.GetAxis("Vertical");

            //   transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horzontalSpeed);
            transform.Translate(Vector3.forward * Time.deltaTime * velocity * verticalSpeed);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horzontalSpeed);

            myCamera.transform.position = transform.position + cameraOffset;
            myCamera.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.right * 20);
        }
        private void LateUpdate()
        {
        }
    }
}