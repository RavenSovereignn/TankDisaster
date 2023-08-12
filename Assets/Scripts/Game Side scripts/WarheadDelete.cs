using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarheadDelete : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
    }
}
