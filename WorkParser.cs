using System;

namespace lab2
{
    public static class WorkParser
    {
        public static Work Parse(string line)
        {
            string[] p = line.Split('|');
            if (p.Length < 4) throw new FormatException("Мало полей");
            return Create(p);
        }

        private static Work Create(string[] p)
        {
            string type = p[0].Trim().ToLower();
            if (type == "lab") return new LabWork(p[1].Trim(), p[2].Trim(), ParseDate(p[3]));
            if (type == "course") return new CourseWork(p[1].Trim(), p[2].Trim(), ParseDate(p[3]), p[4].Trim());
            if (type == "diploma")
            {
                if (p.Length < 6) throw new FormatException("Нужно 6 полей");
                return new DiplomaWork(p[1].Trim(), p[2].Trim(), ParseDate(p[3]), p[4].Trim(), int.Parse(p[5]));
            }
            if (type == "test")
            {
                if (p.Length < 6) throw new FormatException("Нужно 6 полей");
                return new TestWork(p[1].Trim(), p[2].Trim(), ParseDate(p[3]), p[4].Trim(), int.Parse(p[5]));
            }
            throw new FormatException($"Неизвестный тип: {type}");
        }

        private static DateTime ParseDate(string s) =>
            DateTime.ParseExact(s.Trim(), "yyyy.MM.dd", null);
    }
}
