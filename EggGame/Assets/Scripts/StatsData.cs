using TMPro;
using UnityEngine;

public class StatsData : MonoBehaviour
{
    public static int Score;
    public static int MaxScore;
    [SerializeField] private static TextMeshProUGUI scoreTXT;

    private void Start()
    {
        Initialize();
        ShowScore();
    }

    private void Initialize()
    {
        scoreTXT = GameObject.Find("CountFruitTXT").GetComponent<TextMeshProUGUI>();
        Score = 0;
    }
    


    public static void ShowScore()
    {
        scoreTXT.text = Score.ToString();
    }

    public static void AddScore(int count)
    {
        Score += count;
        ShowScore();
    }
    
    
}

