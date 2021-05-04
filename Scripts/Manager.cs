using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Com.BoarShroom.WeltonKingGameJam
{
    public class Manager : MonoBehaviour
    {
        public GameObject[] enemies;
        public GameObject[] bullet;
        public bool slowmo;

        public int score;
        public GameObject[] spawners;
        public GameObject enemy;

        public GameObject[] Obstacles;

        public TMP_Text scoreText;

        public GameObject endGameScreen;
        public TMP_Text highscoreText;

        void Start()
        {
            Instantiate(enemy, spawners[Random.Range(0, spawners.Length)].transform);

        }

        void Update()
        {
            scoreText.text = score.ToString();

            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            for(int i = 0; i < enemies.Length; i++)
            {
                if(slowmo)
                {
                    enemies[i].GetComponent<Enemy>().slowmo = true;
                }
                else
                {
                    enemies[i].GetComponent<Enemy>().slowmo = false;
                }
            }

            bullet = GameObject.FindGameObjectsWithTag("Bullet");

            for (int i = 0; i < bullet.Length; i++)
            {
                if (slowmo)
                {
                    bullet[i].GetComponent<Projectile>().slowmo = true;
                }
                else
                {
                    bullet[i].GetComponent<Projectile>().slowmo = false;
                }
            }
        }

        public void Kill()
        {
            score++;
            for (int i = 0; i < Obstacles.Length; i++)
            {
                Obstacle obs = Obstacles[i].GetComponent<Obstacle>();
                if(obs.behaviour == 0 || obs.behaviour == 2)
                {
                    int random = Random.Range(0, 2);
                    obs.behaviour = random;
                }
                else if(obs.behaviour == 1)
                {
                    obs.behaviour = 2;
                }
            }
            Instantiate(enemy, spawners[Random.Range(0, spawners.Length)].transform);
            Instantiate(enemy, spawners[Random.Range(0, spawners.Length)].transform);

        }

        public void EndGame()
        {
            if(score > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", score);
            }

            highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();

            endGameScreen.SetActive(true);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}
