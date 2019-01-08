using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SpellLevel : MonoBehaviour
{
    public Text sumComponent;
    public Text titleComponent;
    public Text description;
    public Boxcaster bc;
    public TimerScript tc;
    private LevelData level;
    private int lessonIndex = 0;
    private string old;
    public GameControler controler;
    private bool correct;
    public string pathToLevel;

    private void Start()
    {
        LoadLevel();
        updateBlackboardDescription(level.lessons[lessonIndex]);
    }

    public void LoadLevel()
    {
        using (StreamReader stream = new StreamReader(pathToLevel))
        {
            string json = stream.ReadToEnd();
            level = JsonUtility.FromJson<LevelData>(json);
        }
    }

    void updateBlackboardDescription(string text)
    {
        this.description.text = text;
    }

    public void Update()
    {
        if (this.old == null) {
            this.old = "";
        }
        this.stringChanged(this.bc.content.ToUpper());
        this.sumComponent.text = this.old;
        if (correct && tc.Expired()) {
            tc.paused = true;
            tc.resetTimer();
            nextLesson();
        }
    }

    void nextLesson()
    {
        lessonIndex++;
        if(lessonIndex < level.lessons.Length) {
            updateBlackboardDescription(level.lessons[lessonIndex]);
        } else{
            controler.nextLevel();
        }
    }

    private void check() {
        if (old.ToUpper() == this.level.answers[this.lessonIndex].ToUpper()) {
            correct = true;
            updateBlackboardDescription("Correct!");
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

    public void stringChanged(string current) {
        if (old == null) {
            old = current.ToUpper();
            check();
        } else if (current.ToUpper() != old.ToUpper()) {
            old = current.ToUpper();
            check();
        }
    }
}