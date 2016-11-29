using UnityEngine;
using System.Collections;

public class StretchContent : Content {

    private string[] Narr = {"Sith Lord: Since you guys are quite conversant in Linear Transformation. Let me test your knowledge.",
    "Sith Lord: Can anyone tell me what are the rules for a Linear Transformation ?",
    "Lord of light: One of the rule states that T(u+v)=T(u)+T(v). Where T is the transformation function and u and v are the input vectors. And the second rule....",
    "Khal Drogo: The second rule is that T(cu)=cT(u). Here c is a constant and u is the vector.",
    "Lord of light: I was about to say the same thing.",
    "Sith Lord: Give me few example of Linear Transformation ?",
    "King of the eleventh dimension: Projection, Reflection, Shear, compression, and expansion to name a few.",
    "Sith Lord: Is shifting a plane with a vector v a Linear Transformation ?",
    "Khal Drogo: I think the answer might be yes, as a vector u will be moved by v. However 2u will also be moved by v. This make me confuse as transformation function is giving the same result for 2u.",
    "white weirwood trees: I think the answer is No.",
    "Sith Lord: Yes indeed the answer is No. As T(2u)=v+2u !=2T(u)",
    "Sith Lord: What are compression and expansion ? Give a real world example for the same.",
    "Khal Drogo: Consider a spring that is used in shock absorber in a car. The shock absorber goes from a phase of compression and expansion when we move on a rough road.",
    "Sith Lord: Assume a spring to be a unit length square matrix having coordinate (1,0) and (0,1). Now if I apply stretch [(1,0),(0,2)] what will happen to the shape of the matrix.",
    "Lord of light: I think this will increase the breath of the unit matrix to 2 unit ",
    "Sith Lord: Good work.",
    "Archbishop Neo: Victoria, would you like to solve some similar puzzles?",
    "Victoria:  Yes, please !!!",
    "Archbishop Neo: What will happen to unit matrix when I apply following transformation [(1,0),(0,-2)], [(2,0),(0,1)] and[(-2,0),(0, 1)]."
};
    private static Sprite t1 = Resources.Load<Sprite>("Art/SithAvatar") as Sprite;
    private static Sprite t2 = Resources.Load<Sprite>("Art/KhalAvatar") as Sprite;
    private static Sprite t3 = Resources.Load<Sprite>("Art/wiertreeAvatar") as Sprite;
    private static Sprite t4 = Resources.Load<Sprite>("Art/AIJabrAvatar") as Sprite;
    private static Sprite t5 = Resources.Load<Sprite>("Art/LightAvatar") as Sprite;
    private static Sprite t6 = Resources.Load<Sprite>("Art/NeoAvatar") as Sprite;
    private static Sprite[] Portrait = {
        t1,t1,t5,t2,t5,t1,t4,t1,t2,t3,t1,t1,t2,t1,t5,t1,t6,t4,t6
    };
    private static Sprite Question = Resources.Load<Sprite>("Art/Narrative Art/solutionStrechInYaxis") as Sprite;
    private static Matrix4x4 Answer = Matrix4x4.identity;
    public StretchContent()
    {
        name = "";
        description = "";
        Answer[0, 0] = -4;
        Answer[0, 1] = 0;
        Answer[1, 0] = 0;
        Answer[1, 1] = -2;

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
};
