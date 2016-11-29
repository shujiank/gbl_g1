using UnityEngine;
using System.Collections;

public class StretchZContent : Content {
    private string[] Narr = {};
    private static Sprite t1 = Resources.Load<Sprite>("Art/SithAvatar") as Sprite;
    private static Sprite t2 = Resources.Load<Sprite>("Art/KhalAvatar") as Sprite;
    private static Sprite t3 = Resources.Load<Sprite>("Art/wiertreeAvatar") as Sprite;
    private static Sprite t4 = Resources.Load<Sprite>("Art/AIJabrAvatar") as Sprite;
    private static Sprite t5 = Resources.Load<Sprite>("Art/LightAvatar") as Sprite;
    private static Sprite t6 = Resources.Load<Sprite>("Art/NeoAvatar") as Sprite;
    private static Sprite[] Portrait = {
        t6,t1,t5,t2,t1,t2,t1,t5,t1,t2,t1,t3,t1,t6,t6
    };
    private static Sprite Question = Resources.Load<Sprite>("Art/Narrative Art/reflectionX-axis") as Sprite;
    private static Matrix4x4 Answer = Matrix4x4.identity;
    public StretchZContent()
    {
        name = "";
        description = "";
        Answer[0, 0] = 0;
        Answer[0, 1] = -1;
        Answer[1, 0] = -1;
        Answer[1, 1] = 0;

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
