using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4
{
    public class RotateCamera : MonoBehaviour
    {
        public float rotateSpeed;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            var yAxis = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, yAxis * rotateSpeed * Time.deltaTime);
        }
    }
}
