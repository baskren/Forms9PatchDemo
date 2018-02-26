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
            entry.AddValue("application/x-forms9patchdemo-byte", testByteArray[0]);
            entry.AddValue("application/x-forms9patchdemo-bytebuffer", testByteArray);

            var testChar = (char)_rand.Next(255);
            entry.AddValue("application/x-forms9patchdemo-char", testChar);

            var testInt = _rand.Next();
            entry.AddValue("application/x-forms9patchdemo-int", testInt);

            var testDouble = _rand.NextDouble();
            entry.AddValue("application/x-forms9patchdemo-double", testDouble);

            var testString = "This is application/x-forms9patchdemo-string: ⅓ ⅔ ⓪ ① ② ③ ④ ⑤ ⑥ ⑦ ⑧ ⑨ ⑩ ⑪ ⑫ ⑬ ⑭ ⑮ ⑯ ⑰ ⑱ ⑲ ⑳  🅰 🅱 🅲 🅳 🅴 🅵 🅶 🅷 🅸 🅹 🅺 🅻 🅼 🅽 🅾 🅿 🆀 🆁 🆂 🆃 🆄 🆅 🆆 🆇 🆈 🆉 🙃 😐 😑 🤔 🙄 😮 😔 😖 😕";
            entry.AddValue("application/x-forms9patchdemo-string", testString);

            var testIntList = new List<int>();
            for (int i = 0; i < 20; i++)
                testIntList.Add(i);
            entry.AddValue("application/x-forms9patchdemo-int-list", testIntList);

            var testDoubleList = new List<double>();
            for (int i = 0; i < 20; i++)
                testDoubleList.Add(i + i / 10.0);
            entry.AddValue("application/x-forms9patchdemo-double-list", testDoubleList);

            var testStringList = new List<string>();
            for (int i = 0; i < 20; i++)
                testStringList.Add(RandomString(10));
            entry.AddValue("application/x-forms9patchdemo-string-list", testStringList);

            entry.AddOnDemandValue("application/x-forms9patchdemo-ondemand-string", () => DateTime.Now.ToLocalTime().ToString());

            Clipboard.Entry = entry;

            var resultByteArray = (byte[])Clipboard.Entry.GetItem("application/x-forms9patchdemo-bytebuffer").Value;
            if (resultByteArray.Count() != testByteArray.Count())
                throw new Exception("byte array counts don't match");
            for (int i = 0; i < resultByteArray.Count(); i++)
                if (resultByteArray[i] != testByteArray[i])
                    throw new Exception("byte arrays don't match at index [" + i + "]");

            var resultByte = (byte)Clipboard.Entry.GetItem("application/x-forms9patchdemo-byte").Value;
            if (resultByte != testByteArray[0])
                throw new Exception("bytes don't match");

            var resultChar = (char)Clipboard.Entry.GetItem("application/x-forms9patchdemo-char").Value;
            if (resultChar != testChar)
                throw new Exception("chars don't match");

            var resultInt = (int)Clipboard.Entry.GetItem("application/x-forms9patchdemo-int").Value;
            if (resultInt != testInt)
                throw new Exception("ints don't match");

            var resultDouble = (double)Clipboard.Entry.GetItem("application/x-forms9patchdemo-double").Value;
            if (resultDouble != testDouble)
                throw new Exception("doubles don't match");

            var resultString = (string)Clipboard.Entry.GetItem("application/x-forms9patchdemo-string").Value;
            if (resultString != testString)
                throw new Exception("Strings don't match");

            var resultIntList = (List<int>)Clipboard.Entry.GetItem("application/x-forms9patchdemo-int-list").Value;
            if (resultIntList.Count != testIntList.Count)
                throw new Exception("int list counts don't match");
            for (int i = 0; i < resultIntList.Count; i++)
                if (resultIntList[i] != testIntList[i])
                    throw new Exception("int lists don't match at index [" + i + "]");

            var resultStringList = (List<string>)Clipboard.Entry.GetItem("application/x-forms9patchdemo-string-list").Value;
            if (resultStringList.Count != testStringList.Count)
                throw new Exception("string list counts don't match");
            for (int i = 0; i < resultIntList.Count; i++)
                if (resultStringList[i] != testStringList[i])
                    throw new Exception("string lists don't match at index [" + i + "]");

            return true;
        }

        static string RandomString(int length)
        {
            const string chars = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~¡¢£¤¥¦§¨©ª«⅓⅔⓪①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_rand.Next(s.Length)]).ToArray());
        }
    }
}
