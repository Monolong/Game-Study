using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] protected float spawnDelay = 1f;
    [SerializeField] protected int spawnAmount = 1;

    [SerializeField] protected GameObject weaponObject;

    protected void Start()
    {
        StartCoroutine(SpawnbyTime());
    }

    protected IEnumerator SpawnbyTime() // �ڷ�ƾ
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            for (int i = 0; i < spawnAmount; i++)
            {
                SpawnObject();
            }
        }
    }

    protected virtual GameObject SpawnObject()
    {
        //����
        return Instantiate(weaponObject, transform.position, Quaternion.identity);
    }
   
}
