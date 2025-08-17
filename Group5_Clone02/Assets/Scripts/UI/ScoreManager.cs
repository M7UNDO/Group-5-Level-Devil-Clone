using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

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
}
