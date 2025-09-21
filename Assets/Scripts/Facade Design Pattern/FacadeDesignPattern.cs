using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.FacadeDesingPatterns
{
    public class FacadeDesignPattern : MonoBehaviour
    {
        GameStartupManager gameStartupManager = new GameStartupManager();


        void Awake()
        {
            gameStartupManager.StartGame();
        }
    }


    public class UISetup
    {
        public void InitUI() => Debug.Log("UI Başlatıldı.");
    }

    public class AudioSetup
    {
        public void InitAudio() => Debug.Log("Audio Sistemi Başlatıldı.");
    }

    public class PlayerSetup
    {
        public void SpawnPlayer() => Debug.Log("Oyuncu Spawn Edildi.");
    }

    public class InputSetup
    {
        public void EnableInput() => Debug.Log("Input Sistemi Aktif.");
    }

    public class GameStartupManager
    {
        private UISetup ui = new UISetup();
        private AudioSetup audio = new AudioSetup();
        private PlayerSetup player = new PlayerSetup();
        private InputSetup input = new InputSetup();

        public void StartGame()
        {
            ui.InitUI();
            audio.InitAudio();
            player.SpawnPlayer();
            input.EnableInput();

            Debug.Log("Oyun Başladı!");
        }
    }


}
