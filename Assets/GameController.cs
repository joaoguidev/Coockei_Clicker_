using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float _pointsUpdateRate = 1.0f;
    private int _totalPoints = 0;
    private int _pointsPerTap = 0;
    private int _pointsPerSecond = 0;
    private int _tapLevel = 0;
    private int _autoPointsLevel = 0;
    private float _timeSinceLastGrant = 0.0f;

    void Start()
    {
    _totalPoints = 0;
    _pointsPerTap = 1;
    _pointsPerSecond = 0;
    _timeSinceLastGrant = 0.0f;
    _tapLevel = 1;
    _autoPointsLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceLastGrant += Time.deltaTime;
        if(_timeSinceLastGrant >= _pointsUpdateRate)
        {
            while(_timeSinceLastGrant > _pointsUpdateRate)
            {
                AddPoints(_pointsPerSecond);
                _timeSinceLastGrant -= _pointsUpdateRate;
            }
        }
    }
    public void AddPoints(int amount)
    {
        _totalPoints += amount;
    }
    public void SubPoints(int amount)
    {
        _totalPoints -= amount;
    }

    public int GetPoints()
    {
        return _totalPoints;
    }

    public int GetTapLevel()
    {
        return _tapLevel;
    }
    public int GetAutoPointsLevel()
    {
        return _autoPointsLevel;
    }
    public void IncriasePointsPerTap(int cost, int amount)
    {
        if(cost <= _totalPoints)
        {
            SubPoints(cost);
            _pointsPerTap += amount;
            ++_tapLevel;
        }
    }
    public void IncreasePointsPerSecond(int cost, int amount)
    {
        if (cost <= _totalPoints)
        {
            SubPoints(cost);
            _pointsPerSecond += amount;
            ++_autoPointsLevel;
        }
       
    }


    public void AddClickPoints()
    {
        AddPoints(_pointsPerTap);

    }
}
