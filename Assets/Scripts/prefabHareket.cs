using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabHareket : MonoBehaviour
{

    void Update()
    {
        float hareketAral��� = Random.Range(5f, 15f);
        this.gameObject.transform.Translate(0, 0, hareketAral��� * Time.deltaTime);
    }
}