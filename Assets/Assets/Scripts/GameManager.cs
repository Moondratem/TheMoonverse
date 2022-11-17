using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject merman;
    [SerializeField] GameObject sirmer;
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject vampire;
    [SerializeField] GameObject Giant;
    [SerializeField] GameObject player;

    int spawnCounter = 1;

    private void Update()
    {
        int seconds = (int)Time.time;
        int minutes = 0;
        if (seconds >= 60)
        {
            seconds -= 60;
            minutes++;
        }
        timerText.text = $"{minutes}:{seconds}";
    }

    void Start()
    {
        //For testing
        if(TitleManager.saveData == null)
        {
            TitleManager.saveData = new SaveData();
        }

        StartCoroutine(SpawnEnemiesCoroutine());
    }

    IEnumerator SpawnEnemiesCoroutine()
    {
        yield return new WaitForSeconds(5f);
        SpawnEnemies(Giant, 2);
        yield return new WaitForSeconds(5f);
        SpawnEnemies(sirmer, 20);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(merman, 5, false);
        yield return new WaitForSeconds(5f);
        SpawnEnemies(zombie, 5);
        yield return new WaitForSeconds(5f);
        SpawnEnemies(zombie, 10);
        yield return new WaitForSeconds(10f);
        SpawnEnemies(vampire, 5);
        yield return new WaitForSeconds(10f);
        SpawnEnemies(vampire, 5, false);
        yield return new WaitForSeconds(10f); 
        SpawnEnemies(sirmer, 1);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(merman, 10);
        SpawnEnemies(vampire, 10, false);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(merman, 15, false);
        SpawnEnemies(zombie, 15);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(vampire, 10);
        SpawnEnemies(zombie, 20, false);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(vampire, 25, false);
        SpawnEnemies(sirmer, 3);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(merman, 20);
        SpawnEnemies(zombie, 15);
        SpawnEnemies(zombie, 20);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(merman, 20, false);
        SpawnEnemies(zombie, 20, false);
        SpawnEnemies(zombie, 20, false);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(merman, 25);
        SpawnEnemies(zombie, 25);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(merman, 25);
        SpawnEnemies(vampire, 25);
        SpawnEnemies(zombie, 25);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(merman, 50);
        SpawnEnemies(zombie, 50);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(sirmer, 10);
        SpawnEnemies(merman, 20, false);
        SpawnEnemies(zombie, 20, false);
        SpawnEnemies(zombie, 20, false);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(sirmer, 10);
        SpawnEnemies(merman, 20, false);
        SpawnEnemies(zombie, 20, false);
        SpawnEnemies(zombie, 20, false);

        while (true)
        {
            yield return new WaitForSeconds(20f);
            SpawnEnemies(sirmer, 10);
            SpawnEnemies(merman, 20, false);
            SpawnEnemies(zombie, 20, false);
            SpawnEnemies(zombie, 20, false);
        }
    }

    private void SpawnEnemies(GameObject enemyToSpawn, int numberofEnemies, bool isChasing = true)
    {
        for (int i = 0; i < numberofEnemies; i++)
        {
            Vector3 spawnPosition = UnityEngine.Random.insideUnitCircle.normalized * 8;
            spawnPosition += player.transform.position;
            GameObject go = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
            Enemy enemy = go.GetComponent<Enemy>();            
            enemy.isChasing = isChasing;
        }
    }
}
