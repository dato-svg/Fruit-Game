using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FruitSpawner : MonoBehaviour, IFruitSpawner
{
    [FormerlySerializedAs("FruitPrefabs")] [FormerlySerializedAs("eggPrefabs")] [SerializeField] private GameObject[] fruitPrefabs;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Image timerImg;
    [SerializeField] private ShowSpawnIcon showSpawnIcon;

    private IRandomNumberGenerator _randomNumberGenerator;
    private bool _canSpawn = true;

    private int _currentIndex;
    private int _nextIndex;

    private void Start()
    {
        _randomNumberGenerator = new UnityRandomNumberGenerator();
        _currentIndex = _randomNumberGenerator.Generate(fruitPrefabs.Length);
        _nextIndex = _randomNumberGenerator.Generate(fruitPrefabs.Length);
        UpdateNextSpawnIcon();
    }

    
    
    private void UpdateNextSpawnIcon()
    {
        showSpawnIcon.UpdateIcon(fruitPrefabs[_currentIndex]);
    }
    
    public void SpawnFruit()
    {
        Instantiate(fruitPrefabs[_currentIndex], transform.position, Quaternion.identity);
        _currentIndex = _nextIndex;
        _nextIndex = _randomNumberGenerator.Generate(fruitPrefabs.Length);
        UpdateNextSpawnIcon();
    }

    public void OnSpawnButtonClicked()
    {
        if (_canSpawn)
        {
            StartCoroutine(SpawnFruitWithDelay(spawnDelay));
        }
    }

    public IEnumerator SpawnFruitWithDelay(float spawnDelay)
    {
        _canSpawn = false;
        SpawnFruit();
        timerImg.gameObject.SetActive(true);

        float elapsedTime = 0f;

        while (elapsedTime < spawnDelay)
        {
            elapsedTime += Time.deltaTime;
            timerImg.fillAmount = 1f - (elapsedTime / spawnDelay);
            yield return null;
        }

        timerImg.fillAmount = 1f;
        timerImg.gameObject.SetActive(false);
        _canSpawn = true;
    }

  
}

public interface IFruitSpawner
{
    void SpawnFruit();
    void OnSpawnButtonClicked();
    IEnumerator SpawnFruitWithDelay(float spawnDelay);
}

