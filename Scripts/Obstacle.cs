using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BoarShroom.WeltonKingGameJam
{
    public class Obstacle : MonoBehaviour
    {
        public int behaviour; //0 = down/1 = light/ 2 = all
        public GameObject sprite;
        public GameObject light2D;

        void Update()
        {
            if(behaviour == 0)
            {
                light2D.SetActive(false);
                sprite.SetActive(false);
            }
            else if(behaviour == 1)
            {
                light2D.SetActive(true);
                sprite.SetActive(false);
            }
            else if(behaviour == 2)
            {
                sprite.SetActive(true);
                light2D.SetActive(true);
            }
        }
    }
}
