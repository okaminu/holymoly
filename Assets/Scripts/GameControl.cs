using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public GameObject gameOverText;
	public bool gameOver = false;
	public float scrollSpeed = -1.5f;
    public Text scoreText;
    public bool esc = false;

    private int score = 0;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == true && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
        
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void MoreScored()
    {
        if (gameOver)
            {
            return;
            }
        score++;
        scoreText.text = "score: " + score.ToString();
    }

	public void BirdDied() {
		gameOverText.SetActive(true);
        gameOver = true;
    }



}
