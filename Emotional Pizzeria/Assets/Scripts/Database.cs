using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;

public class Database : MonoBehaviour
{

    private string dbName = "URI=file:data/ega.db";
    private int curNumHearts;
    public Text curNumHeartsText;
 
    // Start is called before the first frame update
    void Start()
    {   
        CreateDB();

        curNumHearts = getCurNumHearts();
        //curNumHeartsText = "Hearts: " + curNumHearts;

        Debug.Log("Current number of hearts: " + curNumHearts);

        //Test functions
        //addHeart();
        //showHearts();
    }

    public int getCurNumHearts(){
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

    public void addHeart() { 
        using (var conn = new SqliteConnection(dbName))
        {
            conn.Open();

            using (var cmd = conn.CreateCommand())
            {
                curNumHearts++;
                cmd.CommandText = $"insert into game1_hearts(hearts) values({curNumHearts});";
                cmd.ExecuteNonQuery();
                Debug.Log("Added heart");
            }

            conn.Close();
        }
    }

    public void showHearts() {
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

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateDB()
    {
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
}
