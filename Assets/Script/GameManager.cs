using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    private Player player;
    private Parallax[] parallaxs;
    public int score;
    public TMP_Text scoreText;
    public GameObject gameOverImage;
    public GameObject gameStartImage;
    public GameObject scoreObject;
    public GameObject playButton;


    private void Awake() {
        Application.targetFrameRate = 60;
    }

    private void Start() {
        player = FindObjectOfType<Player>();
        parallaxs = FindObjectsOfType<Parallax>();
        gameStartImage.SetActive(true);
        Pause();
    }

    
    public void Pause() {
        player.enabled = false;
        Time.timeScale = 0f;
        for (int i = 0; i < parallaxs.Length; i++) {
            parallaxs[i].enabled = false;
        }
    }

    public void GameOver() {
        gameOverImage.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void Play() {
        Time.timeScale = 1f;
        scoreObject.SetActive(true);
        gameOverImage.SetActive(false);
        gameStartImage.SetActive(false);
        playButton.SetActive(false);
        score = 0;
        scoreText.text = score.ToString();
        player.enabled = true;
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
        
        for (int i = 0; i < parallaxs.Length; i++) {
            parallaxs[i].enabled = true;
        }
    }
    
    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }
}
