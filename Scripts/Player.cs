using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BoarShroom.WeltonKingGameJam
{
    public class Player : MonoBehaviour
    {
        public float speed;
        public Manager manager;

        void Start()
        {
            manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        }

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 moveDir = new Vector2(horizontal, vertical);
            moveDir.Normalize();

            transform.Translate(moveDir * Time.deltaTime * speed, Space.World);

            if(moveDir != Vector2.zero)
            {
                manager.slowmo = false;
            }
            else
            {
                manager.slowmo = true;
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.tag == "Enemy")
            {
                manager.EndGame();
                Destroy(this.gameObject);
            }
        }
    }
}
