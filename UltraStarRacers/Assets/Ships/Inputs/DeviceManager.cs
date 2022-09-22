using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Ship.Controls
{
    public class DeviceManager : MonoBehaviour
    {
        static public DeviceManager Instance;

        public UnityEngine.InputSystem.PlayerInputManager InputManager;

        public PlayerInput TopPlayer;
        public PlayerInput BottomPlayer;

        public UnityEvent<PlayerInput> OnTopPlayer;
        public UnityEvent<PlayerInput> OnBottomPlayer;
        
        private void Start()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public void OnAddPlayer(PlayerInput player)
        {
            DontDestroyOnLoad(player.gameObject);
            if (TopPlayer == null)
            {
                TopPlayer = player;
                OnTopPlayer?.Invoke(player);
            }
            else if (BottomPlayer == null)
            {
                BottomPlayer = player;
                OnBottomPlayer?.Invoke(player);
            }

            player.transform.parent = transform;
        }

        public void OnRemovePlayer(PlayerInput player)
        {
            //if (TopPlayer == player)
            //{
            //    TopPlayer = null;
            //    OnTopPlayer?.Invoke(null);
            //}
            //
            //if (BottomPlayer == player)
            //{
            //    BottomPlayer = null;
            //    OnBottomPlayer?.Invoke(null);
            //}
        }

        public void RemovePlayer(bool isTopPlayer)
        {
            if (isTopPlayer)
            {
                if (TopPlayer != null)
                {
                    InputManager.playerLeftEvent.Invoke(TopPlayer);
                    TopPlayer = null;
                    OnTopPlayer?.Invoke(null);
                }
            }
            else
            {
                if (BottomPlayer != null)
                {
                    InputManager.playerLeftEvent.Invoke(BottomPlayer);
                    TopPlayer = null;
                    OnBottomPlayer?.Invoke(null);
                }
            }
        }
    }
}
