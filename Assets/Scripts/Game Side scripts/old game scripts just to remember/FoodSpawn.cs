using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;
    private int randomPrefab;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>(); 
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Spawn one piece of food
    public void Spawn()
    {

        
        
            // x position between left & right border
            int x = (int)Random.Range(-85,85);

            // y position between top & bottom border
            int y = (int)Random.Range(-39,
                                      39);
            //Random prefab selection for food sprite
            randomPrefab = Random.Range(0, 7);
            // Instantiate the food at (x, y)
            Instantiate(prefabs[randomPrefab], new Vector2(x, y), Quaternion.identity);
        
    }
}
