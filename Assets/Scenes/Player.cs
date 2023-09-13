using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpPower = 4;
    public float lowWarn = -4;
    public float jumpBoost = 2.5f;
    public float step = 0.5f;
    public float scaleStep = 0.1f;

    TextMesh scoreOutput;
    int score = 0;

    void Start()
    {
        // �̸����� ���� ������Ʈ�� ã��, �� �� TextMesh ������Ʈ�� ���
        scoreOutput = GameObject.Find(name: "Score").GetComponent<TextMesh>();    
    }

    void Update()
    {
        //transform.position += new Vector3(step * Time.deltaTime, 0, 0);
        //transform.localScale += new Vector3(0, scaleStep * Time.deltaTime, 0);
        if (Input.GetButtonDown("Jump"))
        {

            if (gameObject.transform.position.y < lowWarn)
            {
                Debug.Log("Boost Jump!!");
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower + jumpBoost, 0);
            }
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            }
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bonus(Clone)")
        {
            addScore(10);
            Destroy(collision.gameObject);
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ���� ���ϱ�
    public void addScore(int s)
    {
        score += s;
        scoreOutput.text = "���� : " + score;
    }
}
