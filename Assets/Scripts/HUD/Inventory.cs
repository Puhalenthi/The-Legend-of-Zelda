using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private int rupeeCount = 0;
    public GameObject RupeeText;
    public GameObject Bridge;
    public GameObject BridgeCollider;


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

    public void CollectRupee()
    {
        rupeeCount++;
        if (rupeeCount < 10)
        {
            RupeeText.GetComponent<TextMeshPro>().text = rupeeCount + "/10 Rupees";
        } else
        {
            RupeeText.SetActive(false);
            Bridge.SetActive(true);
            BridgeCollider.SetActive(false);
        }
    }
}
