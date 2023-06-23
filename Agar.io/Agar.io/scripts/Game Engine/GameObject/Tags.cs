namespace AgarIO.scripts.GameEngine
{
    public class Tags<T> : List<T>
    {
        public Tags() { }

        public new T this[int index]
            => base[index];

        public static Tags<T> operator +(Tags<T> tags, T tag)
        {
            tags.Add(tag);

            return tags;
        }

        public static Tags<T> operator -(Tags<T> tags, T tag)
        {
            tags.Remove(tag);

            return tags;
        }

        public static bool operator ==(Tags<T> tags, T tag)
            => tags.Contains(tag);

        public static bool operator !=(Tags<T> tags, T tag)
            => !(tags == tag);

        public static bool operator ==(Tags<T> tags1, Tags<T> tags2)
        {
            foreach (T _tag in tags1)
                if (!tags2.Contains(_tag))
                    return false;

            return true;
        }

        public static bool operator !=(Tags<T> tags1, Tags<T> tags2)
            => !(tags1 == tags2);
    }
}
