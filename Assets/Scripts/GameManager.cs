using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    // Reference the button as whole since it has multiple components: Image, Button, etc.
    public GameObject playButton;
    public GameObject gameOver;
    public TextAlignment sc;
    private int score;

    private void Awake()
    {
        gameOver.SetActive(false);
        // Set framerate to 60
        Application.targetFrameRate = 60;
        // Start the game puased to wait for user input on the button
        Pause();
    }

    public async void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        // Destroy all pipes
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        // Freezing the game. Time is not updating. Thus everything will stop updating 
        // Since our update functions work depending on frames, or deltaTime.
        Time.timeScale = 0;
        // Disable player to prevent checking inputs
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        score ++;
        scoreText.text = score.ToString();
    }
}
