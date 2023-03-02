using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject afFishPicture;
    [SerializeField] GameObject afFishInformation;
    [SerializeField] GameObject clFishPicture;
    [SerializeField] GameObject clFishInformation;
    [SerializeField] GameObject dfFishPicture;
    [SerializeField] GameObject dfFishInformation;
    [SerializeField] GameObject elFishPicture;
    [SerializeField] GameObject elFishInformation;
    [SerializeField] GameObject wfFishPicture;
    [SerializeField] GameObject wfFishInformation;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ToAngelFish()
    {
        afFishPicture.SetActive(true);
        afFishInformation.SetActive(true);
        clFishPicture.SetActive(false);
        clFishInformation.SetActive(false);
        dfFishPicture.SetActive(false);
        dfFishInformation.SetActive(false);
        elFishPicture.SetActive(false);
        elFishInformation.SetActive(false);
        wfFishPicture.SetActive(false);
        wfFishInformation.SetActive(false);
    }
    public void ToClassyFish()
    {
        afFishPicture.SetActive(false);
        afFishInformation.SetActive(false);
        clFishPicture.SetActive(true);
        clFishInformation.SetActive(true);
        dfFishPicture.SetActive(false);
        dfFishInformation.SetActive(false);
        elFishPicture.SetActive(false);
        elFishInformation.SetActive(false);
        wfFishPicture.SetActive(false);
        wfFishInformation.SetActive(false);
    }
    public void ToDogFish()
    {
        afFishPicture.SetActive(false);
        afFishInformation.SetActive(false);
        clFishPicture.SetActive(false);
        clFishInformation.SetActive(false);
        dfFishPicture.SetActive(true);
        dfFishInformation.SetActive(true);
        elFishPicture.SetActive(false);
        elFishInformation.SetActive(false);
        wfFishPicture.SetActive(false);
        wfFishInformation.SetActive(false);
    }
    public void ToMetallicEel()
    {
        afFishPicture.SetActive(false);
        afFishInformation.SetActive(false);
        clFishPicture.SetActive(false);
        clFishInformation.SetActive(false);
        dfFishPicture.SetActive(false);
        dfFishInformation.SetActive(false);
        elFishPicture.SetActive(true);
        elFishInformation.SetActive(true);
        wfFishPicture.SetActive(false);
        wfFishInformation.SetActive(false);
    }
    public void ToWanderFish()
    {
        afFishPicture.SetActive(false);
        afFishInformation.SetActive(false);
        clFishPicture.SetActive(false);
        clFishInformation.SetActive(false);
        dfFishPicture.SetActive(false);
        dfFishInformation.SetActive(false);
        elFishPicture.SetActive(false);
        elFishInformation.SetActive(false);
        wfFishPicture.SetActive(true);
        wfFishInformation.SetActive(true);
    }
}
