using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private int n;

    private GameObject gob;
    public Vector3 DefencePos = Vector3.zero;
    private Rigidbody rb;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gob = GetComponent<GameObject>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
        if (DefencePos != Vector3.zero)
        {
            rb.velocity = DefencePos - transform.position;
        }
        else
        {
            rb.velocity = GameObject.Find("movePoint").gameObject.transform.position - transform.position;
        }
        
    }

   
}
