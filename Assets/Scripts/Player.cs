using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerCreator playerCreator;
    private Transform Center;
    [SerializeField] private float speed;

    private void Awake()
    {
        playerCreator = GameObjectManager.instance.allObjects[0].GetComponent<PlayerCreator>();
        Center = GameObjectManager.instance.allObjects[0].transform;
    }

    void FixedUpdate()
    {
        if (!playerCreator.holdoff)
        {
            transform.position = Vector3.MoveTowards(transform.position, Center.position, Time.fixedDeltaTime * speed);
        }
    }
}
