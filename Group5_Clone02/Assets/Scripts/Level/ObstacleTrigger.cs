using System.Collections;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject obstacle;
    private Vector2 startPos;
    [SerializeField] private Vector2 endPos;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float timeToDeactivate = 2f;
    public bool isTemporaryObstacle;
    public bool isDelayed = false;
    public float delayTime;
    private bool moving = false;

    private void Start()
    {
        startPos = obstacle.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.CompareTag("Player") && !moving)
        {
            StartCoroutine(MoveObstacle());
        }
    }

   

    private IEnumerator MoveObstacle()
    {
        if (isDelayed)
        {
            yield return new WaitForSeconds(delayTime);
        }
        moving = true;

        while ((Vector2)obstacle.transform.position != endPos)
        {
            obstacle.transform.position = Vector2.MoveTowards(
                obstacle.transform.position,
                endPos,
                speed * Time.deltaTime
            );
            yield return null; // wait until next frame
        }

        moving = false;

        if (isTemporaryObstacle)
        {
            yield return new WaitForSeconds(timeToDeactivate);

            while ((Vector2)obstacle.transform.position != startPos)
            {
                obstacle.transform.position = Vector2.MoveTowards(
                    obstacle.transform.position,
                    startPos,
                    speed * Time.deltaTime
                );
                yield return null; // wait until next frame
            }
        }
        

    }
}
