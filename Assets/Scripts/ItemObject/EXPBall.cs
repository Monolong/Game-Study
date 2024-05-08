using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPBall : MonoBehaviour
{
    [SerializeField] float expAmount = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if(collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<Character>().SetCharaEXP(expAmount);
            Destroy(gameObject);
        }
    }
}
