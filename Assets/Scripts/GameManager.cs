using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string PLAYER_PREFIX = "Player ";

    private static Dictionary<string, Player> players = new Dictionary<string, Player>();
    public static void RegisterPlayer(string netID, Player player)
    {
        string playerId = PLAYER_PREFIX + netID;
        players.Add(playerId, player);
        player.transform.name = playerId;
    }
    public static void UnregisterPlayer(string playerId)
    {
        players.Remove(playerId);
    }
    public static Player GetPlayer(string playerId)
    {
        return players[playerId];
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(200, 200, 200, 500));
        GUILayout.BeginVertical();
        foreach (string playerId in players.Keys)
        {
            GUILayout.Label(playerId + " - " + players[playerId].transform.name);
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
