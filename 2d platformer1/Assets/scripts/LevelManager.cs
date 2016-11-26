using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float respawnTime;
    public HeroController PlayerController;
	// Use this for initialization
	void Start () {
        PlayerController = FindObjectOfType<HeroController>();
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

        yield return new WaitForSeconds(respawnTime);

        PlayerController.transform.position = PlayerController.respawnPosition;
        PlayerController.gameObject.SetActive(true);
    }
}
