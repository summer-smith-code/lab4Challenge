using System.Collections.Generic;
using UnityEngine;

public class Lab4 : MonoBehaviour
{
    // inputs
    public string characterName;
    public int characterLevel;
    public int conScore;
    public string characterRace;
    public bool toughFeat;
    public bool stoutFeat;
    
    // true if averaged, false if rolled
    public bool diceAveraged;
    private string rollType; // to store whether the HP was rolled or averaged
    public string characterClass;

    private int totalHP;
    // dictionaries to hold constiution, races, and classes data
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
        int hitPoints; // total HP
        int roll = 0; // single roll value
        int totalRoll = 0; // add all rolls together

        if (diceAveraged)
        {
            rollType = "averaged";
            switch (characterClasses[characterClass])
            {
                case 6:
                    roll = 4;
                    break;
                case 8:
                    roll = 5;
                    break;
                case 10:
                    roll = 6;
                    break;
                case 12:
                    roll = 7;
                    break;
                default: // This shouldn't be possible, but it has been added in for the sake of debugging.
                    roll = 0;
                    break;
            }
            totalRoll = roll * characterLevel;
        } else
        {
            rollType = "rolled";
            for (int i = 0; i < characterLevel; i++)
            {
                // randomize each roll and add it to the total roll count
                roll = Random.Range(1, characterClasses[characterClass] + 1);
                totalRoll += roll;
                Debug.Log("Roll " + (i + 1) + ": " + roll);
            }
        }
        // Calculate total HP based in accordance to feat selection
        if (toughFeat && stoutFeat)
        {
            hitPoints = (totalRoll) + (characterLevel * conScores[conScore]) +
                        (characterLevel * characterRaces[characterRace]) + (characterLevel * 3);
        }
        else if (toughFeat)
        {
            hitPoints = (totalRoll) + (characterLevel * conScores[conScore]) +
                        (characterLevel * characterRaces[characterRace]) + (characterLevel * 2);
        }
        else if (stoutFeat)
        {
            hitPoints = (totalRoll) + (characterLevel * conScores[conScore]) +
                        (characterLevel * characterRaces[characterRace]) + (characterLevel * 1);
        }
        else
        {
            hitPoints = (totalRoll) + (characterLevel * conScores[conScore]) +
                        (characterLevel * characterRaces[characterRace]);
        }
          
        
        return hitPoints;
    }
    // Check to make sure that all of the values are within the correct parameters. If not, it sets them to a default value and output a debug log
    public void checkValues()
    {
        if (characterLevel < 1 || characterLevel > 20)
        {
            Debug.Log("Character level must be between 1 and 20. Setting to 1");
            characterLevel = 1;
        }
        if (conScore < 1 || conScore > 30)
        {
            Debug.Log("Constitution score must be between 1 and 30. Setting to 1.");
            conScore = 1;
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

    // Output the character information and total HP
    public void output()
    {
        if (toughFeat && stoutFeat)
        {
            Debug.LogFormat("My character " +characterName + " is a level " +characterLevel + " " +characterClass + 
                            " with a CON score of " +conScore + " and is of the " +characterRace + 
                            " race and has the Tough and Stout feats. I want the HP " + rollType + ".");
        }
        else if (toughFeat)
        {
            Debug.Log("My character " +characterName + " is a level " +characterLevel + " " +characterClass + 
                      " with a CON score of " +conScore + " and is of the " +characterRace + 
                      " race and has the Tough feat. I want the HP " + rollType + ".");
        }
        else if (stoutFeat)
        {
            Debug.Log("My character " +characterName + " is a level " +characterLevel + " " +characterClass + 
                      " with a CON score of " +conScore + " and is of the " +characterRace + 
                      " race and has the Stout feat. I want the HP " + rollType + ".");
        }
        else
        {
            Debug.Log("My character " +characterName + " is a level " +characterLevel + " " +characterClass + 
                      " with a CON score of " +conScore + " and is of the " +characterRace + 
                      " race and has no feats. I want the HP " + rollType + ".");
        }
        Debug.Log("Total HP: " + totalHP);
    }
}
