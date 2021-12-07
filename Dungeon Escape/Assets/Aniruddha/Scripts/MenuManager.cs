using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject deathUI;
    public GameObject winUI;
    public static MenuManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowDeathUI()
    {
        Invoke("DelayDeath", 2.0f);
    }
    public void ShowWinUI()
    {
        winUI.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
    private void DelayDeath()
    {
        deathUI.SetActive(true);
    }
}
