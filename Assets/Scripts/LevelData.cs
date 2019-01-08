using UnityEngine;

[System.Serializable]
public class LevelData {
    public int level;
    public string[] lessons;
    public string[] answers;
    public float[] timeLimits;

    public LevelData(int level, string[] lessons, string[] answers, float[] timeLimits) {
        this.level = level;
        this.lessons = lessons;
        this.answers = answers;
        this.timeLimits = timeLimits;
    }
}