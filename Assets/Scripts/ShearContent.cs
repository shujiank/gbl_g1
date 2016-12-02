using UnityEngine;
using System.Collections;

public class ShearContent : Content
{

    private string[] ShearNarr = { "Sith Lord: What happens when you heat an iron cube and hammer one of its side?",
        "Khal Drogo: The shape of the cube gets deformed. ",
        "Sith Lord:  Good.. Now imagine a unit square matrix at [1,0] and [0,1], and we apply [(1,2),(0,1)] transformation on it. What will happen to this unit matrix? Observe this transformation matrix and share your findings.",
        "white weirwood trees: The diagonal elements of this matrix are one!!!" ,
        "Sith Lord: True, how does this transformation affect the unit square matrix?",
        "King of the eleventh dimension: It will deform the unit matrix. I think it will move the point [0,1] to [2,1]",
        "Sith Lord: Good work, this particular matrix is a horizontal shear matrix. ",
        "Sith Lord: What would a vertical shear matrix be like? ",
        "Lord of light: That would be [(1,0),(k,1)]. Where k can be >0 or <0.",
        "Sith Lord: Well someone is reading books. ",
        "Archbishop Neo: Vectoria, is it possible to have [(1,-1),(0,1)] transformation matrix? Or more specifically [(1,k),(0,1)]",
        "Archbishop Neo: Now, think what will happen if I apply [(1,k),(0,1)] transformation on to the unit square matrix? And what will happen when k=1." };
    private static Sprite t1 = Resources.Load<Sprite>("Art/SithAvatar") as Sprite;
    private static Sprite t2 = Resources.Load<Sprite>("Art/KhalAvatar") as Sprite;
    private static Sprite t3 = Resources.Load<Sprite>("Art/wiertreeAvatar") as Sprite;
    private static Sprite t4 = Resources.Load<Sprite>("Art/KingAvatar") as Sprite;
    private static Sprite t5 = Resources.Load<Sprite>("Art/LightAvatar") as Sprite;
    private static Sprite t6 = Resources.Load<Sprite>("Art/NeoAvatar") as Sprite;
    private static Sprite[] ShearPor = {
        t1,t2,t1,t3,t1,t4,t1,t1,t5,t1,t6,t6
    };
    private static Sprite ShearQue = Resources.Load<Sprite>("Art/Narrative Art/shear1") as Sprite;
    private static Matrix4x4 Answer = Matrix4x4.identity;
    public ShearContent()
    {
        name = "";
        description = "";
        Answer[0, 0] = 1;
        Answer[0, 1] = 1;
        Answer[1, 0] = 0;
        Answer[1, 1] = 1;

    }

    public override string[] getContent()
    {
        return ShearNarr;
    }
    public override Sprite[] getPortrait()
    {
        return ShearPor;
    }
    public override Sprite getQuestion()
    {
        return ShearQue;
    }
    public override Matrix4x4 getAnswer()
    {
        return Answer;
    }
}
