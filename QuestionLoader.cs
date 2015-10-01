using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModelQuestion {
    class QuestionLoader {
        private const string TEXT_EXT = ".txt";

        public static Question[] LoadQuestion(string dir) {
            string[] files = Directory.GetFiles(dir);
            Dictionary<string, FilePair> dict = new Dictionary<string, FilePair>();
            
            foreach (string filename in files) {
                string realname = Path.GetFileNameWithoutExtension(filename);
                string extname = Path.GetExtension(filename);

                FilePair pair;
                if (dict.TryGetValue(realname, out pair)) {
                    // nothing
                } else {
                    pair = dict[realname] = new FilePair();
                }

                if (extname == TEXT_EXT) {
                    pair.TextFile = filename;
                } else {
                    pair.ImageFile = filename;
                }
            }

            LinkedList<Question> questionList = new LinkedList<Question>();
            foreach (var pair in dict) {
                if (pair.Value.ImageFile != null && pair.Value.TextFile != null) {
                    try {
                        string[] lines = File.ReadAllLines(pair.Value.TextFile);
                        Question q = new Question() {
                            Name = pair.Key,
                            ImageFile = pair.Value.ImageFile,
                            Detail = lines[0],
                            Answer = lines[1],
                            Other = lines.Skip(2).ToArray()
                        };
                        questionList.AddLast(q);
                    } catch (IndexOutOfRangeException e) {
                        Console.WriteLine(e.StackTrace);
                    }
                } else {
                    Console.WriteLine("Incomplete pair: {0}: <{1}, {2}>", pair.Key, pair.Value.ImageFile, pair.Value.TextFile);
                }
            }

            return questionList.ToArray();
        }
    }
}
