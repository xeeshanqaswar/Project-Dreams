using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Practise
{
    public class InputManager : MonoBehaviour
    {

        public float horizontal;
        public float vertical;
        public float mouse1;
        public float mouse2;
        public float fire3;
        public float middleMouse;
        public float mouseX;
        public float mouseY;

        [HideInInspector] public FreeCameraLook camProperties;
        [HideInInspector] public Transform camPivot;
        [HideInInspector] public Transform camTrans;

        CrosshairManager crosshairManager;
        ShakeCamera shakeCam;
        StateManager state;

        public float nomralFov = 60f;
        public float aimingFov = 60f;
        float targetFov;
        float curFov;

        public float cameraNormalZ = -2f;
        public float cameraAimingZ = -0.86f;
        float targetZ;
        float actualZ;
        float curZ;

        LayerMask layerMask;

        private void Start()
        {
            
            crosshairManager = CrosshairManager.GetInstance();
            camProperties = FreeCameraLook.GetInstance();
            camPivot = camProperties.transform.GetChild(0);
            camTrans = camPivot.GetChild(0);
            shakeCam = camPivot.GetComponent<ShakeCamera>();

            state = GetComponent<StateManager>();

            layerMask = ~(1 << gameObject.layer);
            state.layer = layerMask;
        }

        private void FixedUpdate()
        {
            HandleInput();
            UpdateState();
            HandleShake();
        }

        private void HandleShake()
        {
        }

        private void UpdateState()
        {
            state.aiming = state.onGround && (mouse2 > 0f);
            state.canRun = !state.aiming;
            state.walk = state.onGround && (fire3 > 0);

            state.horizontal = horizontal;
            state.vertical = vertical;

            if (state.aiming)
            {
                targetZ = cameraAimingZ;
                targetFov = aimingFov;

                state.shoot = mouse1 > 0.5f && !state.reloading; // Do shooting
            }
            else
            {
                state.shoot = false;
                targetFov = nomralFov;
                targetZ = cameraNormalZ;
            }
        }

        private void HandleInput()
        {
            // fire3 == left stick
        }
    }
}
