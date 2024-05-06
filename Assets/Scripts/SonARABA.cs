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
	public float totalTime = 10f; // Toplam s�re
	public Image geriSayim;
	public TextMeshProUGUI sureText;
	private float simdikiZaman;
	public float maxSpeed = 50f; // Maksimum h�z de�eri
	public GameObject panel;
	public WheelCollider FL_Wheel;
	public WheelCollider FR_Wheel;
	public WheelCollider RL_Wheel;
	public WheelCollider RR_Wheel;
	public float frenGucu = 100f; // Fren g�c�, ne kadar h�zl� fren yap�laca��n� belirler
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
			GetComponent<Rigidbody>().AddForce(Vector3.forward * 100, ForceMode.Force);
		}

		if (oyunBitti == false && Input.GetKey("d")) // d bas�nca sa�a do�ru belli h�zda hareket eder
		{
			GetComponent<Rigidbody>().AddForce(Vector3.right * 50, ForceMode.Force);
		}

		if (oyunBitti == false && Input.GetKey("a")) // a bas�nca sola do�ru belli h�zda hareket eder
		{
			GetComponent<Rigidbody>().AddForce(Vector3.left * 50, ForceMode.Force);
		}

		if (oyunBitti == false && Input.GetKey("s")) // s bas�nca h�z� yava�lar
		{
			// "s" tu�una bas�ld���nda araban�n h�z�n� azalt
			GetComponent<Rigidbody>().AddForce(Vector3.back * 100, ForceMode.Force);
		}
		else if (oyunBitti == true) // e�er oyun bittiyse araba hareket etmez h�z� s�f�rlaan�r 
		{
			Time.timeScale = 0f;
		}
		if (Input.GetKeyDown(KeyCode.Space)) // space tu�una bas�ld���nda
		{
			StartCoroutine(Frenle());
		}

		IEnumerator Frenle()
		{
			while (GetComponent<Rigidbody>().velocity.magnitude > 1f) // Araba h�z� �ok d���k olana kadar devam et
			{
				GetComponent<Rigidbody>().velocity -= GetComponent<Rigidbody>().velocity.normalized * frenGucu * Time.deltaTime;
				yield return null;
			}
			GetComponent<Rigidbody>().velocity = Vector3.zero; // H�z �ok d���kse s�f�rla
		}


		// Maksimum h�z tan�mlanmas�
		float currentSpeed = GetComponent<Rigidbody>().velocity.magnitude;

		if (currentSpeed > maxSpeed)
		{
			GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
		}

		// Tekerlekleri d�nd�rme fonksiyonu �a��rma
		TekerlekleriDondur();
	}
	

	void TekerlekleriDondur()
	{
		// D�nme h�z� tan�mlama
		float donmeHizi = 300f;

		// Input.GetAxis("Horizontal") ile sa�a ve sola d�n�� kontrol�
		float steer = Input.GetAxis("Horizontal") * donmeHizi * Time.deltaTime;

		// Tekerlek d�n��lerini uygulama
		FL_Wheel.steerAngle = steer;
		FR_Wheel.steerAngle = steer;

		// Tekerleklerin d�nmesini sa�lamak i�in g�� uygulama
		// Burada arac�n h�z�n� de�il, tekerleklerin d�n��lerini kontrol etti�imizi unutmay�n
		FL_Wheel.motorTorque = Input.GetAxis("Vertical") * donmeHizi;
		FR_Wheel.motorTorque = Input.GetAxis("Vertical") * donmeHizi;
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
			if (puan >= 3)
			{
				panel.SetActive(true);
				Time.timeScale = 0.0f;
			}
		}
	}
}
