using DitzeGames.Effects;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScytheSpawner : BaseWeapon
{
    
    [SerializeField] GameObject scythePrefab;
    
    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
        
    }
    
    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            CameraEffects.ShakeOnce();

            for (int i = 0; i < level; i++)
            {
                float randomAngle = Random.Range(0, 360f);
                Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);
                for(int j = 0; j < level; j++)
                {
                    Instantiate(scythePrefab, transform.position, rotation);
                    
                }
            }
        }
    }
    
}
