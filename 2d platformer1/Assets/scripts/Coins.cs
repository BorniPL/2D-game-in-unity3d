using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

    private LevelManager theLevelManager;
    public int coinsValue;
	// Use this for initialization
	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            theLevelManager.addCoins(coinsValue);
            Destroy(gameObject);
        }
    }
}
