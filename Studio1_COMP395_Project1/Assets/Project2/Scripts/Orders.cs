using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum FoodValues {
        BottomBun = 1,
        Patty = 2,
        American = 3,
        Swiss = 4,
        Lettuce = 5,
        Mushroom = 6,
        Onion = 7,
        Tomato = 8,
        Bacon = 9,
        TopBun = 10
    }
[Serializable]
public class Orders {
    public List<Tuple<int, FoodValues>> recipe;
    private int maxValue = 0;

    public static string[] possibleOrders = {
        "1*2", // only patty
        "1*2/1*3", // cheeseburger: patty and american cheese
        "1*2/1*3/1*9/1*5/1*8" // BLT burger: patty, cheese, bacon, lettuce, tomato
    };

    public static string[] orderTexts = {
        "1x Patty\n",
        "1x Patty\n1x American Cheese",
        "1x Patty\n1x American Cheese\n1x Bacon\n1x Lettuce\n1x Tomato"
    };

    // public Orders( string args ) {
    //     recipe = new List<Tuple<int, FoodValues>>();
    //     recipe.Add( new Tuple<int,FoodValues>(1,FoodValues.BottomBun));
    //     foreach ( string s in args.Split("/") ) {
    //         string[] item = s.Split("*");
    //         recipe.Add( new Tuple<int,FoodValues>(int.Parse(item[0]), (FoodValues)int.Parse(item[1])));
    //     }
    //     recipe.Add( new Tuple<int,FoodValues>(1,FoodValues.TopBun));
    // }

    public Orders( int type = 0 ) {
        recipe = new List<Tuple<int, FoodValues>>();
        if ( type >= possibleOrders.Length ) type = 0;
        recipe.Add( new Tuple<int,FoodValues>(1,FoodValues.BottomBun));
        foreach ( string s in possibleOrders[type].Split("/") ) {
            string[] item = s.Split("*");
            recipe.Add( new Tuple<int,FoodValues>(int.Parse(item[0]), (FoodValues)int.Parse(item[1])));
        }
        recipe.Add( new Tuple<int,FoodValues>(1,FoodValues.TopBun));
        maxValue = 0;
        foreach ( Tuple<int,FoodValues> t in recipe ) {
            maxValue++;
        }
    }

    public int getMaxValue() { return maxValue; }

    // public bool Compare( List<Tuple<int,FoodValues>> other ) {
    //     List<Tuple<int,FoodValues>> basis = recipe;
    //     if ( basis.Count != other.Count ) return false;
    //     for ( int i = 0 ; i < basis.Count ; i++ ) {
    //         if ( basis[i].Item1 != )
    //     }
    //     return true;
    // }
}
