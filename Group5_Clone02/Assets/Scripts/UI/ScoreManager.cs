using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private GameObject bluePlayerWins;
    [SerializeField] private GameObject redPlayerWins;

    public int blueScore = 0;
    public int redScore = 0;
    public int levelsPlayed = 0;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddBlueWin()
    {
        blueScore++;
        levelsPlayed++;
    }

    public void AddRedWin()
    {
        redScore++;
        levelsPlayed++;
    }

    public void EndGame()
    {
        if(levelsPlayed == 5)
        {
            Time.timeScale = 0f;
            if (blueScore > redScore)
            {
                bluePlayerWins.SetActive(true);
            }
            else if(redScore > blueScore)
            {
                redPlayerWins.SetActive(true);
            }
        }
    
        
    }
}
