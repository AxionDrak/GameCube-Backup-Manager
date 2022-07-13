namespace GCBM
{
    public class Game
    {
        public Game()
        {
        }

        public Game(string title, string id, string region, string path, string extension, int size)
        {
            Title = title;
            ID = id;
            Region = region;
            Path = path;
            Extension = extension;
            Size = size;
        }

        public string Title { get; set; }

        public string ID { get; set; }

        public string Region { get; set; }

        public string Path { get; set; }

        public int Size { get; set; }

        public string Extension { get; set; }
        // Other operators by analogy

        public override string ToString()
        {
            return Title + " [" + ID + "]";
        }
    }
}