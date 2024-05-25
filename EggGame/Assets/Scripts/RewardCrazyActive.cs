using UnityEngine;
using CrazyGames;
using UnityEngine.SceneManagement;

public class RewardCrazyActive : MonoBehaviour
{
    private void Start()
    {
        CrazySDK.Init(() => { /** initialization finished callback */ });
    }

    public void ActiveRew()
    {
        CrazySDK.Ad.RequestAd(CrazyAdType.Midgame, () =>
        {
            /** ad started */
        }, (error) =>
        {
            RestartGame();
        }, () =>
        {
            RestartGame();
        });
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
