using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject[] enemies;

    public int maxEnemies = 4;

    int count = 0;

    bool counting = false;
    GameManagment.GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManagment.GameManager>();
    }

    void FixedUpdate () {
        if(count <= maxEnemies)
        {
            if (counting == false)
            {
                StartCoroutine(SpawnEnemy());
            }
        }
	}

    IEnumerator SpawnEnemy()
    {
        counting = true;
        count += 1;
        int random = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[random], this.transform);
        enemy.GetComponent<EnemyManager>().SetPlayer(gameManager.livePlayer);
        enemy.transform.position = this.transform.position;
        yield return new WaitForSeconds(10);
        counting = false;
    }
}
