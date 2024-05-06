using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabHareket : MonoBehaviour
{

    void Update()
    {
        float hareketAralýðý = Random.Range(5f, 15f);
        this.gameObject.transform.Translate(0, 0, hareketAralýðý * Time.deltaTime);
    }
}