using System;

namespace Lap01;

public class PhoneBook
{
    public List<string> ContactName = ["Yousef", "Mohamed"];
    public List<int> PhoneNumber = [01234567, 01543278];

    public int this[string subContactName]
    {
        get
        {
            for (int i = 0; i < ContactName.Count; i++)
            {
                if (ContactName[i] == subContactName)
                {
                    return PhoneNumber[i];
                }
            }
            return -1;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(subContactName) || value <= 0)
            {
                Console.WriteLine("Error");
                return;
            }

            for (int i = 0; i < ContactName.Count; i++)
            {
                if (ContactName[i] == subContactName)
                {
                    PhoneNumber[i] = value;
                    return;
                }
            }

            ContactName.Add(subContactName);
            PhoneNumber.Add(value);
        }
    }

    public string this[int subPhoneNumber]
    {
        get
        {
            for (int i = 0; i < PhoneNumber.Count; i++)
            {
                if (PhoneNumber[i] == subPhoneNumber)
                {
                    return ContactName[i];
                }
            }
            return "Not Found";
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                Console.WriteLine("Error");
                return;
            }
            for (int i = 0; i < PhoneNumber.Count; i++)
            {
                if (PhoneNumber[i] == subPhoneNumber)
                {
                    ContactName[i] = value;
                    return;
                }
            }
            PhoneNumber.Add(subPhoneNumber);
            ContactName.Add(value);
        }
    }
}
