using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BoarShroom.WeltonKingGameJam
{
    public class Enemy : MonoBehaviour
    {
        public float normalSpeed;
        public float slowmoSpeed;
        public float actualSpeed;
        public Vector2 target;
        public Transform playerPosition;
        public Transform Weapon;
        public Transform ShotPosition;

        public float minX;
        public float maxX;
        public float minY;
        public float maxY;

        public bool slowmo;

        public GameObject projectile;
        public float timeBtwShots;
        float shotTime;

        public GameObject ps;

        void Start()
        {

            target = GetRandomPosition();
            shotTime = timeBtwShots;
        }

        void Update()
        {
            if(GameObject.FindGameObjectWithTag("Player"))
            {
                playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

                Weapon.eulerAngles = new Vector3(0, 0, -Weapon.eulerAngles.z);
                Weapon.LookAt(playerPosition.position, Weapon.up);
                Weapon.Rotate(new Vector3(0, -90, -90), Space.Self);
            }

            if (slowmo)
            {
                actualSpeed = slowmoSpeed;
            }
            else
            {
                actualSpeed = normalSpeed;
            }

            if ((Vector2)transform.position != target)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, actualSpeed * Time.deltaTime);
            }
            else
            {
                target = GetRandomPosition();
            }


            if (shotTime <= 0)
            {
                Instantiate(projectile, ShotPosition.position, Weapon.rotation);
                shotTime = timeBtwShots;
            }
            else
            {
                shotTime -= Time.deltaTime;
            }
        }

        Vector2 GetRandomPosition()
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            return new Vector2(randomX, randomY);
        }

        void OnCollisionStay2D(Collision2D col)
        {
            if(col.gameObject.tag == "Obstacles" )
            {
                target = GetRandomPosition();
            }
        }

        public IEnumerator particleStart()
        {
            Instantiate(ps, transform);
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }
}
