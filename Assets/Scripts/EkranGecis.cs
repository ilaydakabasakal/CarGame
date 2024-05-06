using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EkranGecis : MonoBehaviour
{
    public void GoToNextScene(int sahneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sahneIndex);
        Time.timeScale = 1f;
    }
}
