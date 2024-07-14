using System;
using System.Collections.Generic;

namespace DictionaryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tạo một Từ điển <TKey, TValue>
            Dictionary<int, string> myDictionary = new Dictionary<int, string>();

            // Thêm một số giá trị cặp khóa cho Từ điển
            myDictionary.Add(1, "Apple");
            myDictionary.Add(2, "Orange");
            myDictionary.Add(3, "Cherry");

            // Sử dụng phương pháp ContainsKey để kiểm tra xem một khóa có tồn tại trong Từ điển hay không
            int keyToCheck = 2;
            if (myDictionary.ContainsKey(keyToCheck))
            {
                Console.WriteLine($"Key {keyToCheck} exists in the dictionary.");
            }
            else
            {
                Console.WriteLine($"Key {keyToCheck} does not exist in the dictionary.");
            }

            // Sử dụng phương thức TryGetValue để truy xuất giá trị được liên kết với một khóa nhất định một cách an toàn
            int keyToGetValue = 3;
            if (myDictionary.TryGetValue(keyToGetValue, out string value))
            {
                Console.WriteLine($"Value associated with key {keyToGetValue} is: {value}");
            }
            else
            {
                Console.WriteLine($"Key {keyToGetValue} does not exist in the dictionary.");
            }

            // Sử dụng vòng lặp foreach để lặp qua các mục KeyValuePair<TKey, TValue> trong Từ điển và in chúng
            Console.WriteLine("Dictionary contents:");
            foreach (KeyValuePair<int, string> kvp in myDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }
    }
}
