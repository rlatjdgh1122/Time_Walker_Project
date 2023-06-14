public class QuestManager<T> where T : class
{
    private T ownerEntity;
    private Quest<T> previousQuest;
    private Quest<T> currentQuest = null;

    public void Setup(T owner, Quest<T> enrtyQuest)
    {
        ownerEntity = owner;
        currentQuest = null;
    }

    public void UpdateQuest()
    {
        if (currentQuest != null)
            currentQuest.Update(ownerEntity);
    }

    public void ChangeQuest(Quest<T> newQuest)
    {
        if (newQuest == null)
            return;

        if (currentQuest != null)
        {
            previousQuest = currentQuest;

            currentQuest.Exit(ownerEntity);
        }

        currentQuest = newQuest;
        currentQuest.Enter(ownerEntity);
    }
}
