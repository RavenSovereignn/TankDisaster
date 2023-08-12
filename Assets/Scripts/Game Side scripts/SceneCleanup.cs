using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCleanup : MonoBehaviour
{
    private GameObject[] WarheadObj;
    private bool cleaning = false;
    public float TimeBetweenCleaning = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WarheadObj = GameObject.FindGameObjectsWithTag("Warhead");
        if (cleaning == false)
        {
            CleanupWarhead();
        }
    }

    private void CleanupWarhead()
    {
        cleaning = true;
        foreach (GameObject warhead in WarheadObj)
        {
            Debug.Log(warhead);
            Destroy(warhead);
           
        }
        Invoke("Cleaned", TimeBetweenCleaning);
        
    }

    private void Cleaned()
    {
        Debug.Log("Cleaned Warheads");
        cleaning = false;
    }
}
