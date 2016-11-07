using UnityEngine;
using UnityEngine.UI;

public class drawExample : MonoBehaviour
{
    // When added to an object, draws colored rays from the
    // transform position.
    public int lineCount = 100;
    public float radius = 3.0f;
    public InputField m00, m01, m10, m11;
    int current_transformation = 0; // 0:stretch, 1:reflection, 2:rotation, 3:shear

    Vector3[] v = new Vector3[4];

    /*
    Matrix4x4 mat = new Matrix4x4(1, 0, 0, 0,
                                  0, 1, 0, 0,
                                  0, 0, 0, 0,
                                  0, 0, 0, 0);
    */
    Matrix4x4 mat = Matrix4x4.identity;
    static Material lineMaterial;

    void Start()
    {
        resetMatrix();
        displayMatrix();
    }

    void displayMatrix()
    {
        m00.text = mat[0, 0].ToString();
        m01.text = mat[0, 1].ToString();
        m10.text = mat[1, 0].ToString();
        m11.text = mat[1, 1].ToString();
    }

    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }
    
    public void setTransformationType(int i)
    {
        current_transformation = i;
    }

    void transform_stretch(float x, float y)
    {
        setMatrix(x, 0, 0, y);
        displayMatrix();
    }

    void transform_shear(float x, float y)
    {
        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            setMatrix(1, x, 0, 1);
            displayMatrix();
        }
        else
        {
            setMatrix(1, 0, y, 1);
            displayMatrix();
        }
    }

    void transform_rotation(float x, float y)
    {
        float angle = (x + y) / 500 * 360;
        setMatrix(Mathf.Cos(angle), -Mathf.Sin(angle), Mathf.Sin(angle), Mathf.Cos(angle));
        displayMatrix();
    }

    public void dragReact(float x, float y)
    {
        Debug.Log("x");
        Debug.Log(x);
        Debug.Log("y");
        Debug.Log(y);

        switch (current_transformation)
        {
            case 0:
                transform_stretch(x, y);
                break;
            case 1:
                transform_rotation(x, y);
                break;
            case 2:
                break;
            case 3:
                transform_shear(x, y);
                break;
            case 4:
                break;
        }

    }
    
    

    void setMatrix(float m00, float m01, float m10, float m11)
    {
        mat[0, 0] = m00;
        mat[0, 1] = m01;
        mat[1, 0] = m10;
        mat[1, 1] = m11;
    }

    public void inputMatrix()
    {
        setMatrix(float.Parse(m00.text.ToString()), float.Parse(m01.text.ToString()),
            float.Parse(m10.text.ToString()), float.Parse(m11.text.ToString()));
    }

    public void resetMatrix()
    {
        mat = Matrix4x4.identity;
        displayMatrix();
    }

    // Will be called after all regular rendering is done
    public void OnRenderObject()
    {
        CreateLineMaterial();
        // Apply the line material
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        // Set transformation matrix for drawing to
        // match our transform

        Matrix4x4 m = Matrix4x4.identity; 
        Vector3 translation = new Vector3(-2, -2, 0);
        m.SetTRS(translation, Quaternion.identity, new Vector3(1, 1, 1));

        GL.MultMatrix(transform.localToWorldMatrix * m);
        //GL.MultMatrix(m);

        v[0] = new Vector3(0, 0, 0);
        v[1] = new Vector3(0, 1, 0);
        v[2] = new Vector3(1, 1, 0);
        v[3] = new Vector3(1, 0, 0);
        
        for (int i = 0; i < 4; i++)
        {
            v[i] = mat.MultiplyPoint(v[i]);
            //Debug.Log(v[i]);
        }


        // Draw x, y axises
        GL.Begin(GL.LINES);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(-3, 0, 0);
        GL.Vertex3(7, 0, 0);
        GL.Vertex3(0, -10, 0);
        GL.Vertex3(0, 10, 0);
        GL.End();

        GL.Begin(GL.QUADS);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex(v[0]);
        GL.Vertex(v[1]);
        GL.Vertex(v[2]);
        GL.Vertex(v[3]);
        GL.End();


        GL.PopMatrix();
    }
}