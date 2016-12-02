using UnityEngine;
using Affdex;
using System.Collections.Generic;
using System.Collections;
using System.Text;

public class PlayerEmotion : ImageResultsListener
{
    private float currentAttention;
    private float currentValence;
    private float currentEngagement;
    private float currentSurprise;

    private List<string> attentionList = new List<string>();
    private List<string> valenceList = new List<string>();
    private List<string> engagementList = new List<string>();
    private List<string> surpriseList = new List<string>();
    private string[] tempList;
    private string[] headerString = new string[] { "Attention", "Engagement", "Surprise", "Valence" };

    private string delimiter = ",";
    private string filePath;
    private StringBuilder sb = new StringBuilder();

    public override void onFaceFound(float timestamp, int faceId)
    {
        Debug.Log("Face found!");
    }

    public override void onFaceLost(float timestamp, int faceId)
    {
        Debug.Log("NO FACE FOUND!!!");
    }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
        if (faces.Count > 0)
        {
            faces[0].Expressions.TryGetValue(Expressions.Attention, out currentAttention);
            faces[0].Emotions.TryGetValue(Emotions.Valence, out currentValence);
            faces[0].Emotions.TryGetValue(Emotions.Engagement, out currentEngagement);
            faces[0].Emotions.TryGetValue(Emotions.Surprise, out currentSurprise);
        }
        attentionList.Add(currentAttention.ToString());
        engagementList.Add(currentEngagement.ToString());
        surpriseList.Add(currentSurprise.ToString());
        valenceList.Add(currentValence.ToString());
        //Debug.Log(System.DateTime.Now.Date.ToString().Split(' ')[0].Replace('/', '-'));
    }

    public void saveToCsv()
    {
        filePath = getPath();
        // If file does not exist then create a new file with heading
        if (!System.IO.File.Exists(filePath))
        {
            sb.AppendLine(string.Join(delimiter, headerString));
        }
        // Add the data
        for (int i = 0; i < attentionList.Count; i++)
        {
            tempList = new string[] { attentionList[i], engagementList[i], surpriseList[i], valenceList[i] };
            sb.AppendLine(string.Join(delimiter, tempList));
            System.IO.File.WriteAllText(filePath, sb.ToString());
        }
    }

    private string getPath()
    {
        return Application.dataPath + "\\CSV\\" + System.DateTime.Now.ToString().Replace('/', '-').Replace(':', '-') + ".csv";
    }
}
