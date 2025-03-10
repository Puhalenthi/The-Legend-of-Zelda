using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDTextManager : MonoBehaviour
{
    private int rupeeCount = 0;
    
    [SerializeField]
    private TextMeshProUGUI rupeeText;
    // Start is called before the first frame update
    void Awake()
    {
        MessageManager.Instance.rupeeMessenger.Subscribe(collectRupee);
    }
    void Start()
    {
        rupeeText.text = "0";
    }

    
    void collectRupee (Message m)
    {
        rupeeCount ++;
        rupeeText.text = rupeeCount.ToString();
    }
}
