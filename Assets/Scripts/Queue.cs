using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    #region Singleton
    public static Queue Instance;
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    } 
    #endregion

    Queue<GameObject> queue = new Queue<GameObject>();
    [SerializeField] List<GameObject> list = new List<GameObject>();
    [Space]
    [SerializeField] int queueLength = 5;
    [Space]
    [SerializeField] RectTransform[] sockets;


    private void Start()
    {
        Init();
    }

    GameObject RandomItem() { return Instantiate(list[Random.Range(0, list.Count)]); }

    void Init()
    {
        for (int i = 0; i < queueLength; i++)
        {
            var newItem = RandomItem();
            newItem.GetComponent<UIQueueObject>().index = -1;
            newItem.GetComponent<UIQueueObject>().SetPosition(sockets[queueLength - (i+1)].position);
            queue.Enqueue(newItem);
            foreach(var item in queue) { item.GetComponent<UIQueueObject>().index++; }
        }
    }

    public void UpdateQueue()
    {
        var oldItem = queue.Dequeue(); // 1
        oldItem.GetComponent<UIQueueObject>()?.Translate(sockets[queueLength].position, true);//TODO: instantiating sockets
        Destroy(oldItem, 1);
        var newItem = RandomItem(); // 2
        newItem.GetComponent<UIQueueObject>().index = -1;
        newItem.GetComponent<UIQueueObject>().SetPosition(sockets[0].position);
        queue.Enqueue(newItem);
        foreach (var item in queue) { item.GetComponent<UIQueueObject>().index++; }
        foreach (var item in queue)//3
        {
            var UIQO = item.GetComponent<UIQueueObject>();
            UIQO.Translate(sockets[UIQO.index].position);
        }
    }

    public Building PeekQueue() { return queue.Peek().GetComponent<UIQueueObject>().buildingPrefab.GetComponent<Building>(); }
}