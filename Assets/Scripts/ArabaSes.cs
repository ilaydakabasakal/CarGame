using UnityEngine;

public class ArabaSes : MonoBehaviour
{
	public AudioClip motorSesiClip; // Araba motor sesi i�in ses dosyas�
	private AudioSource motorSesiKaynagi; // Araba motor sesi i�in ses kayna��
	public float minPitch = 0.8f; // Minimum pitch de�eri
	public float maxPitch = 1.2f; // Maksimum pitch de�eri
	public float minVolume = 0.2f; // Minimum ses seviyesi
	public float maxVolume = 0.6f; // Maksimum ses seviyesi

	private Rigidbody arabaRigidbody; // Araban�n Rigidbody bile�eni

	void Start()
	{
		arabaRigidbody = GetComponent<Rigidbody>();

		// Araba �zerinde yeni bir AudioSource bile�eni olu�tur
		motorSesiKaynagi = gameObject.AddComponent<AudioSource>();
		motorSesiKaynagi.clip = motorSesiClip; // Olu�turulan AudioSource'a motor sesi dosyas�n� ata
		motorSesiKaynagi.loop = true; // Sesin d�ng�s�n� ba�lat
		motorSesiKaynagi.Play(); // Motor sesini ba�lat
	}

	void Update()
	{
		// Araban�n h�z�na g�re motor sesinin pitch ve ses seviyesini ayarla
		float speedPercent = arabaRigidbody.velocity.magnitude / GetComponent<SonARABA>().maxSpeed;
		float pitch = Mathf.Lerp(minPitch, maxPitch, speedPercent);
		float volume = Mathf.Lerp(minVolume, maxVolume, speedPercent);
		motorSesiKaynagi.pitch = pitch;
		motorSesiKaynagi.volume = volume;
	}
}
