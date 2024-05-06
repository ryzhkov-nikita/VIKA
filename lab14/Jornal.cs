using System.Collections.Generic;

namespace Lab12
{
    public class Journal
    {
        private List<JournalEntry> entries;

        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        public void AddEntry(object source, CollectionHandlerEventArgs e)
        {
            JournalEntry entry = new JournalEntry(e.CollectionName, e.ChangeType, e.ChangedObject.ToString());
            entries.Add(entry);
        }

        public override string ToString()
        {
            string result = "";
            foreach (JournalEntry entry in entries)
            {
                result += entry.ToString() + "\n";
            }
            return result;
        }
    }

    public class JournalEntry
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public string ChangedObjectInfo { get; set; }

        public JournalEntry(string collectionName, string changeType, string changedObjectInfo)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ChangedObjectInfo = changedObjectInfo;
        }

        public override string ToString()
        {
            return $"Collection: {CollectionName}, Change Type: {ChangeType}, Changed Object Info: {ChangedObjectInfo}";
        }
    }
}