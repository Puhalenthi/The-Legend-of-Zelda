using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;



public class HeartsManager : MonoBehaviour
{
    private List<GameObject> _heartObjects = new List<GameObject>();
    private float _xCoord = -0.5f;
    private float _yCoord = 2.9f;
    
    [SerializeField]
    private GameObject fullHeartPrefab;
    
    [SerializeField]
    private GameObject halfHeartPrefab;
    
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
        for (int i = 0; i < 3; i ++) {
            _initHeart = Instantiate(fullHeartPrefab, new Vector3(_xCoord, _yCoord, 0.0f), Quaternion.identity, this.transform);
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
        if (dmg >= healthCounter())
        {
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
                    Destroy(_oldHeart);
                }
                if (dmg - _floorDmg == 0.5) // Half-heart calculations
                {
                    _oldHeart = _heartObjects[_heartObjects.Count - 1];
                    _newHeart = Instantiate(halfHeartPrefab, _oldHeart.transform.position, Quaternion.identity, this.transform);
                    _heartObjects[_heartObjects.Count - 1] = _newHeart;
                    _heartStates[_heartStates.Count - 1] = _heartTypes.HalfHeart;
                    Destroy(_oldHeart);
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
                    Destroy(_oldHeart);
                }
                if (dmg - _floorDmg == 0.5) // Half-heart calculations
                {
                    _oldHeart = _heartObjects[_heartObjects.Count - 1];
                    _heartObjects.RemoveAt(_heartObjects.Count - 1);
                    _heartStates.RemoveAt(_heartStates.Count - 1);
                    Destroy(_oldHeart);
                }
                else
                {
                    Debug.Log(2);
                    _oldHeart = _heartObjects[_heartObjects.Count - 1];
                    _newHeart = Instantiate(halfHeartPrefab, _oldHeart.transform.position, Quaternion.identity, this.transform);
                    _heartObjects[_heartObjects.Count - 1] = _newHeart;
                    _heartStates[_heartStates.Count - 1] = _heartTypes.HalfHeart;
                    Destroy(_oldHeart);
                }
            }
        }
    }
    
    /*
    public void HealLink(Message m) // Deprecated feature
    {
        if (totalHealth + 1 > 5)
        {
            _oldHeart = _heartObjects[4]; // Topmost heart
            _newHeart = Instantiate(fullHeartPrefab, _oldHeart.transform.position, _oldHeart.transform.rotation);
            _heartObjects[4] = ;
            Destroy(_oldHeart);
            _totalHealth = 5.0f;
        }
        else if (_totalHealth + 1 == (int)(_totalHealth + 1))
        {
            
        }
    */
    
    public float healthCounter ()
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
    
    public void SignalGameOver()
    {
        SceneManager.LoadScene("LoseScene");
        MessageManager.Instance.deathMessenger.SendMessage(new DeathMessage());
        Debug.Log("Game Over!");
    }
}
