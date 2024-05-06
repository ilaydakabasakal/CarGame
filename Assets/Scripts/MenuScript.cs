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
		// Kullanýcýya çýkýþ yapmak isteyip istemediðini sormak için bir pencere açýlýr
		// Eðer kullanýcý Evet (true) derse, uygulama kapatýlýr
		// Ýstemiyorsa (false), iþlem iptal edilir
		if (UnityEngine.Application.isEditor)
		{
			UnityEditor.EditorApplication.isPlaying = false;
		}
		else
		{
			// Gerçek uygulamada, kullanýcýya bir onay mesajý gösterilir
			// Onaylandýðýnda uygulama kapatýlýr
			// Eðer bir webgl oyunu ise bu kýsým çalýþmaz
			UnityEngine.Application.Quit();
		}
	}
	}
