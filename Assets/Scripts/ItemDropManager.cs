using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemDropData
{
    public int itemID;
    public string name;
    public int amount;
    public float probability;
}

public class EnemyData
{
    public int enemyID;
    public string enemyName;
    public List<ItemDropData> dropTable;
}

public class ItemData
{
    public int itemID;
    public string name;
    public int description;
    public float probability;
    public GameObject itemPrefab;
}

public class ItemDropManager : MonoBehaviour
{
    List<ItemDropData> itemDropDataList;
    List<ItemData> itemDataList;

    public void OnDropItemSequence(Enemy enemy)
    {
        ItemDropData chosenData =  GetDropData(GetDropTable(enemy.id));
        DropItem(chosenData, enemy);
    }

    public void DropItem(ItemDropData chosenData, Enemy enemy) //������ ���������
    {
        int itemAmount = chosenData.amount;
        GameObject itemPrefab = GetItemData(chosenData.itemID).itemPrefab;
        Vector3 enemyPos = enemy.transform.position;

        for (int i=0; i < itemAmount; i++)
        {
            Instantiate(itemPrefab, enemyPos, Quaternion.identity); 
        }
    }

    ItemData GetItemData(int itemID)
    {
        ItemData itemData = itemDataList.Find(x => x.itemID.Equals(itemID));
        return itemData;
    }

    List<ItemDropData> GetDropTable(int enemyId) // enemyDataList���� ���� ��� ���̺� ã��, ��ȯ
    {
        List<EnemyData> enemyDataList = new(); // ���ʹ� ���� ����Ʈ ���� �ʿ� NYI
        EnemyData enemyData = enemyDataList.Find(x => x.enemyID.Equals(enemyId));
        return enemyData.dropTable;
    }

    ItemDropData GetDropData(List<ItemDropData> dropTable)
    {
        //Ȯ�� ���� -> probability Manager���� �������, NYI
        ItemDropData chosenData = new(); // NYI
        return chosenData;
    }

}
