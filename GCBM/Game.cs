using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCBM
{
    public class Game
    {
        private string _title;
        private string _id;
        private string _region;
        private string _path;
        private string _extension;
        private int _size;

        public Game() { }
        public Game(string title, string id, string region, string path, string extension, int size)
        {
            _title = title;
            _id = id;
            _region = region;
            _path = path;
            _extension = extension;
            _size = size;
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }
        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }
        public string Region
        {
            get { return _region; }
            set
            {
                _region = value;
            }
        }
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
            }
        }
        public int Size
        {
            get { return _size; }
            set
            {
                _size = value;
            }
        }
        public string Extension
        {
            get { return _extension; }
            set
            {
                _extension = value;
            }
        }
        // Other operators by analogy

        public override string ToString()
        {
            return Title + " [" + ID + "]";
        }

        
    }
}