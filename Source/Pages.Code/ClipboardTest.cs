using System;

using Xamarin.Forms;
using P42.Utils;
using System.Linq;
using System.Collections.Generic;
using Forms9Patch;

namespace Forms9PatchDemo
{
    public class ClipboardTest : ContentPage
    {
        static int seed = 3452;
        static Random _rand = new Random(seed);

        public ClipboardTest()
        {
            CopyPaste();
        }



        bool CopyPaste()
        {
            var entry = new Forms9Patch.ClipboardEntry();

            var testByteArray = new byte[200];
            _rand.NextBytes(testByteArray);
            entry.AddItem("application/x-forms9patchdemo-byte", testByteArray[0]);
            entry.AddItem("application/x-forms9patchdemo-bytebuffer", testByteArray);

            var testChar = (char)_rand.Next(255);
            entry.AddItem("application/x-forms9patchdemo-char", testChar);

            var testInt = _rand.Next();
            entry.AddItem("application/x-forms9patchdemo-int", testInt);

            var testDouble = _rand.NextDouble();
            entry.AddItem("application/x-forms9patchdemo-double", testDouble);

            var testString = "This is application/x-forms9patchdemo-string: ⅓ ⅔ ⓪ ① ② ③ ④ ⑤ ⑥ ⑦ ⑧ ⑨ ⑩ ⑪ ⑫ ⑬ ⑭ ⑮ ⑯ ⑰ ⑱ ⑲ ⑳  🅰 🅱 🅲 🅳 🅴 🅵 🅶 🅷 🅸 🅹 🅺 🅻 🅼 🅽 🅾 🅿 🆀 🆁 🆂 🆃 🆄 🆅 🆆 🆇 🆈 🆉 🙃 😐 😑 🤔 🙄 😮 😔 😖 😕";
            entry.AddItem("application/x-forms9patchdemo-string", testString);

            var testIntList = new List<int>();
            for (int i = 0; i < 20; i++)
                testIntList.Add(i);
            entry.AddItem("application/x-forms9patchdemo-int-list", testIntList);

            var testDoubleList = new List<double>();
            for (int i = 0; i < 20; i++)
                testDoubleList.Add(i + i / 10.0);
            entry.AddItem("application/x-forms9patchdemo-double-list", testDoubleList);

            var testStringList = new List<string>();
            for (int i = 0; i < 20; i++)
                testStringList.Add(RandomString(10));
            entry.AddItem("application/x-forms9patchdemo-string-list", testStringList);

            entry.AddOnDemandItem("application/x-forms9patchdemo-ondemand-string", () => DateTime.Now.ToLocalTime().ToString());

            Clipboard.Entry = entry;

            var resultString = (string)Clipboard.Entry.GetItem("application/x-forms9patchdemo-string").Item;


            return false;
        }

        static string RandomString(int length)
        {
            const string chars = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~¡¢£¤¥¦§¨©ª«⅓⅔⓪①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_rand.Next(s.Length)]).ToArray());
        }
    }
}
