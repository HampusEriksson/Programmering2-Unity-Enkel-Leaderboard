using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;


public class LeaderBoard : MonoBehaviour
{

    public TextMeshProUGUI highScoreText;
    private string leaderboardKey = "936eb16ef518600e56b197d00fef7699936884f89e3792dd548a5a34dab8311f";
    
    void Start()
    {
        GetLeaderBoard();
    }
    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(leaderboardKey, (leaderboard) =>
        {
            highScoreText.text = "";
            foreach (var item in leaderboard)
            {
                Debug.Log(item.Username + " : " + item.Score);
                highScoreText.text += item.Username + " : " + item.Score + "\n";
            }
        });
    }

    public void SetLeaderBoardEntry()
    {
        string username = "Vilgot";
        int score = Random.Range(0, 10);
        LeaderboardCreator.UploadNewEntry(leaderboardKey, username, score);
        GetLeaderBoard();
    }
}
