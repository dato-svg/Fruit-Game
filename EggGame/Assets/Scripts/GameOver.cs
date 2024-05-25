using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameOver : MonoBehaviour
{
  [FormerlySerializedAs("OverPanel")] [SerializeField] private GameObject overPanel;
  [FormerlySerializedAs("SpawnButton")] [SerializeField] private GameObject spawnButton;
  [SerializeField] private GameObject recordPanel;
  [SerializeField] private TextMeshProUGUI recordText;
  private float _timeLeft;
  private RecordPanel _recordPanel;

  private void Start()
  {
    StatsData.MaxScore = PlayerPrefs.GetInt("MaxScore");
    _recordPanel = new RecordPanel();
  }

  private void OnTriggerStay2D(Collider2D other)
  {
    _timeLeft += Time.deltaTime;
    if (_timeLeft > 2)
    {
    
      if (StatsData.Score > StatsData.MaxScore)
      {
        StatsData.MaxScore = StatsData.Score;
        PlayerPrefs.SetInt("MaxScore",StatsData.MaxScore);
        overPanel.SetActive(true);
        spawnButton.SetActive(false);
        recordPanel.SetActive(true);
        _recordPanel.ShowText(recordText,StatsData.MaxScore);
      }
      else
      {
        overPanel.SetActive(true);
        spawnButton.SetActive(false);
      }
      
    
    }
    
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    _timeLeft = 0;
  }
}
