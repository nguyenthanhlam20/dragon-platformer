using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int size = 10;
    private readonly List<GameObject> pool = new();

    private void Awake()
    {
        for (int i = 0; i < size; i++)
        {
            GameObject instance = Instantiate(prefab, transform.position, Quaternion.identity);
            instance.SetActive(false);
            pool.Add(instance);
        }
    }

    public GameObject GetFromPool()
    {
        GameObject instance = pool.FirstOrDefault(x => x.activeSelf == false);
        instance.SetActive(true);
        return instance;
    }

    public void BackToPool(GameObject target) => target.SetActive(false);
}
