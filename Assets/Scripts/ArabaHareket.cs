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
    public float totalTime = 10f; // Toplam süre
    public Image geriSayim;
    public TextMeshProUGUI sureText;
    private float simdikiZaman;
    public float maxSpeed = 50f; // Maksimum hýz deðeri
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
        if (oyunBitti == false && Input.GetKey("w")) //z ekseni boyunca ileri doðru hareket eder hýzý 90 
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 200, ForceMode.Force);
        }

        if (oyunBitti == false && Input.GetKey("d")) // d basýnca saða doðru belli hýzda hareket eder
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * 250, ForceMode.Force);
        }
        if (oyunBitti == false && Input.GetKey("a")) // a basýnca sola doðru belli hýzda hareket eder
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * 250, ForceMode.Force);
        }
        if (oyunBitti == false && Input.GetKey("s")) // s basýnca hýzý yavaþlar
        {
            // "s" tuþuna basýldýðýnda arabanýn hýzýný azalt
            GetComponent<Rigidbody>().AddForce(Vector3.back * 200, ForceMode.Force);
        }
        else if (oyunBitti == true) // eðer oyun bittiyse araba hareket etmez hýzý sýfýrlaanýr 
        {
            Time.timeScale = 0f;
            //GameObject.FindWithTag("car").GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        //Maksimum hýz tanýmlanmasý
        float currentSpeed = GetComponent<Rigidbody>().velocity.magnitude;

        if (currentSpeed > maxSpeed)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
        }



    }
    void EndGame()
    {
        // Oyunu sonlandýrma iþlemleri buraya gelecek
        Debug.Log("Game Over!"); // Örnek: Konsola oyunun bittiðini yazdýr
        // Oyunu durdurabilir veya baþka bir iþlem yapabilirsiniz.
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