using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BoarShroom.WeltonKingGameJam
{
    public class Weapon : MonoBehaviour
    {
        public GameObject projectile;
        public float timeBtwShots;
        float shotTime;

        public Transform shotPosition;

        void Update()
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
            transform.rotation = rotation;

            if(Input.GetMouseButton(0))
            {
                if(Time.time >= shotTime)
                {
                    Instantiate(projectile, shotPosition.position, transform.rotation);
                    shotTime = Time.time + timeBtwShots;
                }
            }
        }
    }
}
