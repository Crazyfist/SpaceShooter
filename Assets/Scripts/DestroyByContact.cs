using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    private Rigidbody rb;

    public GameObject explosion;
    public GameObject playerExplosion;

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
        }

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
