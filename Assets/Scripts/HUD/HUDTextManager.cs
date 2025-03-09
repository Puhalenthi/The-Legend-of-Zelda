using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDTextManager : MonoBehaviour
{
    private int bombCount = 5;
    private int rupeeCount = 0;
    
    [SerializeField]
    private TextMeshProUGUI bombText;
    
    [SerializeField]
    private TextMeshProUGUI rupeeText;
    // Start is called before the first frame update
    void Awake()
    {
        MessageManager.Instance.bombMessenger.Subscribe(useBomb);
        MessageManager.Instance.rupeeMessenger.Subscribe(collectRupee);
    }
    void Start()
    {
        bombText.text = "5";
        rupeeText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void useBomb (Message m)
    {
        if (bombCount > 0)
        {
            bombCount --;
            bombText.text = bombCount.ToString();            
        }
    }
    
    void collectRupee (Message m)
    {
        rupeeCount ++;
        rupeeText.text = rupeeCount.ToString();
    }
}
