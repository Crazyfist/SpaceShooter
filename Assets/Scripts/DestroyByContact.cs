using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    private Rigidbody rb;

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }

        if(gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        rb = GetComponent<Rigidbody>();

        if (other.tag == "Boundary")
        {
            return;
        }

        Instantiate(explosion, rb.transform.position, rb.transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
