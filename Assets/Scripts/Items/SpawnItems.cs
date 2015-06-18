using UnityEngine;
using System.Collections;

public class SpawnItems : MonoBehaviour
{
    public Item[] items;

	public void Spawn (Vector3 position)
    {
        Item item = items[Random.Range(0, items.Length)];

        if (Random.Range(0, 1f) < item.probability)
        {
            GameObject obj = Instantiate(item.gameObject, position, Quaternion.identity) as GameObject;
            obj.name = item.gameObject.name;
        }
	}
}

[System.Serializable]
public class Item
{
    public GameObject gameObject;
    public float probability;
}
