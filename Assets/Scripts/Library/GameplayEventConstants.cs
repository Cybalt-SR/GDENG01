namespace Assets.Scripts.Library
{
    public static class GameplayEventConstants
    {
        public struct Roll
        {
            public const string REQUEST = "ROLLREQUEST";
            public const string SHAKE = "ROLLSHAKE";
            public const string DONE = "ROLLDONE";
            
            public struct Param
            {
                public const string REQUESTER = "ROLLREQUESTER";
                public const string STAT = "ROLLSTAT";
                public const string VALUE = "ROLLVALUE";
            }
        }
        public struct Player
        {
            public const string MOVEUP = "PLAYERMOVEUP";
            public const string MOVELEFT = "PLAYERMOVELEFT";
            public const string MOVEDOWN = "PLAYERMOVEDOWN";
            public const string MOVERIGHT = "PLAYERMOVERIGHT";
        }
        public struct Npc
        {
            public const string ENTER = "NPCENTER";
            public const string INITIATE = "NPCINITIATE";
            public const string TALK = "NPCTALK";
            public const string CHOOSE = "NPCCHOOSE";
            public const string EXIT = "NPCEXIT";
            public struct Param
            {
                public const string NAME = "NPCNAME";
                public const string MESSAGE = "NPCMESSAGE";
                public const string CHOICES = "NPCCHOICES";
                public const string CHOICE = "NPCCHOICE";
            }
        }
        public struct Portal
        {
            public const string USE = "PORTALUSE";
            public const string ENTER = "PORTALENTER";
            public const string EXIT = "PORTALEXIT";
            public struct Param
            {
                public const string TARGET = "PORTALTARGET";
            }
        }
        public struct Quest
        {
            public const string ACCEPT = "QUESTACCEPT";
            public const string FINISH = "QUESTFINISH";

            public struct Param
            {
                public const string NAME = "QUESTNAME";
            }
        }
        public struct Notice
        {
            public const string BROADCAST = "NOTICEBROADCAST";
            public struct Param
            {
                public const string MESSAGE = "NOTICEMESSAGE";
            }
        }
    }
}