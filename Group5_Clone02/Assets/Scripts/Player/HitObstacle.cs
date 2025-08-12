using System.Collections;
using UnityEngine;

public class HitObstacle : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private ParticleSystem particleEffectPrefab;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float respawnDelay = 2f;

    [SerializeField] private SpriteRenderer[] allPlayerRenderers;
    private PlayerMovement playerMovement;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    [Header("Audio")]
    public AudioSource explodeSfx;
    public AudioSource respawnSfx;

    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        rb = player.GetComponent<Rigidbody2D>();

        startPosition = player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Spikes"))
        {

            StartCoroutine(HandleDeath());
        }
    }

    private IEnumerator HandleDeath()
    {
        explodeSfx.Play();
        ParticleSystem effect = Instantiate(particleEffectPrefab, player.transform.position, Quaternion.identity);
        effect.Play();

        if (playerMovement != null) playerMovement.enabled = false;
        foreach(SpriteRenderer sprite in allPlayerRenderers)
        {
            sprite.enabled = false;
        }


        rb.velocity = Vector2.zero;
        RigidbodyConstraints2D originalConstraints = rb.constraints;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        yield return new WaitForSeconds(respawnDelay);

        // Respawn position
        respawnSfx.Play();
        Vector3 spawnPos = respawnPoint != null ? respawnPoint.position : startPosition;
        player.transform.position = spawnPos;

        rb.constraints = originalConstraints;

        foreach (SpriteRenderer sprite in allPlayerRenderers)
        {
            sprite.enabled = true;
        }
        if (playerMovement != null) playerMovement.enabled = true;
        Destroy(effect.gameObject, effect.main.duration);
    }
}
