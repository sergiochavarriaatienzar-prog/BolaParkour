using UnityEngine;

public class MechanicsTTL : MonoBehaviour
{
    [SerializeField] private float timeToFall = 1f;      // Tiempo antes de caer
    [SerializeField] private float respawnTime = 3f;     // Tiempo para reaparecer
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FallAndRespawn());
        }
    }

    private System.Collections.IEnumerator FallAndRespawn()
    {
        yield return new WaitForSeconds(timeToFall);

        rb.isKinematic = false; // Se cae

        yield return new WaitForSeconds(respawnTime);

        rb.isKinematic = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
