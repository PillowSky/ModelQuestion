using System;

namespace ModelQuestion {
    public class Question {
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string TextFile { get; set; }
        public string Description { get; set; }
        public string[] Choice { get; set; }
        public string Correct { get; set; }
        public string Selected { get; set; }
    }
}
