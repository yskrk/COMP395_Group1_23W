using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
    private static int score = 13698;
    private static int platesServed = 12345;
    private static int ordersLost = 0;
    private static bool win = true;
    public static void AddPoints( int x ) {
        score += x;
    }

    public static int GetScore() {
        return score;
    }

    public static void AddPlates() {
        platesServed++;
    }

    public static int GetPlates() {
        return platesServed;
    }
    
    public static void AddLoss() {
        ordersLost++;
    }

    public static int GetLostOrders() {
        return ordersLost;
    }

    public static void Win() {
        win = true;
    }

    public static bool GetResult() {
        return win;
    }

}
