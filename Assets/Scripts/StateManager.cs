using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Practise
{
    public class StateManager : MonoBehaviour
    {

        public bool aiming;
        public bool canRun;
        public bool walk;
        public bool shoot;
        public bool reloading;
        public bool onGround;

        public float horizontal;
        public float vertical;
        public Vector3 lookPosition;
        public Vector3 lookHitPosition;
        public LayerMask layer;

        //public CharacterAudioManager audioManager;
        //public HandleShooting handleShooting;
        //public HandleAnimation handleAnim;

        private void Awake()
        {
            
        }

        private void FixedUpdate()
        {
            onGround = IsOnGround();
        }

        private bool IsOnGround()
        {
            Vector3 origin = transform.position + new Vector3(0f,0.05f,0f);
            return Physics.Raycast(origin, -Vector3.up, layer);
        }



    }
}
