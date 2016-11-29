﻿using UnityEngine;
using System.Collections;

public class ShearContent : Content
{

    private string[] ShearNarr = { "Sith Lord: What happen when you heat a iron cube and hammer one of its side ?",
        "Khal Drogo: The shape of the cube get deformed. ",
        "Sith Lord:  Good.. Now imagine a unit square matrix at [1,0] and [0,1], and we apply [(1,2),(0,1)] transforamtion on it.What will happen to this unit matrix ? Observer this transforamtion matrix and share your findings ?",
        "white weirwood trees: The diagonal element of this matrix are one!!!" ,
        "Sith Lord: True, how does this transforamtion effect the unit square matrix?",
        "King of the eleventh dimension: It will deformed the unit matrix. I think it will move the point [0,1] to [2,1]",
        "Sith Lord: Good work, this particular matrix is a horizontal shear matrix. ",
        "Sith Lord: What would a vertical share matrix be like ? ",
        "Lord of light: That would be [(1,0),(k,1)]. Where k can be >0 or <0.",
        "Sith Lord: Well someone is reading books. ",
        "Archbishop Neo: Victoria, is it possible to have [(1,-1),(0,1)] transforamtion matrix ? or more specifically [(1,k),(0,1)]",
        "Victoria: Let me think about it.",
        "Archbishop Neo: Ok, think what will happen if I apply this transforamtion on to the unit square matrix ? and what will happen when k=1." };
    private static Sprite t1 = Resources.Load<Sprite>("Art/SithAvatar") as Sprite;
    private static Sprite t2 = Resources.Load<Sprite>("Art/KhalAvatar") as Sprite;
    private static Sprite t3 = Resources.Load<Sprite>("Art/wiertreeAvatar") as Sprite;
    private static Sprite t4 = Resources.Load<Sprite>("Art/AIJabrAvatar") as Sprite;
    private static Sprite t5 = Resources.Load<Sprite>("Art/LightAvatar") as Sprite;
    private static Sprite t6 = Resources.Load<Sprite>("Art/NeoAvatar") as Sprite;
    private static Sprite[] ShearPor = {
        t1,t2,t1,t3,t1,t4,t1,t1,t5,t1,t6,t1,t6
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
