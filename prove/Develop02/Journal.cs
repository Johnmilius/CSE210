using System.Formats.Asn1;
using System.IO;

class Journal
{
    public List<JournalEntry> Entries = new List<JournalEntry>();

    public void saveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (JournalEntry entry in Entries)
            {
                writer.Write(entry.formatToFile());
                if (entry.formatToFile().EndsWith("\n"))
                { }
                else { Console.WriteLine(); }
            }
        }
    }

    public void loadFile(string fileName)
    {
        string fileContent = File.ReadAllText(fileName);

        string[] parts = fileContent.Split(new string[] { "~~", "\n" }, StringSplitOptions.None);

        for (int i = 0; i < parts.Length; i += 3)
        {
            JournalEntry job = new JournalEntry();
            job.date = DateTime.Parse(parts[i]).Date;
            job.prompt = parts[i + 1];
            job.response = parts[i + 2];

            this.Entries.Add(job);
        }
    }


}