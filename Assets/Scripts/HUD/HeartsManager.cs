using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;



public class HeartsManager : MonoBehaviour
{
    private List<GameObject> _heartObjects = new List<GameObject>();
    private float _xCoord = -0.5f;
    private float _yCoord = 2.9f;

    public GameObject FullHeartPrefab;
    
    public GameObject HalfHeartPrefab;
    
    private GameObject _initHeart, _oldHeart, _newHeart;
    private int _floorDmg;
    
    private enum _heartTypes {FullHeart, HalfHeart};
    private List<_heartTypes> _heartStates = new List<_heartTypes>();
    
    void Awake ()
    {
        MessageManager.Instance.damageMessenger.Subscribe(DamageLink);
        //MessageManager.Instance.healMessenger.subscribe(HealLink); Deprecated
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i = 0; i < 3; i ++) {
            _initHeart = Instantiate(FullHeartPrefab, new Vector3(_xCoord, _yCoord, 0.0f), Quaternion.identity, this.transform);
            _heartObjects.Add(_initHeart);
            _heartStates.Add(_heartTypes.FullHeart);
            _xCoord += 1.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DamageLink(DamageMessage m)
    {
        float dmg = m.DmgAmount;
        if (dmg >= HealthCounter())
        {
            _heartObjects = new List<GameObject>();
            _heartStates = new List<_heartTypes>();
            SignalGameOver();
        }
        else {
            int _heartObjectsLen = _heartObjects.Count;
            if (_heartStates[_heartStates.Count - 1] == _heartTypes.FullHeart)
            {
                _floorDmg = (int)Math.Floor(dmg);
                for (int pos = _heartObjects.Count - 1; pos >= _heartObjectsLen - _floorDmg; pos --)
                {
                    Debug.Log(pos);
                    _oldHeart = _heartObjects[pos];
                    _heartObjects.RemoveAt(pos);
                    _heartStates.RemoveAt(pos);
                    DestroyImmediate(_oldHeart);
                }
                if (dmg - _floorDmg == 0.5) // Half-heart calculations
                {
                    _oldHeart = _heartObjects[_heartObjects.Count - 1];
                    _newHeart = Instantiate(HalfHeartPrefab, _oldHeart.transform.position, Quaternion.identity, this.transform);
                    _heartObjects[_heartObjects.Count - 1] = _newHeart;
                    _heartStates[_heartStates.Count - 1] = _heartTypes.HalfHeart;
                    DestroyImmediate(_oldHeart);
                }
            }
            else
            {
                _floorDmg = (int)Math.Floor(dmg);
                for (int pos = _heartObjects.Count - 1; pos >= _heartObjectsLen - _floorDmg; pos --)
                {
                    _oldHeart = _heartObjects[pos];
                    _heartObjects.RemoveAt(pos);
                    _heartStates.RemoveAt(pos);
                    DestroyImmediate(_oldHeart);
                }
                if (dmg - _floorDmg == 0.5) // Half-heart calculations
                {
                    _oldHeart = _heartObjects[_heartObjects.Count - 1];
                    _heartObjects.RemoveAt(_heartObjects.Count - 1);
                    _heartStates.RemoveAt(_heartStates.Count - 1);
                    DestroyImmediate(_oldHeart);
                }
                else
                {
                    _oldHeart = _heartObjects[_heartObjects.Count - 1];
                    _newHeart = Instantiate(HalfHeartPrefab, _oldHeart.transform.position, Quaternion.identity, this.transform);
                    _heartObjects[_heartObjects.Count - 1] = _newHeart;
                    _heartStates[_heartStates.Count - 1] = _heartTypes.HalfHeart;
                    DestroyImmediate(_oldHeart);
                }
            }
        }
    }
    
    public void SignalGameOver()
    {
        MessageManager.Instance.deathMessenger.SendMessage(new DeathMessage());
        InitHearts();
        Debug.Log("Game Over!");
    }
    
    //Utils (& for testing purposes)
    public int GetHeartObjectsCount ()
    {
        return _heartObjects.Count;
    }
    
    public int GetHeartStatesCount ()
    {
        return _heartStates.Count;
    }
  
    public float HealthCounter ()
    {
        float totalHealth = 0.0f;
        foreach (_heartTypes heart in _heartStates)
        {
            if (heart == _heartTypes.FullHeart)
            {
                totalHealth ++;
            }
            else
            {
                totalHealth += 0.5f;
            }
        }
        return totalHealth;
    }
}
