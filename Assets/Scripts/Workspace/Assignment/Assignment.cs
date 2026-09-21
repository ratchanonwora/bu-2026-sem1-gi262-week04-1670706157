using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            if (words == null) return;

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                if (wordCounts.ContainsKey(currentWord))
                {
                    wordCounts[currentWord]++;
                }
                else
                {
                    wordCounts[currentWord] = 1;
                }
            }

            foreach (KeyValuePair<string, int> pair in wordCounts)
            {
                Debug.Log($"word: '{pair.Key}' count: {pair.Value}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            if (numbers == null) return;

            Dictionary<int, int> numberCounts = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (numberCounts.ContainsKey(currentNumber))
                {
                    numberCounts[currentNumber]++;
                }
                else
                {
                    numberCounts[currentNumber] = 1;
                }
            }

            foreach (KeyValuePair<int, int> pair in numberCounts)
            {
                Debug.Log($"number: {pair.Key} count: {pair.Value}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            if (input == null)
            {
                Debug.Log("Valid");
                return;
            }

            Dictionary<char, char> bracketPairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            LinkedList<char> stack = new LinkedList<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (bracketPairs.ContainsKey(c))
                {
                    stack.AddLast(c);
                }
                else if (bracketPairs.ContainsValue(c))
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }

                    char lastOpenBracket = stack.Last.Value;
                    if (bracketPairs[lastOpenBracket] != c)
                    {
                        Debug.Log("Invalid");
                        return;
                    }

                    stack.RemoveLast();
                }
            }

            if (stack.Count == 0)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid");
            }
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<int> current = list.Last;
            while (current != null)
            {
                Debug.Log(current.Value);
                current = current.Previous;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log(slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();

            Dictionary<string, int> mergedDictionary = new Dictionary<string, int>(dict1);

            foreach (KeyValuePair<string, int> pair in dict2)
            {
                if (mergedDictionary.ContainsKey(pair.Key))
                {
                    mergedDictionary[pair.Key] += pair.Value;
                }
                else
                {
                    mergedDictionary.Add(pair.Key, pair.Value);
                }
            }

            foreach (KeyValuePair<string, int> pair in mergedDictionary)
            {
                Debug.Log($"key: {pair.Key}, value: {pair.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            if (list.Count == 0) return;

            Dictionary<int, bool> seen = new Dictionary<int, bool>();
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                LinkedListNode<int> next = current.Next;

                if (seen.ContainsKey(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    seen.Add(current.Value, true);
                }

                current = next;
            }

            foreach (int val in list)
            {
                Debug.Log(val);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }

            Dictionary<int, int> frequency = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                if (frequency.ContainsKey(num))
                {
                    frequency[num]++;
                }
                else
                {
                    frequency[num] = 1;
                }
            }

            int mostFrequentNumber = numbers[0];
            int maxCount = frequency[mostFrequentNumber];

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                int count = frequency[num];
                if (count > maxCount)
                {
                    mostFrequentNumber = num;
                    maxCount = count;
                }
            }

            Debug.Log($"{mostFrequentNumber} count: {maxCount}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;

            if (!string.IsNullOrEmpty(itemName))
            {
                if (inventory.ContainsKey(itemName))
                {
                    inventory[itemName] += quantity;
                }
                else
                {
                    inventory.Add(itemName, quantity);
                }
            }

            foreach (KeyValuePair<string, int> pair in inventory)
            {
                Debug.Log($"{pair.Key}: {pair.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            if (eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;
                eventQueue.RemoveFirst();

                Debug.Log($"Processing event: {currentEvent.Name}");
                Debug.Log($"Remaining events in queue: {eventQueue.Count}");

                string eventType = currentEvent.EventType?.ToLower();
                if (eventType == "enemy")
                {
                    Debug.Log($"Enemy event processed - {currentEvent.Name}");
                }
                else if (eventType == "powerup")
                {
                    Debug.Log($"Power-up event processed - {currentEvent.Name}");
                }
                else if (eventType == "level")
                {
                    Debug.Log($"Level event processed - {currentEvent.Name}");
                }
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;

            if (!string.IsNullOrEmpty(statName))
            {
                if (playerStats.ContainsKey(statName))
                {
                    playerStats[statName] += value;
                }
                else
                {
                    playerStats.Add(statName, value);
                }

                Debug.Log($"Updated {statName}: {playerStats[statName]}");
            }

            Debug.Log("Current player statistics:");
            foreach (KeyValuePair<string, int> pair in playerStats)
            {
                Debug.Log($"{pair.Key}: {pair.Value}");
            }
        }

        #endregion
    }
}
