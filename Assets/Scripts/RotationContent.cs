using UnityEngine;
using System.Collections;

public class RotationContent : Content
{

    private string[] Narr = { "Sith Lord: Has anyone given a thought to how our planet rotates around its axis?",
    "Khal Drogo: Sounds like another form of transformation skill we can acquire - Rotation!",
    "white weirwood trees: I believe this transformation can be computed based on the angle theta around which the vector rotates.",
    "Sith Lord: Great job grasping the concept. Basically, rotation sends a vector [x,y] to [-y,x] for a 90 degree rotation around the origin. Based on this information, how would you depict this transformation in matrix form?",
    "Light of Lord: Building on that, the transformed images of basic vectors [1,0] and [0,1] using this rotation would be[0,1] and [-1,0]. ",
    "Khal Drogo: I see! They would form the columns of the standard transformation matrix for rotation around the origin by 90 degree - [(0,-1),(1,0)].",
    "Sith Lord: I'm impressed! Can anyone further generalize this transformation?",
    "Light of Lord: I can notice that the images T([[0,1]]) = [(cosθ),(sinθ)],and T([-1,0]) = [(-sinθ),(cosθ)], which makes the standard rotation transformation matrix equal to[(cosθ,-sinθ),(sinθ, cosθ)] in counterclockwise direction.",
    "White weirwood trees: But what if we wanted to rotate it in clockwise direction?",
    "Khal Drogo: I imagine it would be equal to counterclockwise rotation matrix, but through the angle -theta.",
    "Sith Lord: That's correct! I am proud to have you all as my apprentices.",
    "Archbishop Neo: Vectoria, keeping this information in mind, you need to decipher the rotation matrix of a unit square matrix through a 45 degree rotation around the origin."};
    private static Sprite t1 = Resources.Load<Sprite>("Art/SithAvatar") as Sprite;
    private static Sprite t2 = Resources.Load<Sprite>("Art/KhalAvatar") as Sprite;
    private static Sprite t3 = Resources.Load<Sprite>("Art/wiertreeAvatar") as Sprite;
    private static Sprite t4 = Resources.Load<Sprite>("Art/AIJabrAvatar") as Sprite;
    private static Sprite t5 = Resources.Load<Sprite>("Art/LightAvatar") as Sprite;
    private static Sprite t6 = Resources.Load<Sprite>("Art/NeoAvatar") as Sprite;
    private static Sprite[] Portrait = {
        t1,t2,t3,t1,t5,t2,t1,t5,t3,t2,t1,t6
    };
    private static Sprite Question = Resources.Load<Sprite>("Art/Narrative Art/rotation90") as Sprite;
    private static Matrix4x4 Answer = Matrix4x4.identity;
    public RotationContent()
    {
        name = "";
        description = "";
        Answer[0, 0] = Mathf.Round(Mathf.Cos(45) * 10f) / 10f;
        Answer[0, 1] = Mathf.Round(-Mathf.Sin(45) * 10f) / 10f;
        Answer[1, 0] = Mathf.Round(Mathf.Sin(45) * 10f) / 10f;
        Answer[1, 1] = Mathf.Round(Mathf.Cos(45) * 10f) / 10f;
        Debug.Log(Answer);
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

