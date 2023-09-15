using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float speed = -7;
    Player player;

    void Start()
    {
        player = GameObject.Find(name: "Player").GetComponent<Player>();
    }

    void Update()
    {
        //transform.Rotate(new Vector3(0.2f, 0.2f, 0.2f));
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

}
