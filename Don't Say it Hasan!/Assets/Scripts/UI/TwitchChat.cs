using UnityEngine;
using System.Net.Sockets;
using System.IO;
using Core;

namespace UI
{
    public class TwitchChat : MonoBehaviour, ITimed
    {
        private TcpClient twitchClient;
        private StreamReader reader;
        private StreamWriter writer;

        public string username, channelName;
        public bool timesUp = false;
        private string password = "oauth:140lnc8fwf3gaf32de494zhnoft0c3"; //Get the password from https://twitchapps.com/tmi
        [SerializeField] GameObject chatterObject;

        private void Awake()
        {
            Connect();
        }

        void Update()
        {
            if (!twitchClient.Connected)
            {
                Connect();
            }
            ReadChat();
        }

        private void Connect()
        {
            twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
            reader = new StreamReader(twitchClient.GetStream());
            writer = new StreamWriter(twitchClient.GetStream());

            writer.WriteLine("PASS " + password);
            writer.WriteLine("NICK " + username);
            writer.WriteLine("USER " + username + " 8 * :" + username);
            writer.WriteLine("JOIN #" + channelName);
            writer.Flush();
        }

        private void ReadChat()
        {
            if (twitchClient.Available > 0 && !timesUp)
            {
                var message = reader.ReadLine(); //Read in the current message
                // print(message);
                if (message.Contains("PRIVMSG"))
                {
                    //Get the users name by splitting it from the string
                    var splitPoint = message.IndexOf("!", 1);
                    var chatName = message.Substring(0, splitPoint);
                    chatName = chatName.Substring(1);

                    //Get the users message by splitting it from the string
                    splitPoint = message.IndexOf(":", 1);
                    message = message.Substring(splitPoint + 1);
                    //print(String.Format("{0}: {1}", chatName, message));
                    // chatBox.text = chatBox.text + "\n" + String.Format("{0}: {1}", chatName, message);

                    //Get chatters name and add it to the chat with a message
                    GameObject newChatter = Instantiate(chatterObject, transform, false);
                    var chatter = newChatter.GetComponent<Chatter>();
                    chatter.SetName(chatName);
                    chatter.SetMessage("This is a test message, you should replace it later");
                }
            }
        }

        public void TimesUp()
        {
            timesUp = true;
            reader.Close();
            twitchClient.Close();
        }
    }
}

