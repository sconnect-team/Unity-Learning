using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject enemyPb;
        public float spawnRange;
        // Start is called before the first frame update
        void Start()
        {
            Instantiate(enemyPb, GeneratePos(), enemyPb.transform.rotation);
        }

        private Vector3 GeneratePos()
        {
            var xPos = UnityEngine.Random.Range(-spawnRange, spawnRange);
            var ZPos = UnityEngine.Random.Range(-spawnRange, spawnRange);
            return new Vector3(xPos, 0, ZPos);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
