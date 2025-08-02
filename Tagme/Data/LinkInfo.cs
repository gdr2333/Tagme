namespace Tagme.Data;

public class LinkInfo
{
    public bool HasCratedPage { get; set; } = false;

    public DateTime LastNewTag { get; set; } = DateTime.MinValue;

    public Queue<DateTime> VoteTags { get; set; } = [];

    private readonly static TimeSpan NewTagCD = TimeSpan.FromMinutes(1);

    private readonly static TimeSpan VoteTagCD = TimeSpan.FromMinutes(1);

    private const int VoteTagTimes = 5;

    public bool TryNewTag()
    {
        bool can = DateTime.Now - LastNewTag >= NewTagCD;
        LastNewTag = DateTime.Now;
        return can;
    }

    public bool TryVoteTag()
    {
        while (VoteTags.Count != 0 && DateTime.Now - VoteTags.Peek() >= VoteTagCD)
            VoteTags.Dequeue();
        bool can = VoteTags.Count < VoteTagTimes;
        if (can)
            VoteTags.Enqueue(DateTime.Now);
        return can;
    }
}
