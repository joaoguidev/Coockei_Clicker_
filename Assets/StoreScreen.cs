using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreScreen : MonoBehaviour
{
    [SerializeField] private GameController _gameController = null;
    [SerializeField] private MainGame _mainGame = null;
    [SerializeField] private TMP_Text _pointsText = null;

    void Update()
    {
        UpdatePoints();
    }

    public void OnClose()
    {
        _mainGame.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void UpdatePoints()
    {
        var points = _gameController.GetPoints();
        _pointsText.text = points.ToString();
    }

    public void OnClickButton(int buttonIndex)
    {
        Debug.Log("Pressed Store Button " + buttonIndex);
    
    }
}
