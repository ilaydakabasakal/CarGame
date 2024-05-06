using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColYol : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Vector3 reverseDirection = new Vector3(0, 0, -(transform.GetChild(0).GetComponent<Renderer>().bounds.size.z * 20));
		transform.position += reverseDirection;
	}


}
