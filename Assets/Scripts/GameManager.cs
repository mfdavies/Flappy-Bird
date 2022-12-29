using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public AudioSource source;
    public AudioClip flapClip;
    public AudioClip pointClip;
    public AudioClip hitClip;
    public UnityEngine.UI.Text gameplayScoreText; 
    public GameObject gameOverCanvas;
    public GameObject gameplayCanvas;
    public GameObject bronzeMedal;
    public GameObject silverMedal;
    public GameObject goldMedal;
    public GameObject platinumMedal;
    public UnityEngine.UI.Text finalScoreText; 

    public static int score = 0;
    [SerializeField] private float moveSpeed = 1;
    public static float currSpeed;
    public static bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        currSpeed = moveSpeed;
        hit = false;
        score = 0;
        gameplayScoreText.text = score.ToString();
        Time.timeScale = 1;
    } // end Start

    public void HitEnviroment()
    {
        currSpeed = 0;
        hit = true;
        PlayHit(); 
    } // end HitEnviroment
    public void GameOver()
    {
        gameplayCanvas.SetActive(false);
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        if (score >= 40) 
        {
            platinumMedal.SetActive(true);
        } else if (score >= 30) 
        {
            goldMedal.SetActive(true);
        } else if (score >= 20) 
        {
            silverMedal.SetActive(true);
        } else if (score >= 10) 
        {
            bronzeMedal.SetActive(true);
        }
        finalScoreText.text = score.ToString();
    } // end GameOver

    public void AddScore()
    {
        source.PlayOneShot(pointClip);
        score++;
        gameplayScoreText.text = score.ToString();
    } // end AddScore

    public void Replay()
    {
        SceneManager.LoadScene("Main Game");
    } // end Replay

    public void PlayFlap()
    {
        source.PlayOneShot(flapClip);
    } // end PlayFlap
    
    public void PlayHit()
    {
        source.PlayOneShot(hitClip);
    } // end PlayHit
} // end class GameManager
