using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class DestroyOutofBound : MonoBehaviour
    {
        public float topBound;
        public float bottomBound;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(transform.position.z > topBound || transform.position.z < bottomBound)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
