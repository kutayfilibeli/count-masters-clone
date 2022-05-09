using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    private PlayerController playerController;
    private EnemyCreator enemyCreator;
    public SphereCollider sphCol;
    private bool isplayerDetected = false;
    public bool rush = false;

    private void Awake()
    {
        playerController = GameObjectManager.instance.allObjects[0].GetComponent<PlayerController>();
        enemyCreator = GameObjectManager.instance.allObjects[1].GetComponent<EnemyCreator>();
    }

    private void Start()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isplayerDetected == false)
        {
            isplayerDetected = true;
            StartCoroutine(Stop());
            sphCol.enabled = false;
            rush = true;
        }
    }

    private IEnumerator Stop()
    {
        playerController.enabled = false;
        yield return new WaitUntil(() => enemyCreator.isEnemyAlive == false);
        playerController.enabled = true;
    }
}
