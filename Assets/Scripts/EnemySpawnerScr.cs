using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerScr : MonoBehaviour
{
    public LevelManagerScr LMS;
    GameControllerScr gcs;

    public float timeToSpawn = 4;
    int spawnCount = 0;

    public GameObject enemyPref;

    private void Start()
    {
        gcs = FindObjectOfType<GameControllerScr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToSpawn <= 0)
        {
            StartCoroutine(SpawnEnemy(spawnCount + 1));
            timeToSpawn = 4;
        }

        timeToSpawn -= Time.deltaTime;
    }

    IEnumerator SpawnEnemy(int enemyCount)
    {
        spawnCount++;

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject tmpEnemy = Instantiate(enemyPref);
            tmpEnemy.transform.SetParent(gameObject.transform, false);

            tmpEnemy.GetComponent<EnemyScr>().selfEnemy = new Enemy(gcs.AllEnemies[Random.Range(0, gcs.AllEnemies.Count)]);

            Transform startCellPos = LMS.wayPoints[0].transform;
            Vector3 startPos = new Vector3(startCellPos.position.x + startCellPos.GetComponent<SpriteRenderer>().bounds.size.x / 2,
                                           startCellPos.position.y - startCellPos.GetComponent<SpriteRenderer>().bounds.size.y / 2);

            tmpEnemy.transform.position = startPos;

            yield return new WaitForSeconds(0.3f);
        }
    }
}
