using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public float spawnProbability = 0.5f;
    public Item[] itemPrefabs;

    private Item _currentItem;

    public void ResetItem()
    {
        if (_currentItem != null)
        {
            Destroy(_currentItem.gameObject);
        }
        
        if (Random.value < spawnProbability)
        {
            _currentItem = Instantiate(SelectRandomItem(), transform);
            _currentItem.Initialize();
        }
    }

    private Item SelectRandomItem()
    {
        return itemPrefabs[Random.Range(0, itemPrefabs.Length)];
    }
}
