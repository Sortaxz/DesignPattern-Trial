using UnityEngine;

namespace FactoryDesignPatterns
{

    #region Example_1

    // Adım 1: Karmaşık Alt Sistemler (Örnek: Bir oyunun başlama süreci)
    public class AssetLoader { public void LoadAssets() => Debug.Log("Grafikler ve sesler hafızaya yüklendi."); }
    public class SaveSystem { public void LoadSaveGame() => Debug.Log("Kayıtlı dosya okundu, oyuncu konumu alındı."); }
    public class NetworkManager { public void ConnectToServer() => Debug.Log("Sunucuya bağlanıldı. Çok oyunculu mod aktif."); }

    // Adım 2: FACADE Sınıfı (Ön Cephe)
    // Bütün o karmaşayı tek bir arayüzün arkasına gizliyoruz.
    public class GameLoopFacade
    {
        private readonly AssetLoader _assetLoader;
        private readonly SaveSystem _saveSystem;
        private readonly NetworkManager _networkManager;

        public GameLoopFacade()
        {
            _assetLoader = new AssetLoader();
            _saveSystem = new SaveSystem();
            _networkManager = new NetworkManager();
        }

        // İstemcinin çağıracağı tek, tertemiz metot:
        public void StartGame()
        {
            Debug.Log("Oyun başlatılıyor... Lütfen bekleyin...");
            _assetLoader.LoadAssets();
            _saveSystem.LoadSaveGame();
            _networkManager.ConnectToServer();
            Debug.Log("Oyun başarıyla başladı! İyi eğlenceler.");
        }
    }

    #endregion

    #region  Example_2


    public class PlayerAnimationManager : MonoBehaviour
    {
        public void PlayDeathAnimation() => Debug.Log("1. Ölüm animasyonu oynatıldı.");
    }

    public class AudioManager : MonoBehaviour
    {
        public void PlayDeathSound() => Debug.Log("2. Ölüm sesi çalındı.");
    }

    public class UIManager : MonoBehaviour
    {
        public void ShowGameOverUI() => Debug.Log("3. Game Over paneli ekrana getirildi.");
    }

    public class ScoreManager : MonoBehaviour
    {
        public void SaveScore() => Debug.Log("4. Skor kaydedildi.");
    }

    public class GameOverFacade : MonoBehaviour
    {

        [SerializeField]
        private PlayerAnimationManager playerAnimationManager;

        [SerializeField]
        private AudioManager audioManager;

        [SerializeField]
        private UIManager uIManager;

        [SerializeField]
        private ScoreManager scoreManager;

        public void GameOver()
        {
            playerAnimationManager.PlayDeathAnimation();
            audioManager.PlayDeathSound();
            uIManager.ShowGameOverUI();
            scoreManager.SaveScore();
        }

    }


    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private GameOverFacade gameOverFacade;
        private int currentHealth = 100;

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // 4 farklı sistemle uğraşmıyoruz, tek tuşla işi bitiriyoruz!
            gameOverFacade.GameOver();
        }
    }

    #endregion

}