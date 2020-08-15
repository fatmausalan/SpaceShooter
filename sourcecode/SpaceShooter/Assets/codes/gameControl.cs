using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameControl : MonoBehaviour
{
    public GameObject Asteroid;
    public Vector3 randomPos;
    public float startWait;
    public float asteroidFirtWait;
    public float asteroidSecondWait;
    public Text text;
    bool gameOverControl = false;
    bool retryGame = false;
    public Text gameoverText;

    int score;
    void Start()
    {
        score = 0;
        text.text = "" + score;
        StartCoroutine(create());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && retryGame)
        {
            SceneManager.LoadScene("level1");
        }
    }

    IEnumerator create()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(asteroidFirtWait);
            }
            yield return new WaitForSeconds(asteroidSecondWait);
            if (gameOverControl)
            {
                retryGame = true;
                break;
            }
        } 
    }

    public void scoreIncrease(int comingScore)
    {
        score += comingScore;
        text.text = "" + score;
    }
    
    public void gameOver()
    {
        gameoverText.text = "GAME OVER";
        gameOverControl = true;
    }
}