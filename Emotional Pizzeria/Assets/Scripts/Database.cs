using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;

/// <summary>
/// Author: Bernhard Andersson
/// This class is used to interact with the database, to send and retrieve data
/// </summary>
public class Database : MonoBehaviour
{

    private string dbFilePath = "data/ega.db";
    private string dbName = "URI=file:data/ega.db";
    private int curNumHearts;
    public Text curNumHeartsText;
    public GameObject databaseCheck;    
    private bool databasePresent = true;
    public bool requiresPopup;
 
    // Start is called before the first frame update
    void Start()
    {   
        CreateDB();

        //curNumHearts = getCurNumHearts();
        //curNumHeartsText = "Hearts: " + curNumHearts;

        //Debug.Log("Current number of hearts: " + curNumHearts);

        //Test functions
        //addHeart();
        //showHearts();
    }

    /// <summary>
    /// Author: Bernhard Andersson
    /// Returns the current number of hearts the player has
    /// </summary>
    /// <returns> The number of hearts stored in the database </returns>
    public int getCurNumHearts(){
        if (!databasePresent){
            Debug.Log("No hearts found as database is missing.");
            return -1;
        }
        using (var conn = new SqliteConnection(dbName))
        {
            conn.Open();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select hearts from game1_hearts order by timestamp desc limit 1;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }

            conn.Close();
        }
        Debug.Log("Error: no hearts found");
        return -1;
    }

    /// <summary>
    /// Author: Bernhard Andersson
    /// Adds n hearts to the database
    /// </summary>
    /// <param name="n"> The number of hearts to add to the database </param>
    public void addHearts(int n) { 
        if (!databasePresent){
            Debug.Log("No hearts added as database is missing.");
            return;
        }
        using (var conn = new SqliteConnection(dbName))
        {
            conn.Open();

            using (var cmd = conn.CreateCommand())
            {
                curNumHearts+=n;
                cmd.CommandText = $"insert into game1_hearts(hearts) values({curNumHearts});";
                cmd.ExecuteNonQuery();
                Debug.Log($"Added {n} hearts");
                //showHearts();
            }

            conn.Close();
        }
    }

    /// <summary>
    /// Author: Bernhard Andersson
    /// Shows the current number of hearts
    /// </summary>
    public void showHearts() {
        if (!databasePresent){
            Debug.Log("No hearts shown as database is missing.");
            return;
        }
        using (var conn = new SqliteConnection(dbName))
        {
            conn.Open();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select * from game1_hearts;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log(reader.GetInt32(0) + " " + reader.GetString(1));
                    }
                }
            }

            conn.Close();
        }
    }

    /// <summary>
    /// Author: Bernhard Andersson
    /// Creates the database if it doesn't exist
    /// </summary>
    public void CreateDB()
    {
        Debug.Log(dbFilePath);
        if (!File.Exists(dbFilePath)){
            if (requiresPopup) databaseCheck.SetActive(true);
            databasePresent = false;
            return;
        }

        using (var conn = new SqliteConnection(dbName))
        {
            conn.Open();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "create table if not exists game1_hearts(hearts int, timestamp string default current_timestamp);";
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

    public void deactivatePopup(){
        databaseCheck.SetActive(false);
    }
}
