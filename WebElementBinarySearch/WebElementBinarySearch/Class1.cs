using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebElementBinarySearch
{
    public class WebElementBinarySearch
    {
        public static IWebElement SearchInSorted (String name, IList<IWebElement> list)
        {
            int j = list.Count;
            int i = 0;
            if (StrComparer.Compare(name,list[i].Text)==-1 || StrComparer.Compare(name, list[j-1].Text) == 1) throw new Exception("Element not found!");
            while (!list[i].Text.Equals(name))
            {
                if (StrComparer.Compare(name, list[(j + i) / 2].Text) <= 0)
                    j = i+ (j - i) / 2;
                else
                    i = i+ (j - i) / 2 + 1;
                if (i==j && !list[i].Text.Equals(name)) throw new Exception("Element not found!");
            }
            return list[i];
        }

        public static IWebElement SearchInUnsorted (String name, IList<IWebElement> list)
        {
            IWebElement[] list0 = { };
            list.CopyTo(list0, 0);
            Array.Sort(list0,new WebElementTextComparer());
            return SearchInSorted(name, list0);
        }


        class WebElementTextComparer : System.Collections.Generic.IComparer<IWebElement>
        {
            public int Compare(IWebElement x, IWebElement y)
            {
                int i = 0;
                int j = 0;
                while (x.Text.Length - i != 0 && y.Text.Length - j != 0)
                {
                    while (x.Text[i] == '\'')
                        i++;
                    while (y.Text[j] == '\'')
                        j++;
                    switch (x.Text[i])
                    {
                        case 'і':
                            if (y.Text[j] == 'ї')
                                return -1;
                            else if (y.Text[j] == 'и')
                                return 1;
                            else if (y.Text[j] == 'і')
                                break;
                            else if ('и'.CompareTo(y.Text[j]) != 0)
                                return 'и'.CompareTo(y.Text[j]);
                            break;

                        case 'ї':
                            if (y.Text[j] == 'й')
                                return -1;
                            else if (y.Text[j] == 'і')
                                return 1;
                            else if (y.Text[j] == 'ї')
                                break;
                            else if ('и'.CompareTo(y.Text[j]) != 0)
                                return 'и'.CompareTo(y.Text[j]);
                            break;

                        case 'є':
                            if (y.Text[j] == 'ж')
                                return -1;
                            else if (y.Text[j] == 'е')
                                return 1;
                            else if (y.Text[j] == 'є')
                                break;
                            else if ('е'.CompareTo(y.Text[j]) != 0)
                                return 'е'.CompareTo(y.Text[j]);
                            break;

                        default:
                            if (x.Text[i].CompareTo(y.Text[j]) != 0)
                                return x.Text[i].CompareTo(y.Text[j]);
                            break;

                    }

                    i++;
                    j++;
                }
                return x.Text.Length.CompareTo(y.Text.Length);
            }

        }


        class StrComparer
        {
            public static int Compare(String x, String y)
            {
                int i = 0;
                int j = 0;
                while (x.Length - i != 0 && y.Length - j != 0)
                {
                    while (x[i] == '\'')
                        i++;
                    while (y[j] == '\'')
                        j++;
                    switch (x[i])
                    {
                        case 'і':
                            if (y[j] == 'ї')
                                return -1;
                            else if (y[j] == 'и')
                                return 1;
                            else if (y[j] == 'і')
                                break;
                            else if ('и'.CompareTo(y[j]) != 0)
                                return 'и'.CompareTo(y[j]);
                            break;

                        case 'ї':
                            if (y[j] == 'й')
                                return -1;
                            else if (y[j] == 'і')
                                return 1;
                            else if (y[j] == 'ї')
                                break;
                            else if ('и'.CompareTo(y[j]) != 0)
                                return 'и'.CompareTo(y[j]);
                            break;

                        case 'є':
                            if (y[j] == 'ж')
                                return -1;
                            else if (y[j] == 'е')
                                return 1;
                            else if (y[j] == 'є')
                                break;
                            else if ('е'.CompareTo(y[j]) != 0)
                                return 'е'.CompareTo(y[j]);
                            break;

                        default:
                            if (x[i].CompareTo(y[j]) != 0)
                                return x[i].CompareTo(y[j]);
                            break;

                    }

                    i++;
                    j++;
                }
                return x.Length.CompareTo(y.Length);
            }
        }
    }
}
