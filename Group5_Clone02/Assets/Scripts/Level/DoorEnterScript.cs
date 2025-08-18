using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterScript : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private float fadeDuration = 2f;
    [SerializeField] private float endLevelDuration = 1.2f;
    private Rigidbody2D rb;
    public bool isEndGame = false;
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.CompareTag("Player"))
        {
            

                PlayerMovement playerMovement = coli.gameObject.GetComponent<PlayerMovement>();
            if(playerMovement.playerID == 1)
            {
                ScoreManager.Instance.AddBlueWin();
            }
            else if(playerMovement.playerID == 2)
            {
                ScoreManager.Instance.AddRedWin();
            }

            FindObjectOfType<DotUI>().UpdateDots();

         
            playerMovement.enabled = false;
            coli.gameObject.transform.position = transform.position;
            coli.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rb = coli.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            

            print(ScoreManager.Instance.blueScore);
            if (ScoreManager.Instance.blueScore == 5)
            {
                isEndGame = true;
                ScoreManager.Instance.EndGame();
            }
            else if (ScoreManager.Instance.redScore == 5)
            {

                isEndGame = true;
                ScoreManager.Instance.EndGame();
            }
            else
            {
                isEndGame = false;
            }
            StartCoroutine(PlayerEnterDoor(coli.gameObject));
        }
    }


    private IEnumerator PlayerEnterDoor(GameObject player)
    {
        
        
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        SpriteRenderer srEyes = player.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Color startColor = sr.color;
        Color startEyesColor = sr.color;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            sr.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            srEyes.color = new Color(startEyesColor.r, startEyesColor.g, startEyesColor.b, alpha);
            yield return null;
        }

        doorAnimator.SetTrigger("Close");
        yield return new WaitForSeconds(endLevelDuration);

        if (!isEndGame)
        {
            gameObject.GetComponent<LevelLoader>().LoadNextLevel();
        }
        else
        {
            print("Level Completed");
        }
        
    }
}

    



