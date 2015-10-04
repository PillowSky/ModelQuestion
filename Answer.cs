using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelQuestion {
    public class Answer {
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string Detail { get; set; }
        public string Correct { get; set; }
        public string[] Choice { get; set; }
        public string Selected { get; set; }

        public Answer(Question q) {
            Name = q.Name;
            ImageFile = q.ImageFile;
            Detail = q.Detail;
            Correct = q.Answer;
            var items = q.Other.ToList();
            items.Add(Correct);
            Choice = items.ToArray();
        }
    }
}
