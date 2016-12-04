using UnityEngine;
using System.Collections;

public class StretchOnLineContent : Content{

    private string[] Narr = {"Sith Lord: So far we have seen stretch direction either towards or away from Y axis or X axis.What will happen to this shape when I say that all the point along y = -3 is a stretch by the factor of 2 and the point that are on y = x remain fixed.",
    "Lord of light: I think the point such as (2, 2) and(-2, 2) will remain fixed as they are on the line y = x.But I am confused about the y = -3x and how it will affect the shape.I know that point satisfying the equation will move 2 unit but I am not sure.",
    "Khal Drogo: I think the point that satisfying the equation y = -3x and line parallel to the equation have a stretch of 2 units.",
    "Sith Lord: Both of you are right.This will result in a new grid.",
    "Sith Lord: Can someone tell me stretch matrix for this problem.I will give you a hint.Consider A as the transformation matrix[a b\n c d] this matrix when multiplied with any point should yield the new stretch point.",
    "White weirwood trees: This means when I apply A[2,2] =[2 ,2] and A[-1,3] =[-3,6].By solving I found out A =[(5/4,-1/4), (-3/4, 7/4)]",
    "Sith Lord: Superb !!!",
    "Archbishop Neo: Now, Vectoria, your next obstacle entails solving a similar problem.What will happen to unit at origin when point at y = x remain fixed and point at y = -x are stretch by the factor of 2.What would be the transformation matrix ?? "
};
    private static Sprite t1 = Resources.Load<Sprite>("Art/SithAvatar") as Sprite;
    private static Sprite t2 = Resources.Load<Sprite>("Art/KhalAvatar") as Sprite;
    private static Sprite t3 = Resources.Load<Sprite>("Art/wiertreeAvatar") as Sprite;
    private static Sprite t4 = Resources.Load<Sprite>("Art/AIJabrAvatar") as Sprite;
    private static Sprite t5 = Resources.Load<Sprite>("Art/LightAvatar") as Sprite;
    private static Sprite t6 = Resources.Load<Sprite>("Art/NeoAvatar") as Sprite;
    private static Sprite[] Portrait = {
        t1,t5,t2,t1,t1,t3,t1,t6
    };
    private static Sprite Question = Resources.Load<Sprite>("Art/Narrative Art/ProblemCombinationalProblemStrechOnLineEquationGrid") as Sprite;
    private static Matrix4x4 Answer = Matrix4x4.identity;
    public StretchOnLineContent()
    {
        name = "";
        description = "";
        Answer[0, 0] = 1.5f;
        Answer[0, 1] = -0.5f;
        Answer[1, 0] = -0.3f;
        Answer[1, 1] = 1.5f;

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
