using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] Camera myCamera;
    [SerializeField] float turnSpeed;
    private float horzontalSpeed;
    private float verticalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horzontalSpeed = Input.GetAxis("Horizontal");
        verticalSpeed = Input.GetAxis("Vertical");

        //   transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horzontalSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * velocity * verticalSpeed);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horzontalSpeed);
    }
    private void LateUpdate()
    {
        myCamera.transform.position = transform.position + new Vector3(0, 6, -6);
    }
}
