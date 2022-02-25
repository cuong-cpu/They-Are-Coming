using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    public float Speed = 50;

    public float MoveSpeed = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0,0,MoveSpeed*Time.deltaTime);
        transform.Rotate(Speed * Time.deltaTime,0,0); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
            Destroy(other.transform.gameObject);
       
    }
}
