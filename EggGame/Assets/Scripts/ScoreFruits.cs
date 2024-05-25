using TMPro;
using UnityEngine;

public class ScoreFruits : MonoBehaviour
{
    [HideInInspector] public int ScoreCount;
    [SerializeField] private TextMeshProUGUI scoreCountTxT;
    
    private void Start()
    {
        scoreCountTxT = GetComponent<TextMeshProUGUI>();
        ShowScore();
    }

    public void ShowScore()
    {
        scoreCountTxT.text = ScoreCount.ToString();
    }
}
