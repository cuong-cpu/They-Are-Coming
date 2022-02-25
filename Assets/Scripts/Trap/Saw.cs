using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float MoveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0,0,MoveSpeed * Time.deltaTime);
        
    }
    public void OnCollisionEnter(Collision other)
    {
        
        if (other.collider.gameObject.CompareTag("Wall"))
            MoveSpeed *= -1;
    }
}
