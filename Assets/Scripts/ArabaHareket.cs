using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class arabaHareket : MonoBehaviour
{
    public int puan;
    public TextMeshProUGUI puanText;
    bool oyunBitti = false;
    public float totalTime = 10f; // Toplam s�re
    public Image geriSayim;
    public TextMeshProUGUI sureText;
    private float simdikiZaman;
    public float maxSpeed = 50f; // Maksimum h�z de�eri
    public GameObject panel;
    void Start()
    {
        simdikiZaman = totalTime;
    }

    void Update()
    {
        if (simdikiZaman > 0)
        {
            simdikiZaman -= Time.deltaTime;
            sureText.text = ((int)simdikiZaman).ToString();
            geriSayim.fillAmount = simdikiZaman / totalTime;
        }
        if (simdikiZaman <= 0)
        {
            EndGame();
        }
        if (oyunBitti == false && Input.GetKey("w")) //z ekseni boyunca ileri do�ru hareket eder h�z� 90 
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 200, ForceMode.Force);
        }

        if (oyunBitti == false && Input.GetKey("d")) // d bas�nca sa�a do�ru belli h�zda hareket eder
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * 250, ForceMode.Force);
        }
        if (oyunBitti == false && Input.GetKey("a")) // a bas�nca sola do�ru belli h�zda hareket eder
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * 250, ForceMode.Force);
        }
        if (oyunBitti == false && Input.GetKey("s")) // s bas�nca h�z� yava�lar
        {
            // "s" tu�una bas�ld���nda araban�n h�z�n� azalt
            GetComponent<Rigidbody>().AddForce(Vector3.back * 200, ForceMode.Force);
        }
        else if (oyunBitti == true) // e�er oyun bittiyse araba hareket etmez h�z� s�f�rlaan�r 
        {
            Time.timeScale = 0f;
            //GameObject.FindWithTag("car").GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        //Maksimum h�z tan�mlanmas�
        float currentSpeed = GetComponent<Rigidbody>().velocity.magnitude;

        if (currentSpeed > maxSpeed)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
        }



    }
    void EndGame()
    {
        // Oyunu sonland�rma i�lemleri buraya gelecek
        Debug.Log("Game Over!"); // �rnek: Konsola oyunun bitti�ini yazd�r
        // Oyunu durdurabilir veya ba�ka bir i�lem yapabilirsiniz.
        oyunBitti = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            puan++;
            Destroy(other.gameObject);
            puanText.text = " " + puan;
			if (puan >= 15)
            {
                panel.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }




}