using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject characterPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Character character = new Character("Test Character", 1, 10, "Dwarf", "Fighter", true, true, true);
        GameObject characterObject = Instantiate(characterPrefab); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
