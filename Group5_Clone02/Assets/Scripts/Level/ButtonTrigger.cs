using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject obstacle;
    private Vector2 startPos;
    [SerializeField] private Vector2 endPos;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float pressSpeed = 3f;
    [SerializeField] private float timeToDeactivate = 2f;
    public bool isTemporaryObstacle;

    private bool moving = false;
    [SerializeField] private Vector2 pressedButtonState;
    private Vector2 originalButtonState;

    public AudioSource buttonPushSFX;
    private void Start()
    {
        startPos = obstacle.transform.position;
        originalButtonState = transform.position;
        obstacle.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Player") && !moving)
        {
            StartCoroutine(ButtonPress());
            buttonPushSFX.Play();
            StartCoroutine(MoveObstacle());
            
        }
    }

    private void OnCollisionExit2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ButtonReturn());
        }
    }


    private IEnumerator MoveObstacle()
    {
        moving = true;
        obstacle.SetActive(true);

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

        

        obstacle.SetActive(false);
    }

    private IEnumerator ButtonPress()
    {
        while ((Vector2)transform.position != pressedButtonState)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                pressedButtonState,
                pressSpeed * Time.deltaTime
            );
            yield return null; // Wait until next frame
        }
    }
    private IEnumerator ButtonReturn()
    {
        yield return new WaitForSeconds(1f);
        while ((Vector2)transform.position != originalButtonState)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                originalButtonState,
                pressSpeed * Time.deltaTime
            );
            yield return null; // Wait until next frame
        }
    }

}
