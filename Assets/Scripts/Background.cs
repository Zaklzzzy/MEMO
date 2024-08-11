using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private Sprite[] _backgrounds;
    private Image _backgroundImage;

    private void Awake()
    {
        _backgroundImage = gameObject.GetComponent<Image>();
        _backgroundImage.sprite = _backgrounds[Random.Range(0, _backgrounds.Length)];
    }
}
