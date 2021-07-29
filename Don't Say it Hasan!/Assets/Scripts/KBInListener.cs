using System.Collections;
using TMPro;
using UnityEngine;

public class KBInListener : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Color32 myColor;
    Color32[] newVertexColors;
    TextMeshProUGUI gt;
    private TMP_Text m_TextComponent;
    TMP_TextInfo textInfo;
    string targetString;
    string currentString = "";
    int currentCharacter = 0;

    Color32 c0;

    void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();
        textInfo = m_TextComponent.textInfo;
    }
    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
        targetString = gt.text;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                //clear text?
                currentString = "";
                currentCharacter = 0;
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                //check against final text
                if (targetString == currentString) print("correct");
                else print("WRONG DUD");
                currentString = "";
                currentCharacter = 0;
            }
            else
            {
                currentString += c;
                currentCharacter = currentString.Length;
                // StartCoroutine(MarkCorrectText());
                if (currentString == targetString.Substring(0, currentString.Length))
                {
                    MarkCorrectCharacters();
                }
                else
                {
                    m_TextComponent.ForceMeshUpdate();//I think this resets the mesh.
                    currentString = "";
                    print("WRONG DUD");
                    currentCharacter = 0;
                }

                if (targetString == currentString)
                {
                    m_TextComponent.ForceMeshUpdate();
                    print("correct");
                    currentString = "";
                    currentCharacter = 0;
                }
            }
            print(currentString.Length);
        }
    }

    private void MarkCorrectCharacters()
    {
        m_TextComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = m_TextComponent.textInfo;

        Color32[] newVertexColors;
        Color32 c0 = m_TextComponent.color;

        for (int i = 0; i < currentCharacter; i++)
        {
            int characterCount = textInfo.characterCount;
            if (characterCount == 0) return;
            // Get the index of the material used by the current character.
            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
            // Get the vertex colors of the mesh used by this text element (character or sprite).
            newVertexColors = textInfo.meshInfo[materialIndex].colors32;
            // Get the index of the first vertex used by this text element.
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;
            // Only change the vertex color if the text element is visible.
            if (textInfo.characterInfo[i].isVisible)
            {
                c0 = new Color32((byte)199, (byte)55, (byte)55, 255);
                // c0 = myColor;

                newVertexColors[vertexIndex + 0] = c0;
                newVertexColors[vertexIndex + 1] = c0;
                newVertexColors[vertexIndex + 2] = c0;
                newVertexColors[vertexIndex + 3] = c0;

                // New function which pushes (all) updated vertex data to the appropriate meshes when using either the Mesh Renderer or CanvasRenderer.
                m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

                // This last process could be done to only update the vertex data that has changed as opposed to all of the vertex data but it would require extra steps and knowing what type of renderer is used.
                // These extra steps would be a performance optimization but it is unlikely that such optimization will be necessary.
            }
        }
    }
}
