namespace GCBM
{
    public class Game
    {
        #region Properties        
        public string Title { get; set; }
        public string InternalName { get; set; }
        public string ID { get; set; }
        public string Region { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public string Path { get; set; }
        public string IDMakerCode { get; set; }
        public string IDGameCode { get; set; }
        public string IDRegionCode { get; set; }
        public string DiscID { get; set; }
        public string Date { get; set; }
        #endregion

        #region Constructors
        public Game()
        {

        }
        public Game(string Title, string ID, string Region, string Extension, int Size, string Path)
        {
            this.Title = Title;
            this.ID = ID;
            this.Region = Region;
            this.Extension = Extension;
            this.Size = Size;
            this.Path = Path;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return Title + " [" + ID + "]";
        }
        #endregion
    }
}