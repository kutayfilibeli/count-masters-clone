using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerDetect playerDetect;
    private EnemyCreator enemyCreator;
    private PlayerCreator playerCreator;
    private Transform playerBase;
   

    private bool kill = false;

    private void Awake()
    {
        playerDetect = FindObjectOfType<PlayerDetect>();
        playerBase = GameObjectManager.instance.allObjects[0].transform;
        enemyCreator = GameObjectManager.instance.allObjects[1].GetComponent<EnemyCreator>();
        playerCreator = GameObjectManager.instance.allObjects[0].GetComponent<PlayerCreator>();
        
    }

    private void FixedUpdate()
    {
        if (playerDetect.rush)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerBase.position, Time.fixedDeltaTime * 2.7f);
        }        
    } 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !kill)
        {
            kill = true;
            playerCreator.players.Remove(collision.gameObject);
            collision.transform.parent = null;
            collision.gameObject.SetActive(false);
            

           
            enemyCreator.enemies.Remove(gameObject);            
            gameObject.SetActive(false);
          
        }
    }
}
