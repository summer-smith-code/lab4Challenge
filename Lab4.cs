using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Rendering.UI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TextCore.Text;

public class Lab4 : MonoBehaviour
{

    public string characterName;
    public int characterLevel;
    public int conScore;
    public string characterRace;
    public Boolean toughFeat;
    public Boolean stoutFeat;
    // true if averaged, false if rolled
    public Boolean diceAveraged;
    public string characterClass;

    private int totalHP;
    private Dictionary<int, int> conScores = new Dictionary<int, int>();
    private Dictionary<string, int> characterRaces = new Dictionary<string, int>();
    private Dictionary<string, int> characterClasses = new Dictionary<string, int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setUp();
        checkValues();
        totalHP = calculateHP();
        output();
    }

    public int calculateHP()
    {

        return totalHP;
    }
    public void checkValues()
    {
        if (characterLevel < 1 || characterLevel > 20)
        {
            Debug.Log("Character level must be between 1 and 20.");
        }
        if (conScore < 1 || conScore > 30)
        {
            Debug.Log("Constitution score must be between 1 and 30.");
        }
            if (characterRaces.ContainsKey(characterRace) == false)
        {
            Debug.Log("The race you chose is not applicable. Setting to Human.");
            characterRace = "Human";
        }
            if (characterClasses.ContainsKey(characterClass) == false)
        {
            Debug.Log("The class you chose is not applicable. Setting to Fighter.");
            characterClass = "Fighter";
        }

    }
    public void setUp()
    {
        // Set up constitution scores and modifiers
        int start = -5;
        for (int i = 1; i <= 30; i++)
        {
            if (i % 2 == 0) start++;
            conScores.Add(i, start);
        }
        /* 
        foreach (var kvp in conScores)
        {
            if (kvp.Key == conScore)
            {
                // Debug.LogFormat("Constitution Score: {0} \n Modifier: {1}", kvp.Key, kvp.Value);
            }
            Debug.LogFormat("Constitution Score: {0} \n Modifier: {1}", kvp.Key, kvp.Value);
        }
        */
    
        // Set up races and modifiers
        characterRaces.Add("Aasmar", 0);
        characterRaces.Add("Dragonborn", 0);
        characterRaces.Add("Dwarf", 2);
        characterRaces.Add("Elf", 0);
        characterRaces.Add("Gnome", 0);
        characterRaces.Add("Goliath", 1);
        characterRaces.Add("Halfling", 0);
        characterRaces.Add("Orc", 1);
        characterRaces.Add("Human", 0);
        characterRaces.Add("Tiefling", 0);

        // set up character classes and hit die
        characterClasses.Add("Artificer", 8);
        characterClasses.Add("Barbarian", 12);
        characterClasses.Add("Bard", 8);
        characterClasses.Add("Cleric", 8);
        characterClasses.Add("Druid", 8);
        characterClasses.Add("Fighter", 10);
        characterClasses.Add("Monk", 8);
        characterClasses.Add("Ranger", 10);
        characterClasses.Add("Rogue", 8);
        characterClasses.Add("Paladin", 10);
        characterClasses.Add("Sorcerer", 6);
        characterClasses.Add("Wizard", 6);
        characterClasses.Add("Warlock", 8);
    }

    public void output()
    {
        if (toughFeat && stoutFeat)
        {
            Debug.LogFormat("My character " +characterName + " is a level " +characterLevel + " " +characterClass + " with a CON score of " +conScore + " and is of " +characterRace + " race and has Tough and Stout feats.I want the HP " +rollType);
        }
        else if (toughFeat)
        {
            Debug.Log("My character " +characterName + " is a level " +characterLevel + " " +characterClass + " with a CON score of " +conScore + " and is of " +characterRace + " race and has Tough feat.I want the HP " +rollType);
        }
        else if (stoutFeat)
        {
            Debug.Log("My character " +characterName + " is a level " +characterLevel + " " +characterClass + " with a CON score of " +conScore + " and is of " +characterRace + " race and has Stout feat.I want the HP " +rollType);
        }
        else
        {
            Debug.Log("My character " +characterName + " is a level " +characterLevel + " " +characterClass + " with a CON score of " +conScore + " and is of " +characterRace + " race and has no feats.I want the HP " +rollType);
        }
        Debug.Log("Total HP: " + totalHP);

    }
}
