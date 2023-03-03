using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Color = System.Drawing.Color;
using Random = UnityEngine.Random;

public class TaskSelection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _dalleImage;
    [SerializeField] private CheckHit _checkHit;
    
    public bool _isCountDown { get; private set; }
    public string tempName { get ; private set; }
    public Sprite tempSprite { get; private set; }
    
    private IReadOnlyList<Sprite> _sprites = new List<Sprite>();
    private  List<String> _spritesNames = new List<string>();
    private List<Sprite> _tempDalleSprites = new List<Sprite>();
    private TextMeshPro _textName;
    private bool isDalleImage = false;
    private int _waitingTime = 5;
    
   
    [UsedImplicitly]
    public void SearchObject()
    {
        StartCoroutine(CountDown());
    }

    public void ListNameClear()
    {
        
        _spritesNames?.Clear();
        _tempDalleSprites?.Clear();
        
    }

    private int GetRandomName()
    {
      return  Random.Range(0,_sprites.Count);
    }
    public void Initialize(IReadOnlyList<Sprite> sprites)
    {
        _sprites = sprites;
    }

    [UsedImplicitly]
    public void ShowDalleImage()
    {
        isDalleImage = true;
    }
    public IEnumerator  CountDown()
    {
        if (_dalleImage.sprite != null)
        {
            _dalleImage.sprite = null;
        }
        _isCountDown = true;
        var tempTime = _waitingTime;
        while (tempTime > 0)
        {

            _text.text = tempTime.ToString();
        
            yield return new WaitForSeconds(1f); 
        
            tempTime--; 
        }
        _text.text = "GO!";
        yield return new WaitForSeconds(2f);
        
        var randomIndex = GetRandomName();
        Debug.Log(_spritesNames.Count);
        tempSprite = _sprites[randomIndex];
        tempName = _sprites[randomIndex].name;

        while (_tempDalleSprites.Contains(tempSprite))
        {
            randomIndex = GetRandomName();
            tempName = _sprites[randomIndex].name;
           tempSprite = _sprites[randomIndex];
        }
        _tempDalleSprites.Add(tempSprite);
        _spritesNames.Add(tempName);
       
        UnityEngine.Color tempColor = Random.ColorHSV();
        _text.color = tempColor;
        _text.text = "Find "+ tempName;
        _dalleImage.sprite = tempSprite;
        if (isDalleImage)
        { 
            _dalleImage.enabled = true;
            _dalleImage.sprite = tempSprite;
            //_checkHit.Initialize(_dalleImage.sprite);
        }
        
        _isCountDown = false;
    }
}
