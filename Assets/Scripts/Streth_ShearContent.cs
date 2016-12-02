using UnityEngine;
using System.Collections;

public class Streth_ShearContent : Content {

    private string[] Narr = {"Sith Lord: How does a blacksmith convert a iron cube into any shape he want.",
    "Lord of light: He first make the iron mallable by heating it, in the furnace and then apply force to change the shape.",
    "Sith Lord: Good answer, now suppose you have have unit square matrix with  at [0,1] and [1,1]. And you first apply a stretch of [(2,0),(0,1)] and then a  shear of [(1,0),(2,1)]. What will happen ?",
    "Lord of light: The first matrix will enlarge the matrix in x axis and the second matrix will apply a shear of 2 unit in the positive y axis.",
    "White weirwood trees: I also thinks that if we change the order of these transformation matrix the result will remain the same. ",
    "Khal Drogo: I think this transformation make the matrix look like this.",
    "Sith Lord: Impressive works!",
    "Archbishop Neo: So Vectoria, What transformation has to be applied on the unit matrix to make it twice as large in both positive y and x axis and have a shear of 2 unit in x direction a unit?"
};
    private static Sprite t1 = Resources.Load<Sprite>("Art/SithAvatar") as Sprite;
    private static Sprite t2 = Resources.Load<Sprite>("Art/KhalAvatar") as Sprite;
    private static Sprite t3 = Resources.Load<Sprite>("Art/wiertreeAvatar") as Sprite;
    private static Sprite t4 = Resources.Load<Sprite>("Art/AIJabrAvatar") as Sprite;
    private static Sprite t5 = Resources.Load<Sprite>("Art/LightAvatar") as Sprite;
    private static Sprite t6 = Resources.Load<Sprite>("Art/NeoAvatar") as Sprite;
    private static Sprite[] Portrait = {
        t1,t5,t1,t5,t3,t2,t1,t6
    };
    private static Sprite Question = Resources.Load<Sprite>("Art/Narrative Art/ShearStreach") as Sprite;
    private static Matrix4x4 Answer = Matrix4x4.identity;
    public Streth_ShearContent()
    {
        name = "";
        description = "";
        Answer[0, 0] = 2;
        Answer[0, 1] = 2;
        Answer[1, 0] = 0;
        Answer[1, 1] = 2;

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
