using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGame : MonoBehaviour
{
    [SerializeField] private GameController _gameController = null;
    [SerializeField] private StoreScreen _storeScreen = null;
    [SerializeField] private UpgradeScreen _upgradeScreen = null;
    [SerializeField] private TMP_Text _pointsText = null;

    void Start()
    {
        UpdatePoints();

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePoints();
    }

    public void OnTapCookie()
    {
        _gameController.AddClickPoints();
        UpdatePoints();
    }

    public void OnClickUpgrade()
    {
        _upgradeScreen.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

    }

    public void OnClickStore()
    {
        _storeScreen.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void UpdatePoints()
    {
        var points = _gameController.GetPoints();
        _pointsText.text = points.ToString();
    }

}
