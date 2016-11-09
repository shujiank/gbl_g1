using UnityEngine;
using System.Collections;

public class TestContent : Content {

    private string[] testone = { "text1", "text2", "text3", "text4" };

    public TestContent() {
        name = "";
        description = "";
    }

    public override string[] getContent()
    {
        return testone;
    }
}
