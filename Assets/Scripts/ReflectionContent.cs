using UnityEngine;
using System.Collections;

public class ReflectionContent : Content
{

    private string[] Narr = {"Archbishop Neo: Hail your highness, we meet again! Having learned the art of transformations, you must use your wits to overcome the next barrier. Let us get you enlightened a bit more.",
    "Sith Lord: Let us move on to a specific form of transformation - Reflections.",
    "Lord of light: I have a feeling that it is supposed to be the mirror image of a vector, as the name suggests.",
    "Khal Drogo: I agree with that.",
    "Sith Lord: You are correct. Let us consider a scenario with a unit square matrix, having (x, y) coordinates as (1, 0) and (0, 1), positioned in front of a mirror placed facing the x-axis, what do you expect to see in the mirror?",
    "Khal Drogo: I am thinking it will convert the vector [x \n y] to  [-x \n -y]?",
    "Sith Lord: Think about it! You should also consider the fact that the reflection is along the x-axis.",
    "Lord of light: Oh! I think the vector would be converted to [x \n -y]. So the transformation matrix should be [1 0 \n 0 -1]",
    "Sith Lord: Correct! Now what would happen if we applied transformation \n [0 1 \n 1 0] on the unit matrix?",
    "Khal Drogo: That should be a reflection along the line x = y. ",
    "Sith Lord: Well done!",
    "White weirwood trees: Interesting! I'm noticing that these reflection transformations, like [1 0 \n 0 -1] and [0 1 \n 1 0], are equal to their own inverses.",
    "Sith Lord: Good observation! That is one major property of reflection - Every reflection is its own inverse.",
    "Archbishop Neo: Now, Vectoria, your next obstacle entails solving a similar problem.",
    "Archbishop Neo: What transformation has to be applied on the unit matrix for reflection through the line y = -x? {open the puzzle} {solution: [0 -1\n -1 0] (reflectionY-X.png)"};
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
    public ReflectionContent()
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
