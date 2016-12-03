using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float respawnTime;
    public HeroController PlayerController;
    public GameObject explosion;
    public int coinCount;
    public Text coinText;
	// Use this for initialization
	void Start () {
        PlayerController = FindObjectOfType<HeroController>();
        coinText.text = "Coins: " + coinCount;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Respawn()
    {
        StartCoroutine("RespawnCo");

    }
    public IEnumerator RespawnCo()
    {
        PlayerController.gameObject.SetActive(false);

        Instantiate(explosion, PlayerController.transform.position, PlayerController.transform.rotation);

        yield return new WaitForSeconds(respawnTime);

        PlayerController.transform.position = PlayerController.respawnPosition;
        PlayerController.gameObject.SetActive(true);
    }
    public void addCoins(int coinsToAdd)
    {

        coinCount += coinsToAdd;
        coinText.text = "Coins: " + coinCount;
    }
}
