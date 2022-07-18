using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    Queue<GameObject> queue = new Queue<GameObject>();
    [SerializeField] List<GameObject> list = new List<GameObject>();
    [Space]
    [SerializeField] int queueLength = 5;
    [Space]
    [SerializeField] Transform[] sockets;

    private void Start()
    {
        for (int i = 0; i < queueLength; i++)
        {
            queue.Enqueue(RandomItem());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (var item in queue)
            {
                Debug.Log(item);
            }
        }
    }

    GameObject RandomItem() { return list[Random.Range(0, list.Count)]; }

    GameObject NextItem()
    {
        queue.Enqueue(RandomItem());
        return queue.Dequeue();
    }
}