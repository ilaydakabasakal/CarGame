using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
public void PlayButton()
	{
		SceneManager.LoadScene(0);
	}
	public void ControllsButton()
	{
		SceneManager.LoadScene(5);
	}
	public void AboutButton()
	{
		SceneManager.LoadScene(4);
	}
	public void GeriButton()
	{
		SceneManager.LoadScene(3);
	}
	public void QuitButton()
	{
		// Kullan�c�ya ��k�� yapmak isteyip istemedi�ini sormak i�in bir pencere a��l�r
		// E�er kullan�c� Evet (true) derse, uygulama kapat�l�r
		// �stemiyorsa (false), i�lem iptal edilir
		if (UnityEngine.Application.isEditor)
		{
			UnityEditor.EditorApplication.isPlaying = false;
		}
		else
		{
			// Ger�ek uygulamada, kullan�c�ya bir onay mesaj� g�sterilir
			// Onayland���nda uygulama kapat�l�r
			// E�er bir webgl oyunu ise bu k�s�m �al��maz
			UnityEngine.Application.Quit();
		}
	}
	}
