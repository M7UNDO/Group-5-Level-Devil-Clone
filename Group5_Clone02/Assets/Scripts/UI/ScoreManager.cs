using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private GameObject bluePlayerWins;
    [SerializeField] private GameObject redPlayerWins;

    public int blueScore = 0;
    public int redScore = 0;

    

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
    }

    public void AddRedWin()
    {
        redScore++;
    }

    public void EndGame()
    {
        if(blueScore == 5)
        {
            Time.timeScale = 0f;
            bluePlayerWins.SetActive(true);
        }
        else if(redScore == 5)
        {
            Time.timeScale = 0f;
            redPlayerWins.SetActive(true);
        }
        
    }
}
