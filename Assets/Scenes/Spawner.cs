using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] wallPrefab;
    public GameObject dropPrefab;
    public GameObject bonusPrefab;

    public float interval = 1.5f;   // ���� �ð�����
    public float range = 4;
    float term;
    float bonusTerm;

    Vector3 pos;

    void Start()
    {
        term = interval;    // ���ۺ��� ���� �ϳ� ������ ����    
        bonusTerm = 0.75f;
        pos = transform.position;
    }

    void Update()
    {
        term += Time.deltaTime;
        bonusTerm += Time.deltaTime;
        if(term >= interval)
        {
            // ��ֹ� ����
            pos = transform.position;
            pos.y += Random.Range(-range, range);   // float�̸� max�� ����, int�� max�� �������� ����
            int wallType = Random.Range(0, wallPrefab.Length);
            Instantiate(wallPrefab[wallType], pos, transform.rotation);

            // �������� ��ֹ� ����
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
                // ���ʽ� ����
                pos = transform.position;
                pos.y += Random.Range(-range, range);
                Instantiate(bonusPrefab, pos, transform.rotation);
            }
            bonusTerm -= interval;
        }
    }
}
