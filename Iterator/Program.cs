// See https://aka.ms/new-console-template for more information
using System.Collections;

namespace Iterator
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Testing iterator");

            var collection = new CategoryCollection();
            foreach (var c in collection)
            {
                Console.WriteLine(c.Name);
            }
        }
    }

    class Category
    {
        public string Name { get; set; }
    }

    class CategoriesEnumerator : IEnumerator<Category>
    {
        private int categoryId = 0;

        public Category Current => new Category
        {
            //In really, there is no list, but the items were created just in time
            Name = $"Category {categoryId}"
        };

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (this.categoryId > 5)
                return false;
            else {
                this.categoryId++;
                return true;
            }
        }

        public void Reset()
        {
            this.categoryId=0;
        }
    }

    class CategoryCollection : IEnumerable<Category>
    {
        public IEnumerator<Category> GetEnumerator()
        {
            return new CategoriesEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}