// Nikhil Palempalle

/* This test suite tests whether the HUD hearts interact appropriately when Link is damaged. It will test different combinations of damage,
* such as fractional damage, integer damages, and consecutive damages
* I chose to focus specifically on the lengths of both _myHeartObjects and _myHeartTypes because I wanted to make sure that the lists have the correct length
* (and therefore the correct number of hearts)
* This test is not brittle as it does not depend on the integrity of the code to function (it does not test implementation details (such as how each heart is processed))
*/
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HeartDamageTests : MonoBehaviour
{
    private HeartsManager _myHeartsManager;
    private Transform _fullHeart, _halfHeart;
    
    [SetUp]
    public void Setup()
    {
        _myHeartsManager = new GameObject().AddComponent<HeartsManager>();
        _myHeartsManager.FullHeartPrefab = Resources.Load("FullHeart") as GameObject;
        _myHeartsManager.HalfHeartPrefab = Resources.Load("HalfHeart") as GameObject;
        _myHeartsManager.InitHearts();
       
    }
    
    [Test]
    public void InitAmountOfHeartsEqualsThree()
    {
        Assert.AreEqual(3, _myHeartsManager.GetHeartObjectsCount()); //Measures the length of the heart objects list
        Assert.AreEqual(3, _myHeartsManager.GetHeartStatesCount());
        Assert.AreEqual(3.0f, _myHeartsManager.HealthCounter());
    }
    
    [Test]
    public void DamageHalfAHeart_ThreeHeartsShouldRemain()
    {
        _myHeartsManager.DamageLink(new DamageMessage(0.5f));
        
        Assert.AreEqual(3, _myHeartsManager.GetHeartObjectsCount());
        Assert.AreEqual(3, _myHeartsManager.GetHeartStatesCount());
        Assert.AreEqual(2.5f, _myHeartsManager.HealthCounter());
    }
    
    [Test]
    public void DamageOneHeart_TwoHeartsShouldRemain()
    {
        _myHeartsManager.DamageLink(new DamageMessage(1.0f));
        
        Assert.AreEqual(2, _myHeartsManager.GetHeartObjectsCount());
        Assert.AreEqual(2, _myHeartsManager.GetHeartStatesCount());
        Assert.AreEqual(2.0f, _myHeartsManager.HealthCounter());
    }
    
    [Test]
    public void DamageTwoHearts_OneHeartShouldRemain()
    {
        _myHeartsManager.DamageLink(new DamageMessage(2.0f));
        
        Assert.AreEqual(1, _myHeartsManager.GetHeartObjectsCount());
        Assert.AreEqual(1, _myHeartsManager.GetHeartStatesCount());
        Assert.AreEqual(1.0f, _myHeartsManager.HealthCounter());
    }
    
    [Test]
    public void DamageTwoHeartsAndAHalf_OneHeartShouldRemain()
    {
        _myHeartsManager.DamageLink(new DamageMessage(2.5f));
        
        Assert.AreEqual(1, _myHeartsManager.GetHeartObjectsCount());
        Assert.AreEqual(1, _myHeartsManager.GetHeartStatesCount());
        Assert.AreEqual(0.5f, _myHeartsManager.HealthCounter());
    }
    
    [Test]
    public void DamageOneHeartAndThenDamageHalfAHeart_TwoHeartsShouldRemain()
    {
        _myHeartsManager.DamageLink(new DamageMessage(1.0f));
        _myHeartsManager.DamageLink(new DamageMessage(0.5f));
        
        Assert.AreEqual(2, _myHeartsManager.GetHeartObjectsCount());
        Assert.AreEqual(2, _myHeartsManager.GetHeartStatesCount());
        Assert.AreEqual(1.5f, _myHeartsManager.HealthCounter());
    }
    
    [Test]
    public void DamageOneHeartAndAHalfAndThenDamageOneHeart_OneHeartShouldRemain()
    {
        _myHeartsManager.DamageLink(new DamageMessage(1.5f));
        _myHeartsManager.DamageLink(new DamageMessage(0.5f));
        
        Assert.AreEqual(1, _myHeartsManager.GetHeartObjectsCount());
        Assert.AreEqual(1, _myHeartsManager.GetHeartStatesCount());
        Assert.AreEqual(1.0f, _myHeartsManager.HealthCounter());
    }
}
