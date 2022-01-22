using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private GameController _gameController = null;
    [SerializeField] private MainGame _mainGame = null;
    [SerializeField] private TMP_Text _pointsText = null;
    [SerializeField] private Button _upgradePointsButton = null;
    [SerializeField] private Button _upgradePointsPerSecongButton = null;
    [SerializeField] private TMP_Text _upgradePointCostText = null;
    [SerializeField] private TMP_Text _upgradePoiPerSecondText = null;

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    public void OnClose()
    {
        _mainGame.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }


    public void OnUpgradePointsClicked()
    {
        int cost = 10 * _gameController.GetTapLevel();
        int amount = 1;
        _gameController.IncriasePointsPerTap(cost, amount);
        UpdateDisplay();
    }

    public void OnUpgradePointsPerSecondsClicked()
    {
        int cost = 10 * _gameController.GetAutoPointsLevel();
        int amount = 1;
        _gameController.IncreasePointsPerSecond(cost, amount);
        UpdateDisplay();
    }


    public void UpdateDisplay()
    {
        var points = _gameController.GetPoints();
        _pointsText.text = points.ToString();

        int cost = 10 * _gameController.GetTapLevel();
        _upgradePointsButton.interactable = (cost <= points);
        _upgradePointCostText.text = string.Format("({0})", cost.ToString());


        cost = 10 * _gameController.GetAutoPointsLevel();
        _upgradePointsPerSecongButton.interactable = (cost <= points);
        _upgradePoiPerSecondText.text = string.Format("({0})", cost.ToString());
    }
}
