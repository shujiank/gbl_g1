using UnityEngine;
using System.Collections;

public class ProjectContent : Content
{

    private string[] Narr = {"Sith Lord: What if we compress an object along a surface?",
    "Lord of light: It should map the object to the surface.",
    "Khal Drogo: Basically, it will be a projection from 2-space onto the line, that forgets the y-coordinate.",
    "Sith Lord: Good job. This is called a linear projection. Now, if we have a unit matrix that is being projected to the x axis, what do you think will the transformation matrix be like?",
    "White weirwood trees: I believe each vector in the matrix should be projected on the x-axis for the mapping to work.",
    "Khal Drogo: That would make the projection [1 0 \n 0 0]",
    "Sith Lord: You people are impressive!",
    "Archbishop Neo: So Vectoria, What transformation has to be applied on the unit matrix for projection on y-axis?{open the puzzle} {solution: [0 0\n 0 1] (projectionYaxis.png)"};
    private static Sprite t1 = Resources.Load<Sprite>("Art/SithAvatar") as Sprite;
    private static Sprite t2 = Resources.Load<Sprite>("Art/KhalAvatar") as Sprite;
    private static Sprite t3 = Resources.Load<Sprite>("Art/wiertreeAvatar") as Sprite;
    private static Sprite t4 = Resources.Load<Sprite>("Art/AIJabrAvatar") as Sprite;
    private static Sprite t5 = Resources.Load<Sprite>("Art/LightAvatar") as Sprite;
    private static Sprite t6 = Resources.Load<Sprite>("Art/NeoAvatar") as Sprite;
    private static Sprite[] Portrait = {
        t1,t5,t2,t1,t3,t2,t1,t6
    };
    private static Sprite Question = Resources.Load<Sprite>("Art/Narrative Art/projectionXaxis") as Sprite;
    private static Matrix4x4 Answer = Matrix4x4.identity;
    public ProjectContent()
    {
        name = "";
        description = "";
        Answer[0, 0] = 0;
        Answer[0, 1] = 0;
        Answer[1, 0] = 0;
        Answer[1, 1] = 1;

    }

    public override string[] getContent()
    {
        return Narr;
    }
    public override Sprite[] getPortrait()
    {
        return Portrait;
    }
    public override Sprite getQuestion()
    {
        return Question;
    }
    public override Matrix4x4 getAnswer()
    {
        return Answer;
    }
}
