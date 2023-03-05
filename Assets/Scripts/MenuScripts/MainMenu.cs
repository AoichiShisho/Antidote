using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Play").GetComponent<Button>().onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Main"));
        GameObject.Find("Quit").GetComponent<Button>().onClick.AddListener(Application.Quit);
    }
}
