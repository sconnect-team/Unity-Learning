using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject obstaclePb;
        public Vector3 spawnObstaclePos;
        public Vector3 rotateObstacle;
        private PlayerController player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
        }
        private void OnEnable()
        {
            InvokeRepeating("SpawnObstacle", 0, 2);
        }

        private void SpawnObstacle()
        {
            if (!player.isGameOver)
            {
                Instantiate(obstaclePb, spawnObstaclePos, Quaternion.Euler(rotateObstacle));
            }
        }
        private void OnDisable()
        {
            CancelInvoke();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
