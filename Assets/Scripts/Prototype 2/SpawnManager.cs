using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] animals;
        public float xRange;
        public float zRange;
        public float spawnDelayTime;
        public float repeatingTime;

        private void Start()
        {
            InvokeRepeating("SpawnRandomAnimal", spawnDelayTime, repeatingTime);
        }
        private void Update()
        {
        }

        void SpawnRandomAnimal()
        {
            var rdIndex = Random.Range(0, animals.Length);
            var rdXRange = Random.Range(-xRange, xRange);
            Instantiate(animals[rdIndex], new Vector3(rdXRange, 0, zRange), Quaternion.Euler(Vector3.up * 180));
        }
    }
}
