using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BoarShroom.WeltonKingGameJam
{
    public class Projectile : MonoBehaviour
    {
        public float normalSpeed;
        public float slowmoSpeed;
        public float actualSpeed;
        public bool enemyBullet;

        public bool slowmo;

        GameObject manager;

        GameObject camera;

        void Start()
        {
            manager = GameObject.FindGameObjectWithTag("Manager");
            camera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        void Update()
        {
            if (slowmo)
            {
                actualSpeed = slowmoSpeed;
            }
            else
            {
                actualSpeed = normalSpeed;
            }

            transform.Translate(Vector2.up * actualSpeed * Time.deltaTime);
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.tag == "Obstacles")
            {
                Destroy(this.gameObject);
            }
            else if(col.gameObject.tag == "Enemy" && !enemyBullet)
            {
                //col.gameObject.GetComponent<Enemy>().StartCoroutine("particleStart");
                manager.GetComponent<AudioSource>().Play();
                camera.GetComponent<Animator>().SetTrigger("shake");
                manager.GetComponent<Manager>().Kill();
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
            else if(col.gameObject.tag == "Player" && enemyBullet)
            {
                manager.GetComponent<Manager>().EndGame();
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
            else if(col.gameObject.tag == "Bullet")
            {
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
