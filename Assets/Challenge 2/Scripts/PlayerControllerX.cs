﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Protoype1
{
    public class PlayerControllerX : MonoBehaviour
    {
        public GameObject dogPrefab;

        // Update is called once per frame
        void Update()
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            }
        }
    }
}