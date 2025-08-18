using UnityEngine;
using UnityEngine.UI;

public class DotUI : MonoBehaviour
{
    public Image[] dots;
    public Color blueColor, redColor, emptyColor;

    void Start()
    {
        UpdateDots();
    }

    public void UpdateDots()
    {
        int totalWins = ScoreManager.Instance.blueScore + ScoreManager.Instance.redScore;

        for (int i = 0; i < dots.Length; i++)
        {
            if (i < ScoreManager.Instance.blueScore)
            {
                dots[i].color = blueColor;
            }
            else if (i < totalWins)
            {
                dots[i].color = redColor;
            }
            else
            {
                dots[i].color = emptyColor;
            }
        }
    }
}
