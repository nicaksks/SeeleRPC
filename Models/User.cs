namespace SeeleRichPresence.Models
{
    public class ChallengeData
    {
        public int PreMazeGroupIndex { get; set; }
    }

    public class PlayerDetailInfo
    {
        public int UID { get; set; }
        public int CurFriendCount { get; set; }
        public int WorldLevel { get; set; }
        public string? Signature { get; set; }
        public string? NickName { get; set; }
        public int Birthday { get; set; }
        public int Level { get; set; }
        public PlayerSpaceInfo? PlayerSpaceInfo { get; set; }
        public int HeadIconID { get; set; }
    }

    public class PlayerSpaceInfo
    {
        public ChallengeData? ChallengeData { get; set; }
        public int PassAreaProgress { get; set; }
        public int LightConeCount { get; set; }
        public int AvatarCount { get; set; }
        public int AchievementCount { get; set; }
    }

    public class Root
    {
        public PlayerDetailInfo? PlayerDetailInfo { get; set; }
    }



}
