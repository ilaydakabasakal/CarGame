using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonsuzYol : MonoBehaviour
{
    
    
    private void OnTriggerEnter(Collider other)
    {
       

        transform.position += new Vector3(0, 0, transform.GetChild(0).GetComponent<Renderer>().bounds.size.z*4 - 10);
    }
}
