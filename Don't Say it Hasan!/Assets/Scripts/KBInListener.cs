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

    void Awake() 
    {
        m_TextComponent = GetComponent<TMP_Text>();
        textInfo = m_TextComponent.textInfo;

        Color32 c0 = m_TextComponent.color;
    }
    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
        targetString = gt.text;
    }

    // Update is called once per frame
    void Update()
    {
        m_TextComponent.ForceMeshUpdate();
        int characterCount = textInfo.characterCount;

        foreach (char c in Input.inputString)
        {
            int materialIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;
            newVertexColors = textInfo.meshInfo[materialIndex].colors32;
            int vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;

            if (c == '\b') // has backspace/delete been pressed?
            {
                //clear text?
                currentString = "";
                currentCharacter = 0;
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                //check against final text
                if(targetString == currentString) print("correct");
                else print("WRONG DUD");
                currentString = "";
                currentCharacter = 0;
            }
            else
            {
                currentString += c;
            }

            if (currentString.Length > targetString.Length)
            {
                print("WRONG DUD");
                currentString = "";
                currentCharacter = 0;
            }

            string sub =  targetString.Substring(0, currentString.Length);
            print(sub+":"+currentString+":"+(sub==currentString).ToString());
            if(sub == currentString)
            {
                for(int i = 0; i < sub.Length; i++)
                {
                }
            }
        }
    }
}
