using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class FruitDetected : MonoBehaviour
{
    [SerializeField] private int ID;
    [FormerlySerializedAs("eggs")] [SerializeField] private GameObject[] fruits;
    [SerializeField] private int ScoreCountGive;
    [SerializeField] private GameObject fruitScoreObj;
    private IRandomNumberGenerator _randomNumberGenerator;
    [SerializeField] private AudioSource audioSource;
    private int _randomEuler;
    private void Start()
    {
        _randomNumberGenerator = new UnityRandomNumberGenerator();
        _randomEuler = _randomNumberGenerator.Generate(30);
        audioSource = GameObject.Find("SellectFruit").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<FruitDetected>() != null)
        {
            if (gameObject.GetComponent<FruitDetected>().ID == other.transform.GetComponent<FruitDetected>().ID)
            {
                audioSource.Play();
                if (ID < 7)
                {
                    StatsData.AddScore(ScoreCountGive);
                    Destroy(gameObject);
                    Destroy(other.gameObject);
                    GameObject fruit = Instantiate(fruits[++ID],gameObject.transform.position
                        ,Quaternion.Euler(transform.position.x
                            ,transform.position.y,transform.position.z),null);

                    GameObject fruitScore = Instantiate(fruitScoreObj, fruit.transform.position, quaternion.Euler(0,0,_randomEuler),GameObject.Find("GameCanvas").transform);
                    fruitScore.GetComponent<ScoreFruits>().ScoreCount = ScoreCountGive;
                    fruitScore.GetComponent<ScoreFruits>().ShowScore();
                }
                else
                {
                    Destroy(gameObject);
                    Destroy(other.gameObject); 
                    StatsData.AddScore(ScoreCountGive);
                    GameObject fruitScore = Instantiate(fruitScoreObj, transform.position, quaternion.Euler(0,0,_randomEuler),GameObject.Find("GameCanvas").transform);
                    fruitScore.GetComponent<ScoreFruits>().ScoreCount = ScoreCountGive;
                    fruitScore.GetComponent<ScoreFruits>().ShowScore();
                }
               
            } 
        }
       

       
    }
}
