using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{

    //public GameObject ground;
    private bool walking = true;
    private Vector3 spanPoint;

    // Use this for initialization
    void Start()
    {
        spanPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (walking)
        {
            transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime;
        }

        if (transform.position.y < -10f)
        {
            transform.position = spanPoint;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("plane"))
            {
                walking = false;
            }
            else
            {
                walking = true;
            }
        }
    }
}