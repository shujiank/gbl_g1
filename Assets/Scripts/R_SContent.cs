using UnityEngine;
using System.Collections;

public class R_SContent : Content {

    private string[] Narr = {"Sith Lord: What if we were to reflect a unit matrix along y-axis and then stretch it to 2 units along positive y direction?",
    "Lord of light: That should be easy! We can multiply the matrix of reflection transformation to that of the stretch transformation to obtain the resultant transformation matrix.",
    "Sith Lord: You are getting there, but keep in mind that matrix multiplication is not commutative.",
    "White weirwood trees: Oh! That means the order of the matrix would matter.",
    "Sith Lord: Let me put it this way, consider the reflection matrix R and stretch matrix S. For vector [x y] to tranform, transformation S(R([x y])) needs to be applied.",
    "Khal Drogo: I see! That means the resultant transformation should be S X R and not R X S, as one would intuitively assume.",
    "Lord of Light: So the composition of the linear transformation reflection [(-1,0),(0,1)] and stretch [(1,0),(0,2)] will be [(-1,0),(0,2)] {Show ReflectStretchComb.png}",
    "Sith Lord: You got it!",
    "Archbishop Neo: Now Vectoria, you have to reflect the unit matrix along the x axis and then stretching it horizontally in positive x-direction to 3 units, what would be tranformation matrix?"
};
    private static Sprite t1 = Resources.Load<Sprite>("Art/SithAvatar") as Sprite;
    private static Sprite t2 = Resources.Load<Sprite>("Art/KhalAvatar") as Sprite;
    private static Sprite t3 = Resources.Load<Sprite>("Art/wiertreeAvatar") as Sprite;
    private static Sprite t4 = Resources.Load<Sprite>("Art/AIJabrAvatar") as Sprite;
    private static Sprite t5 = Resources.Load<Sprite>("Art/LightAvatar") as Sprite;
    private static Sprite t6 = Resources.Load<Sprite>("Art/NeoAvatar") as Sprite;
    private static Sprite[] Portrait = {
        t1,t5,t1,t3,t1,t2,t5,t1,t6
    };
    private static Sprite Question = Resources.Load<Sprite>("Art/Narrative Art/ReflectStretchComb") as Sprite;
    private static Matrix4x4 Answer = Matrix4x4.identity;
    public R_SContent()
    {
        name = "";
        description = "";
        Answer[0, 0] = 3;
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
