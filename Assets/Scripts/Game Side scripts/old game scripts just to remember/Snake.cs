using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;

public class Snake : MonoBehaviour
{
    // Current Movement Direction
    // (by default it moves to the right)
    Vector2 dir = Vector2.right;
    List<Transform> tail = new List<Transform>();
    public bool ate = false;
    // Tail Prefab
    public GameObject tailPrefab;
    public FoodSpawn spawn;
    // Score UI
    public Score scorenb;
    //Server side of the script
    PhotonView view;

    // Use this for initialization
    void Start()
    {
        // Move the Snake every 100ms
        InvokeRepeating("Move", 0.1f, 0.1f);
        view = GetComponent<PhotonView>();
        scorenb = GameObject.Find("ScoreUIMain").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
            dir = Vector2.right;
        else if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow)))
            dir = -Vector2.up;    // '-up' means 'down'
        else if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
            dir = -Vector2.right; // '-right' means 'left'
        else if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow)))
            dir = Vector2.up;
    }

    void Move()
    {
        // Save current position (gap will be here)
        Vector2 v = transform.position;
        if (view.IsMine)
        {
            // Move head into new direction (now there is a gap)
            transform.Translate(dir);
        }
            // Ate something? Then insert new Element into gap
            if (ate)
            {
                
                // Load Prefab into the world
                GameObject g = (GameObject)PhotonNetwork.Instantiate(tailPrefab.name,v,Quaternion.identity);

                // Keep track of it in our tail list
                tail.Insert(0, g.transform);

                // Reset the flag
                ate = false;
            }
            // Do we have a Tail?
            else if (tail.Count > 0)
            {
                // Move last Tail Element to where the Head was
                tail.Last().position = v;

                // Add to front of list, remove from the back
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.gameObject.tag == "Food")
        {
            if (view.IsMine) 
            {
                // Get longer in next Move call
                ate = true;
                spawn.Spawn();
                scorenb.scoreNumber++;
                DBManager.score++;
                //scorenb.ScoreUI(scorenb.scoreNumber);
                scorenb.myScore();
                Debug.Log("Snake score:" + scorenb.scoreNumber);
                Debug.Log("Snake score server:" + DBManager.score);
                // Remove the Food
                Destroy(coll.gameObject);
            }   
            else
            {
                // ToDo 'You lose' screen
            }
        }   
        // Collided with Tail or Border  
    }
}
