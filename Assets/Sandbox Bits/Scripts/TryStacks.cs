using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TryStacks : MonoBehaviour
{
    private Stack<GameObject> itemStack = new Stack<GameObject>();

    private Queue<GameObject> itemQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject item = transform.GetChild(i).gameObject;
            itemStack.Push(item);
        }
        
    }

    public void RemoveFromStack()
    {
        GameObject currentItem = itemStack.Pop();

        currentItem.SetActive(false);

        itemQueue.Enqueue(currentItem);
    }

    public void RemoveFromQueue()
    {
        GameObject currentItem = itemQueue.Dequeue();
        currentItem.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RemoveFromStack();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            RemoveFromQueue();
        }
    }
}
