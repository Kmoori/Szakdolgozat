using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostCameraBehaviour : MonoBehaviour
{
    Transform targetObject;

    public float speed = 2f;

    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("Object").GetComponent<Transform>();
    }



    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(targetObject.transform.position, Vector3.up, -Input.GetAxis("Mouse X") * speed); //Jobbra-Balra
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f) // Elõre
        {
            transform.position = transform.position + Camera.main.transform.forward * 5 * Time.deltaTime;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // Hátra
        {
            transform.position = transform.position + -Camera.main.transform.forward * 5 * Time.deltaTime;
        }
    }
}
