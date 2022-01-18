using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public objects objects;
    public ObjectManager objectManager;

    void Start()
    {
        objectManager = FindObjectOfType<ObjectManager>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(objects == objects.cube01 && collision.gameObject.GetComponent<CollisionDetection>().objects == objects.cylinder04)
        {
            objectManager.onCorrectAns();
        }

        if (objects == objects.cube01 && collision.gameObject.GetComponent<CollisionDetection>().objects == objects.cube03)
        {
            objectManager.onIncorrectAns();
        }

        if (objects == objects.cube01 && collision.gameObject.GetComponent<CollisionDetection>().objects == objects.sphere02)
        {
            objectManager.onIncorrectAns();
        }
    }
}
