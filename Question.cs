using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModelQuestion {
    public class Question {
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string TextFile { get; set; }
        public string Description { get; set; }
        public string[] Choice { get; set; }
        public string Selected { get; set; }

        public static Question[] LoadQuestion(string dir) {
            const string TEXT_EXT = ".txt";

            string[] files = Directory.GetFiles(dir);
            Dictionary<string, Question> dict = new Dictionary<string, Question>();

            foreach (string filename in files) {
                string realname = Path.GetFileNameWithoutExtension(filename);
                string extname = Path.GetExtension(filename);

                Question q;
                if (dict.TryGetValue(realname, out q)) {
                    // done
                } else {
                    q = dict[realname] = new Question();
                }

                if (extname == TEXT_EXT) {
                    try {
                        string[] lines = File.ReadAllLines(filename);
                        q.Description = lines[0];
                        q.Choice = lines.Skip(1).ToArray();

                        q.Name = realname;
                        q.TextFile = filename;
                    } catch (IndexOutOfRangeException e) {
                        Console.WriteLine(e.StackTrace);
                    }
                } else {
                    q.ImageFile = filename;
                }
            }

            return dict.Values.Where(q => q.ImageFile != null && q.TextFile != null && q.Choice.Length > 0).ToArray();
        }
    }
}
