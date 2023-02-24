using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
   [SerializeField] public GameObject _nextLevelbutton;
   [SerializeField] private GameController _gameController;
   
   public  int columnsCount;
   public  int elementsСountPerLine;
   public  int startPositionX;
   public  int startPositionY;
   public  int distanceBetweenElements;
   public  int lineSpacing;
   

   public void NextLevelSetting()
   {
      _nextLevelbutton.SetActive(false);
      _gameController._PlayMode.Invoke();
   }
   public  void EasyLevelSettings()
   {
      columnsCount = 1;
      elementsСountPerLine = 3;
      startPositionX = -5;
      startPositionY = 0;
      distanceBetweenElements = 5;
      lineSpacing = 0;
   }
   public  void MediumLevelSettings()
   {
      columnsCount = 2;
      elementsСountPerLine = 3;
      startPositionX = -5;
      startPositionY = 2;
      distanceBetweenElements = 5;
      lineSpacing =3;
   }
   public  void HardLevelSettings()
   {
      columnsCount = 3;
      elementsСountPerLine = 3;
      startPositionX = -4;
      startPositionY = 3;
      distanceBetweenElements = 4;
      lineSpacing = 3;
   }
}
