using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] wallPrefab;
    public GameObject dropPrefab;
    public GameObject bonusPrefab;

    public float interval = 1.5f;   // 일정 시간마다
    public float range = 4;
    float term;
    float bonusTerm;

    Vector3 pos;

    void Start()
    {
        term = interval;    // 시작부터 벽이 하나 나오기 위해    
        bonusTerm = 0.75f;
        pos = transform.position;
    }

    void Update()
    {
        term += Time.deltaTime;
        bonusTerm += Time.deltaTime;
        if(term >= interval)
        {
            // 장애물 생성
            pos = transform.position;
            pos.y += Random.Range(-range, range);   // float이면 max를 포함, int면 max를 포함하지 않음
            int wallType = Random.Range(0, wallPrefab.Length);
            Instantiate(wallPrefab[wallType], pos, transform.rotation);

            // 떨어지는 장애물 생성
            if (Random.Range(0, 3) == 0)
            {
                Instantiate(dropPrefab);
            }

            term -= interval;
        }

        if (bonusTerm >= interval)
        {
            if (Random.Range(0, 2) == 0)
            {
                // 보너스 생성
                pos = transform.position;
                pos.y += Random.Range(-range, range);
                Instantiate(bonusPrefab, pos, transform.rotation);
            }
            bonusTerm -= interval;
        }
    }
}
