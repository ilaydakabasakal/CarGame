using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SonARABA : MonoBehaviour
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
	public WheelCollider FL_Wheel;
	public WheelCollider FR_Wheel;
	public WheelCollider RL_Wheel;
	public WheelCollider RR_Wheel;
	public float frenGucu = 100f; // Fren gücü, ne kadar hýzlý fren yapýlacaðýný belirler
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
			GetComponent<Rigidbody>().AddForce(Vector3.forward * 100, ForceMode.Force);
		}

		if (oyunBitti == false && Input.GetKey("d")) // d basýnca saða doðru belli hýzda hareket eder
		{
			GetComponent<Rigidbody>().AddForce(Vector3.right * 50, ForceMode.Force);
		}

		if (oyunBitti == false && Input.GetKey("a")) // a basýnca sola doðru belli hýzda hareket eder
		{
			GetComponent<Rigidbody>().AddForce(Vector3.left * 50, ForceMode.Force);
		}

		if (oyunBitti == false && Input.GetKey("s")) // s basýnca hýzý yavaþlar
		{
			// "s" tuþuna basýldýðýnda arabanýn hýzýný azalt
			GetComponent<Rigidbody>().AddForce(Vector3.back * 100, ForceMode.Force);
		}
		else if (oyunBitti == true) // eðer oyun bittiyse araba hareket etmez hýzý sýfýrlaanýr 
		{
			Time.timeScale = 0f;
		}
		if (Input.GetKeyDown(KeyCode.Space)) // space tuþuna basýldýðýnda
		{
			StartCoroutine(Frenle());
		}

		IEnumerator Frenle()
		{
			while (GetComponent<Rigidbody>().velocity.magnitude > 1f) // Araba hýzý çok düþük olana kadar devam et
			{
				GetComponent<Rigidbody>().velocity -= GetComponent<Rigidbody>().velocity.normalized * frenGucu * Time.deltaTime;
				yield return null;
			}
			GetComponent<Rigidbody>().velocity = Vector3.zero; // Hýz çok düþükse sýfýrla
		}


		// Maksimum hýz tanýmlanmasý
		float currentSpeed = GetComponent<Rigidbody>().velocity.magnitude;

		if (currentSpeed > maxSpeed)
		{
			GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
		}

		// Tekerlekleri döndürme fonksiyonu çaðýrma
		TekerlekleriDondur();
	}
	

	void TekerlekleriDondur()
	{
		// Dönme hýzý tanýmlama
		float donmeHizi = 300f;

		// Input.GetAxis("Horizontal") ile saða ve sola dönüþ kontrolü
		float steer = Input.GetAxis("Horizontal") * donmeHizi * Time.deltaTime;

		// Tekerlek dönüþlerini uygulama
		FL_Wheel.steerAngle = steer;
		FR_Wheel.steerAngle = steer;

		// Tekerleklerin dönmesini saðlamak için güç uygulama
		// Burada aracýn hýzýný deðil, tekerleklerin dönüþlerini kontrol ettiðimizi unutmayýn
		FL_Wheel.motorTorque = Input.GetAxis("Vertical") * donmeHizi;
		FR_Wheel.motorTorque = Input.GetAxis("Vertical") * donmeHizi;
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
			if (puan >= 3)
			{
				panel.SetActive(true);
				Time.timeScale = 0.0f;
			}
		}
	}
}
