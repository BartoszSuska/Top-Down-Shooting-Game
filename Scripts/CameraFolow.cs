using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BoarShroom.WeltonKingGameJam
{
    public class CameraFolow : MonoBehaviour
    {
        public Transform playerTransform;
        public float speed;

        public float minX;
        public float maxX;
        public float minY;
        public float maxY;

        void Start()
        {
            transform.position = playerTransform.position;
        }

        void Update()
        {
            if(playerTransform != null)
            {
                float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
                float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);

                transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
            }
        }
    }
}
