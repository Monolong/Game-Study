using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CreatureStat
{
    public int level;

    public float healthPoint;
    public float healthPointMax;

    public float expCurrent;
    public float expMax;
}

public class Character : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    Vector3 moveVector;

    [SerializeField] HPIndicator indicator;

    [SerializeField] CreatureStat stat;


    private void Start()
    {
        SetHealthPoint(stat.healthPointMax);
    }

    // Update is called once per frame
    void Update()
    {
        MoveByAxes();
    }

    public void SetHealthPoint(float health)
    {
        stat.healthPoint = health;
        indicator.SetIndicator(stat.healthPoint/stat.healthPointMax);
    }

    public void SetCharaEXP(float amount)
    {
        stat.expCurrent += amount;
    }

    public void ExecuteOnDamaged(float damage)
    {
        SetHealthPoint(stat.healthPoint - damage);
        Debug.Log("¾Æ¾ß");
    }

    void MoveByRigidBody()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.W))
        {
            moveVector = transform.up; //(0,1,0)
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveVector = -1 * transform.right; //(-1,0,0)
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVector = -1 * transform.up; //(0,-1,0)
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveVector = transform.right; //(1,0,0)
        }
        else
        {
            moveVector = Vector3.zero;
        }

        rb.AddForce(moveVector * moveSpeed * Time.deltaTime);
    }

    void MoveByTransform()
    {
        moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveVector += transform.up; //(0,1,0)
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVector += -1 * transform.up; //(0,-1,0)
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVector += -1 * transform.right; //(-1,0,0)
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveVector += transform.right; //(1,0,0)
        }

        transform.position += moveVector.normalized * moveSpeed * Time.deltaTime;
    }
    void MoveByAxes()
    {
        moveVector = Input.GetAxis("Horizontal") * transform.right;
        moveVector += Input.GetAxis("Vertical") * transform.up;
        transform.position += moveVector.normalized * moveSpeed * Time.deltaTime;
    }
}
