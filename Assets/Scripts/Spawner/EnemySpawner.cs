using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 3f;
    [SerializeField] int spawnAmount = 2;

    [SerializeField] GameObject enemyObject;

    public List<Enemy> enemyList;

    GameObject spawnedEnemyObj;
    Enemy spawnedEnemy;
    //���ʿ� �ѹ��� ������ ��ġ�� ������Ű�� �ʹ�

    private void Start()
    {
        StartCoroutine(SpawnbyTime());
    }

    IEnumerator SpawnbyTime() // �ڷ�ƾ
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            for (int i = 0; i < spawnAmount; i++)
            {
                spawnedEnemyObj = SpawnObject();
                spawnedEnemy = spawnedEnemyObj.GetComponent<Enemy>();
                enemyList.Add(spawnedEnemy);
                spawnedEnemy.ExecuteOnInit(this);
            }
        }
    }

    GameObject SpawnObject()
    {
        //����
        return Instantiate(enemyObject, GetRndPos(), Quaternion.identity);
    }
    
    Vector3 GetRndPos()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);
        Vector3 rndPos = new Vector3(x, y, 0);
        return rndPos;
    }
}
