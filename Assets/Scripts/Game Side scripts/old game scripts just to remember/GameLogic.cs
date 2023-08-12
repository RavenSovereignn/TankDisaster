using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject foodPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(foodPrefab,
                  new Vector2(0, 0),
                  Quaternion.identity); // default rotation
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
