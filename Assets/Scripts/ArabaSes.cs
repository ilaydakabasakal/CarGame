using UnityEngine;

public class ArabaSes : MonoBehaviour
{
	public AudioClip motorSesiClip; // Araba motor sesi için ses dosyasý
	private AudioSource motorSesiKaynagi; // Araba motor sesi için ses kaynaðý
	public float minPitch = 0.8f; // Minimum pitch deðeri
	public float maxPitch = 1.2f; // Maksimum pitch deðeri
	public float minVolume = 0.2f; // Minimum ses seviyesi
	public float maxVolume = 0.6f; // Maksimum ses seviyesi

	private Rigidbody arabaRigidbody; // Arabanýn Rigidbody bileþeni

	void Start()
	{
		arabaRigidbody = GetComponent<Rigidbody>();

		// Araba üzerinde yeni bir AudioSource bileþeni oluþtur
		motorSesiKaynagi = gameObject.AddComponent<AudioSource>();
		motorSesiKaynagi.clip = motorSesiClip; // Oluþturulan AudioSource'a motor sesi dosyasýný ata
		motorSesiKaynagi.loop = true; // Sesin döngüsünü baþlat
		motorSesiKaynagi.Play(); // Motor sesini baþlat
	}

	void Update()
	{
		// Arabanýn hýzýna göre motor sesinin pitch ve ses seviyesini ayarla
		float speedPercent = arabaRigidbody.velocity.magnitude / GetComponent<SonARABA>().maxSpeed;
		float pitch = Mathf.Lerp(minPitch, maxPitch, speedPercent);
		float volume = Mathf.Lerp(minVolume, maxVolume, speedPercent);
		motorSesiKaynagi.pitch = pitch;
		motorSesiKaynagi.volume = volume;
	}
}
