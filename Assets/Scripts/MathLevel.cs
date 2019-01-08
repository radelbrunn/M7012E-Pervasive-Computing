using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MathLevel : MonoBehaviour {
    public Text sumComponent;
    public Text titleComponent;
    public Text description;
    private int sum = 0;
    public TimerScript tc;
    private LevelData level;
    private int lessonIndex = 0;
    public GameControler controler;
    private bool correct = false;
    public string pathToLevel;
    
    // Initialize level and blackboard description
    void Start() {
        LoadLevel();
        updateBlackboardDescription(level.lessons[lessonIndex]);
    }

    void Update () {
        if(correct && tc.Expired())
        {
            nextLesson();
            tc.paused = true;
            tc.resetTimer();
        }
    }

    // Used for loading levels from json files. pathToLevel is a public variable set in each unity scene.
    public void LoadLevel()
    {
        using (StreamReader stream = new StreamReader(pathToLevel))
        {
            string json = stream.ReadToEnd();
            level = JsonUtility.FromJson<LevelData>(json);
        }
    }

    // Called after a correct answer has been provided. If its the last lesson in the level then nextLevel is called. 
    void nextLesson(){
        correct = false;
        lessonIndex++;
        if(lessonIndex < level.lessons.Length) {
            updateBlackboardDescription(level.lessons[lessonIndex]);
        } else{
            controler.nextLevel();
        }
    }

    // add to the current sum
    void addToSum(int sumToAdd)
    {
        this.sum += sumToAdd;
        updateSum();
    }

    private void updateSum()
    {
        this.sumComponent.text = "Sum: " + this.sum.ToString();
    }

    void updateBlackboardDescription(string text) {
        this.description.text = text;
    }


    // Called if the sum has changed with the old and current value
    public void sumChanged(int old, int current) {
        int newSum = current-old;
        Debug.Log("newSum: " + newSum.ToString() + " answer: " + level.answers[lessonIndex]);
        addToSum(newSum);
        if(current.ToString() == level.answers[lessonIndex]) {
            updateBlackboardDescription("Correct!");
            correct = true;

            if (tc != null)
            {
                if (tc.paused)
                {
                    tc.Start();
                    tc.paused = false;
                }
            }
        }
    }
}