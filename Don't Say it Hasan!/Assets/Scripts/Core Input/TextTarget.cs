using Core;
using TMPro;
using UnityEngine;
using Utility;

namespace CoreInput
{
    public class TextTarget : MonoBehaviour
    {
        [SerializeField] Color32 myColor;
        [SerializeField] GameObject background;
        Color32[] newVertexColors;
        private TMP_Text m_TextComponent;
        TMP_TextInfo textInfo;
        SceneDirector director;
        Color32 c0;
        private RectTransform m_RectTransform;
        string currentString = "";
        int currentCharacter = 0;
        WordQueue queue;

        [HideInInspector] public bool isSelected = false;
        public string targetString;
        void Awake()
        {
            queue = GameObject.FindGameObjectWithTag("Word Queue").GetComponent<WordQueue>();
            director = GameObject.FindGameObjectWithTag("Director").GetComponent<SceneDirector>();
            m_RectTransform = GetComponent<RectTransform>();
            m_TextComponent = GetComponent<TMP_Text>();
            textInfo = m_TextComponent.textInfo;
            m_TextComponent.text = queue.GetNextWord();
            targetString = m_TextComponent.text;
        }

        void Update()
        {
            HandleInput();
            background.SetActive(isSelected);
        }

        private void HandleInput()
        {
            if (isSelected && !ReactPanel.isSwitching && Input.anyKeyDown && !ReactPanel.timeOut)
            {
                foreach (char c in Input.inputString)
                {
                    if (c == '\b') // has backspace/delete been pressed?
                    {
                        currentString = "";
                        currentCharacter = 0;
                    }
                    else if ((c == '\n') || (c == '\r')) // enter/return
                    {
                        //check against final text, mostly as a failsafe
                        if (targetString == currentString) director.AddScore(targetString.Length);
                        currentString = "";
                        currentCharacter = 0;
                    }
                    else
                    {
                        currentString += c;
                        currentCharacter = currentString.Length;
                        if (targetString.Equals(currentString))
                        {
                            currentString = "";
                            currentCharacter = 0;
                            m_TextComponent.ForceMeshUpdate();
                            director.AddScore(targetString.Length);
                            director.wordCount += 1;
                            ChangeWord();
                            GetComponentInParent<ReactPanel>().SwitchForward();
                        }
                        else if (currentString.Equals(targetString.Substring(0, currentString.Length)))
                        {
                            MarkCorrectCharacters();
                        }
                        else
                        {
                            m_TextComponent.ForceMeshUpdate();//it's important to update the mesh.
                            currentString = "";
                            director.AddScore(-targetString.Length);
                            director.AddStress(0.05f);
                            currentCharacter = 0;
                        }
                    }
                }
            }
        }

        public void ChangeWord()
        {
            SetText(queue.GetNextWord());
            GetComponentInParent<ReactPanel>().MoveWord(m_RectTransform);
        }

        public void SetText(string newText)
        {
            m_TextComponent.text = newText;
            targetString = m_TextComponent.text;
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
}