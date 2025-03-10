using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : Singleton<Inventory>
{

    private int rupeeCount = 0;
    public GameObject RupeeText;
    public GameObject Bridge;
    public GameObject BridgeCollider;
    private ServiceLocator _serviceLocator;

    /*
    //Set up Singleton
    public Inventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance!=null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    */
    public void Awake()
    {
        MessageManager.Instance.rupeeMessenger.Subscribe(CollectRupee);
    }

    public void Start()
    {
        _serviceLocator = GameObject.Find("GameManager").GetComponent<ServiceLocator>();
    }

    public void CollectRupee(Message m)
    {
        rupeeCount++;
        if (rupeeCount < 10)
        {
            _serviceLocator.AudioService.PlayEffect(_serviceLocator.AudioService.Rupee);
            //GameObject.Find("GameManager").GetComponent<ServiceLocator>().
            RupeeText.GetComponent<TextMeshProUGUI>().text = rupeeCount + "/10 Rupees";
        } 
        else
        {
            RupeeText.SetActive(false);
            Bridge.SetActive(true);
            BridgeCollider.SetActive(false);
        }
    }
}
