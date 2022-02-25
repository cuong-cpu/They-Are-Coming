using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveZeroPoint : MonoBehaviour
{
    public float Speed = 10f;

    // Start is called before the first frame update
    private float rotation = 0;
    private float timer;
    [SerializeField] private Transform point;
    Transform DefensePosition;
    private float NumberOfPlayers;
    private Vector3[] DefPos = new Vector3[100];
    private GameObject MovePoint;
    public static moveZeroPoint instance;

    void Start()
    {
        instance = this;
        PositionCal();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * Speed);
        transform.Rotate(Vector3.up * rotation * Time.deltaTime);
        TheNumberOfPlayer();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Euler")
        {

            rotation = 100;
        }
        else if (other.tag == "Euler2")
        {
            rotation = 0;
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }

        if (other.tag == "Goal")
        {
            Speed = 0; 
            MovetoDefPos();
        }
    }

    public void TheNumberOfPlayer()
    {
        MovePoint = GameObject.Find("movePoint");
        int playerCounting = 0;
        for (int i = 0; i < MovePoint.transform.childCount; i++)
        {
            if (MovePoint.transform.GetChild(i).gameObject.activeSelf)
            {
                playerCounting++;
            }
        }

        NumberOfPlayers = playerCounting;
    }

    void PositionCal()
    {
        int PositionCounting = 0;
        DefensePosition = point.transform;
        
        if (DefensePosition.rotation.eulerAngles.y == 90)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    DefPos[i * 9 + j] = new Vector3(DefensePosition.position.x + i * 0.8f, -0.05f,
                        DefensePosition.position.z + j * 0.8f);
                    PositionCounting++;
                    Debug.Log(DefPos[i * 9 + j]);
                }
            }
        }
        else if (DefensePosition.rotation.eulerAngles.y == 0)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    DefPos[i * 9 + j] = new Vector3(DefensePosition.position.x + j * 0.8f, -0.05f,
                        DefensePosition.position.z + i * 0.8f);
                    PositionCounting++;
                    Debug.Log(DefPos[i * 9 + j]);
                }
            }
        }
    }

    void MovetoDefPos()
    {
        TheNumberOfPlayer();
        int i = 0;
        for (int j = 0; j < MovePoint.transform.childCount; j++)
        {
            if (MovePoint.transform.GetChild(j).gameObject.activeSelf)
            {
                MovePoint.transform.GetChild(j).gameObject.GetComponent<PlayerController>().gameObject
                    .GetComponent<CapsuleCollider>().isTrigger = true;
                MovePoint.transform.GetChild(j).gameObject.GetComponent<PlayerController>().DefencePos = DefPos[i];
                i++;
                continue;
            }
        }
    }
}