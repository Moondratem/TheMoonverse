using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Enemy BossMan;
    public void Start()
    {
        StartCoroutine(TeleportCoroutine());
        

    }
    void Update()
    {
        if(BossMan.EnemyHP <= 10)
        {
            BossMan.Speed = 2;
        }

    }

    IEnumerator TeleportCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(6.2f);
            this.transform.position = UnityEngine.Random.insideUnitCircle.normalized * 8;
            

        }
    }
}
