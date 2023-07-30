namespace SeeleRichPresence.Models
{
    public class ChallengeData
    {
        public int NoneScheduleMaxLevel { get; set; }
    }

    public class DetailInfo
    {
        public int UID { get; set; }
        public int CurFriendCount { get; set; }
        public int WorldLevel { get; set; }
        public string? Signature { get; set; }
        public string? Nickname { get; set; }
        public int Birthday { get; set; }
        public int Level { get; set; }
        public RecordInfo? RecordInfo { get; set; }
        public int HeadIconID { get; set; }
    }

    public class RecordInfo
    {
        public ChallengeData? ChallengeInfo { get; set; }
        public int MaxRogueChallengeScore { get; set; }
        public int EquipmentCount { get; set; }
        public int AvatarCount { get; set; }
        public int AchievementCount { get; set; }
    }

    public class Root
    {
        public DetailInfo? DetailInfo { get; set; }
    }



}
