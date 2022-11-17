using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : BaseWeapon

{
    [SerializeField] GameObject lightningBombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < level; i++)
            {
                Vector3 spawnPosition = UnityEngine.Random.insideUnitCircle * 5;
                spawnPosition += this.transform.position;
                Instantiate(lightningBombPrefab, spawnPosition, Quaternion.identity);

                
            }
        }
    }
}
