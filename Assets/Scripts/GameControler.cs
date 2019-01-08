using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour {
    private string[] mathLevels = { "math1", "math2", "math3" };
    private string[] spellLevels = { "spell1", "spell2", "spell3" };

    private int levelIndex = 0;
    public string gameType;
    private bool gravity = true;
    public GameObject interactionObjects;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("s")) {
            levelIndex = 0;
            this.gameType = "spelling";
            setLevel(levelIndex, gameType);
        } else if (Input.GetKeyDown("m")) {
            levelIndex = 0;
            this.gameType = "math";
            setLevel(levelIndex, gameType);
        }
        else if (Input.GetKeyDown("n")) {
            nextLevel();
        }
    }

    public void nextLevel() {
        levelIndex++;
        Debug.Log(gameType);
        setLevel(levelIndex, gameType);
    }
    
   
    public void setLevel(int level, string game)
    {
        string newLevel = "";
        if (game.Equals("math"))
        {
            newLevel = mathLevels[level];
        }
        else if (game.Equals("spelling"))
        {
            newLevel = spellLevels[level];
        }
        SceneManager.LoadScene(newLevel);
    }

    public void toggleGravity()
    {
        gravity = !gravity;
        Rigidbody[] objects = interactionObjects.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody body in objects)
        {
            body.useGravity = gravity;
        }
    }
}
