using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeartsManager : MonoBehaviour
{
    private List<GameObject> _heartStack;
    private float _xCoord = 3.25f;
    private float _yCoord = 4.00f;
    
    [SerializeField]
    private GameObject fullHeartPrefab;
    
    [SerializeField]
    private GameObject halfHeartPrefab;
    
    [SerializeField]
    private GameObject emptyHeartPrefab;
    
    private GameObject _initHeart, _oldHeart, _newHeart;
    private float _totalHealth;
    // Start is called before the first frame update
    void Start()
    {
        _heartStack = new List<GameObject>();
        _totalHealth = 3.0f;
        for (int i = 0; i < 3; i ++) {
            _initHeart = Instantiate(fullHeartPrefab, new Vector3(_xCoord, _yCoord, 0.0f), Quaternion.identity);
            Debug.Log("Hello");
            _heartStack.Add(_initHeart);
            _xCoord += 1.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DamageLink(int dmg)
    {
        if (dmg >= _totalHealth)
        {
            SignalGameOver();
        }
        else {
            floor_dmg = Math.Floor(dmg);
            for (int pos = _heartStack.Count - 1; i >= _heartStack.Count - floor_dmg; i --)
            {
                _oldHeart = _heartStack[pos];
                _heartStack.RemoveAt(pos);
                Destroy(_oldHeart);
            }
            if (dmg - floor_dmg == 0.5) // Half-heart calculations
            {
                _oldHeart = _heartStack[_heartStack.Count - 1]
                if (_totalHealth == (int)_totalHealth)
                {
                    _newHeart = Instantiate(halfHeartPrefab, _
                    _heartStack[_heartStack
                }
            }
            _totalHealth -= dmg;
        }
    }
    
    public void HealLink() // One heart at a time
    {
        if (totalHealth + 1 > 5)
        {
            _oldHeart = _heartStack[4]; // Topmost heart
            _newHeart = Instantiate(fullHeartPrefab, _oldHeart.transform.position, _oldHeart.transform.rotation);
            _heartStack[4] = ;
            Destroy(_oldHeart);
            _totalHealth = 5.0f;
        }
        else if (_totalHealth + 1 == (int)(_totalHealth + 1))
        {
            
        }
    }
    
    public void SignalGameOver()
    {
        /// Game Over Screen
        Debug.Log("Game Over!");
    }
}
