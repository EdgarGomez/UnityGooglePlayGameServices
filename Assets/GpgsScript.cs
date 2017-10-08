using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GpgsScript : MonoBehaviour {

    int points = 0;
    public Text pointsText;

	void Start () {
        // Recommended for debugging
        PlayGamesPlatform.DebugLogEnabled = true;

        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
    }
	
    /// <summary>
    /// Make Login and manage the succes or failure
    /// </summary>
    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Login Sucess");
            }
            else
            {
                Debug.Log("Login failed");
            }
        });
    }

    /// <summary>
    /// Shows Leaderboard
    /// </summary>
    public void OnShowLeaderBoard()
    {
        //Social.ShowLeaderboardUI (); // Show all leaderboard
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIuJGt07gTEAIQAQ");
    }

    /// <summary>
    /// Adds score to Leaderboard
    /// </summary>
    public void addScoreLeaderBoard()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(points, "CgkIuJGt07gTEAIQAQ", (bool success) =>
            {
                if (success)
                {
                    points = 0;
                    pointsText.text = "Points: " + points;

                }
                else
                {
                    Debug.Log("Update Score Fail");
                }
            });
        }
    }

    /// <summary>
    /// Unlock Reward
    /// </summary>
    public void rewardAchiv()
    {
        Social.ReportProgress("CgkIuJGt07gTEAIQAg", 200.0f, (bool success) => {
            // handle success or failure
        });
    }

    /// <summary>
    /// Adding points
    /// </summary>
    public void morePoints ()
    {
        points = points + 100;
        pointsText.text = "Points: " + points;
    }

    /// <summary>
    /// Log Out
    /// </summary>
    public void OnLogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }
}
