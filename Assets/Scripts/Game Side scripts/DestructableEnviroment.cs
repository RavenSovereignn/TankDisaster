using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableEnviroment : MonoBehaviour
{
    public float maxForce;
    public float timeToDestroy;
    public Score scorenb;

    public void Start()
    {
        scorenb = GameObject.Find("ScoreUIMain").GetComponent<Score>();
    }
    public void BreakEnviroment()
    {
        Rigidbody[] bricks = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody objPart in bricks)
        {
            objPart.isKinematic = false;

            objPart.AddExplosionForce(maxForce, transform.position, 20f);
            objPart.AddForce(Random.insideUnitSphere * maxForce);

        }
        Destroy(gameObject.GetComponent<Collider>());
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Warhead")
        {
            BreakEnviroment();
            Destroy(collision.gameObject);
            Debug.Log("Warhead in da house");
            scorenb.scoreNumber = scorenb.scoreNumber + 50;
            DBManager.score = DBManager.score + 50;
            scorenb.myScore();
            Debug.Log("Snake score:" + scorenb.scoreNumber);
            Debug.Log("Snake score server:" + DBManager.score);

        }
        if (collision.gameObject.tag == "Player")
        {
            BreakEnviroment();
            Debug.Log("Player in da house");
            scorenb.scoreNumber = scorenb.scoreNumber + 100;
            DBManager.score = DBManager.score + 100;
            scorenb.myScore();
            Debug.Log("Snake score:" + scorenb.scoreNumber);
            Debug.Log("Snake score server:" + DBManager.score);
        }
    }
    
}
