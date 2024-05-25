using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowSpawnIcon : MonoBehaviour
{
    [SerializeField] private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void UpdateIcon(GameObject nextPrefab)
    {
        Sprite newSprite = nextPrefab.GetComponent<SpriteRenderer>().sprite;
        if (newSprite != null)
        {
            image.sprite = newSprite;
        }
        else
        {
            Debug.LogWarning("The prefab does not have a SpriteRenderer or its sprite is null.");
        }
    }
    
}
